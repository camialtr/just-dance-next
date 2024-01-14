using Nova;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// A simple example of a Tooltip componenent, which can activate a  <see cref="TooltipVisual"/>
    /// when a designated <see cref="TriggerRegion"/> is hovered using Nova's <see cref="Interaction"/> API.
    /// </summary>
    public class Tooltip : MonoBehaviour
    {
        private static readonly Vector2[] OffsetCorners = new Vector2[] { new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1), new Vector2(1, 1) };

        [Tooltip("The UIBlock to dispay and move while the tooltip is triggered.")]
        public UIBlock TooltipVisual = null;

        [Tooltip("The Interactable or Scroller whose bounds will define the area where the tooltip should be active when hovered.")]
        public GestureRecognizer TriggerRegion = null;

        [Header("Repositioning")]
        [Tooltip("If false, the tooltip will only hide/show but will not move.")]
        public bool FollowCursor = true;
        [Tooltip("The size of the cursor in pixels. Used to position the tooltip such that the cursor doesn't obscure it.")]
        public Rect CursorRect = new Rect(Vector2.zero, Vector2.one * 32);
        [Tooltip("If true, this tooltip will always try to position its tooltip visual within the bounds defined by the Trigger Region's UI Block.")]
        public bool KeepWithinRootBounds = true;
        [Tooltip("The camera used to route input. If left null, will try to fall back to first the ScreenSpace Target Camera and then the Main camera.")]
        public Camera InputCamera = null;

        public void OnEnable()
        {
            if (TooltipVisual != null)
            {
                // Make sure to start disabled
                TooltipVisual.gameObject.SetActive(false);
            }

            if (TriggerRegion == null)
            {
                // Can't subscribe to gesture events
                return;
            }

            // Subscribe to desired gestures
            TriggerRegion.UIBlock.AddGestureHandler<Gesture.OnHover>(ShowTooltip);
            TriggerRegion.UIBlock.AddGestureHandler<Gesture.OnMove>(MoveTooltip);
            TriggerRegion.UIBlock.AddGestureHandler<Gesture.OnUnhover>(HideTooltip);
        }

        public void OnDisable()
        {
            if (TriggerRegion == null)
            {
                // Can't unsubscribe from gesture events
                return;
            }

            // Unsubscribe from gestures
            TriggerRegion.UIBlock.RemoveGestureHandler<Gesture.OnHover>(ShowTooltip);
            TriggerRegion.UIBlock.RemoveGestureHandler<Gesture.OnMove>(MoveTooltip);
            TriggerRegion.UIBlock.RemoveGestureHandler<Gesture.OnUnhover>(HideTooltip);
        }

        /// <summary>
        /// Show the <see cref="TooltipVisual"/> on hovered.
        /// </summary>
        /// <param name="evt">The hover event data, which we can use to position the tooltip.</param>
        private void ShowTooltip(Gesture.OnHover evt)
        {
            if (TooltipVisual == null)
            {
                // Nothing to show
                return;
            }

            TooltipVisual.gameObject.SetActive(true);

            TooltipVisual.CalculateLayout();

            UpdateTooltipPosition(evt.PointerWorldPosition);
        }

        /// <summary>
        /// Update the tooltip position on as the pointer moves.
        /// </summary>
        /// <param name="evt">The move event data, which we can use to position the tooltip.</param>
        private void MoveTooltip(Gesture.OnMove evt)
        {
            if (TooltipVisual == null)
            {
                return;
            }

            UpdateTooltipPosition(evt.PointerWorldPosition);
        }

        /// <summary>
        /// Move the tooltip visual relative to the cursor.
        /// </summary>
        /// <param name="pointerWorldPosition">The cursor position in world space.</param>
        private void UpdateTooltipPosition(Vector3 pointerWorldPosition)
        {
            if (!FollowCursor)
            {
                // We don't want to move the tooltip.
                return;
            }

            Transform parent = TooltipVisual.transform.parent;
            Matrix4x4 parentLocalToWorldMatrix = parent != null ? parent.localToWorldMatrix : Matrix4x4.identity; 
            Matrix4x4 parentWorldToLocal = parent != null ? parent.worldToLocalMatrix : Matrix4x4.identity; 

            // Get the cursor position relative to the tooltip
            Vector2 pointerPositionParentSpace = parentWorldToLocal.MultiplyPoint(pointerWorldPosition);

            // The tooltip visual size in local space
            Vector2 visualSize = TooltipVisual.CalculatedSize.XY.Value * TooltipVisual.transform.localScale.x;

            // The extents of the tooltip visual in local space
            Vector2 extents = 0.5f * visualSize;
            
            // The default offset direction, which is to the bottom right of the cursor
            Vector2 offsetCorner = OffsetCorners[0];

            // Get the amount we need to offset the tooltip in 
            // local space based on the pixel size of the cursor
            Vector2 cursorOffset = GetApproximateWorldCursorOffset(pointerWorldPosition, offsetCorner);

            // The position to move the tooltip visual, relative to where it is now.
            Vector3 newLocalPosition = pointerPositionParentSpace + offsetCorner * (extents + cursorOffset);

            // If desired, try to flip the tooltip visual offset such that it doesn't
            // render outside the bounds of its root UIBlock
            if (KeepWithinRootBounds)
            {
                // Get the root UIBlock to bounds check against
                UIBlock root = TooltipVisual.Root;

                // The bounds of the root in root space
                Vector2 rootSize = root.CalculatedSize.XY.Value;
                Rect rootBounds = new Rect(-0.5f * rootSize, rootSize);
                
                // Try all four corners around the cursor.
                // Finishes on the top left of the cursor if they all fail.
                for (int i = 1; i < OffsetCorners.Length; ++i)
                {
                    // The point that's going to be the furthest from the cursor (in local space)
                    Vector3 furthestPointLocalSpace = newLocalPosition + (Vector3)(offsetCorner * extents);

                    // Convert the furthest point into world space
                    Vector3 furthestPointWorldSpace = parentLocalToWorldMatrix.MultiplyPoint(furthestPointLocalSpace);

                    // Convert the furthest point into root space
                    Vector3 furthestPointRootSpace = root.transform.InverseTransformPoint(furthestPointWorldSpace);

                    if (rootBounds.Contains(furthestPointRootSpace))
                    {
                        // In bounds, so we don't need to keep checkout corners.
                        break;
                    }

                    // Move on to the next corner
                    offsetCorner = OffsetCorners[i];
                    cursorOffset = GetApproximateWorldCursorOffset(pointerWorldPosition, offsetCorner);
                    newLocalPosition = pointerPositionParentSpace + (offsetCorner * (extents + cursorOffset));
                }
            }

            // Move the tooltip to its new local position
            TooltipVisual.TrySetLocalPosition(newLocalPosition);
        }

        /// <summary>
        /// Hide the <see cref="TooltipVisual"/> on unhovered.
        /// </summary>
        /// <param name="evt">The unhover event data.</param>
        private void HideTooltip(Gesture.OnUnhover evt)
        {
            if (TooltipVisual == null)
            {
                // Nothing to hide
                return;
            }

            TooltipVisual.gameObject.SetActive(false);
        }

        /// <summary>
        /// Calculates an offset to adjust the tooltip position such that the cursor doesn't obscure it.
        /// </summary>
        /// <remarks>
        /// This value will be incorrect if the camera used for the calculation
        /// is not the camera used to raycast the cursor for the initial gesture
        /// (or in the XR case where the cursor raycast comes from a controller).
        /// </remarks>
        private Vector2 GetApproximateWorldCursorOffset(Vector3 cursorWorldPosition, Vector2 offsetDirection)
        {
                                               // flip y because yMax in rect space is down
            Vector2 cursorOffset = new Vector2(offsetDirection.x < 0 ? CursorRect.xMin : CursorRect.xMax,
                                               offsetDirection.y > 0 ? CursorRect.yMin : CursorRect.yMax);

            UIBlock root = TooltipVisual.Root;
            Camera camera = InputCamera;

            if (camera == null)
            {
                // If the Input camera is unassigned, try to fallback to the screen space camera
                if (root.TryGetComponent(out ScreenSpace screenSpace) && screenSpace.TargetCamera != null)
                {
                    camera = screenSpace.TargetCamera;
                }
                else
                {
                    camera = Camera.main;
                }
            }

            if (camera == null)
            {
                // Main camera not found.
                return Vector2.zero;
            }

            // Convert cursor position to screen space
            Vector2 minScreenPosition = camera.WorldToScreenPoint(cursorWorldPosition);

            // Get the offset position of the cursor rect in screen space
            Vector2 maxScreenPosition = minScreenPosition + cursorOffset;

            // Convert the screen position into a ray
            Ray maxRay = camera.ScreenPointToRay(maxScreenPosition);
            
            Plane rootPlane = new Plane(root.transform.forward, root.transform.position);
            
            // Raycast against the UI Block root plane
            if (!rootPlane.Raycast(maxRay, out float distanceToRoot))
            {
                return Vector2.zero;
            }

            // The position in the world of the max point on the cursor rect
            Vector3 cursorMaxPoint = maxRay.GetPoint(distanceToRoot);

            // The size of the cursor in world space
            Vector2 cursorSize = cursorWorldPosition - cursorMaxPoint;

            float parentScale = TooltipVisual.transform.parent != null ? TooltipVisual.transform.parent.lossyScale.x : 1;

            // Absolute value of the cursor size, in root local space
            return Vector2.Max(cursorSize, -cursorSize) / parentScale;
        }
    }
}
