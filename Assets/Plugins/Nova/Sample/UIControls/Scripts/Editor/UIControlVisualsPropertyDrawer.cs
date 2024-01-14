using Nova;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
#if PACKAGE_ANIMATION
using UnityEditor.Animations;
#endif
using UnityEngine;

namespace NovaSamples.UIControls.Editor
{
    [CustomPropertyDrawer(typeof(UIControlVisuals), true)]
    public class UIControlVisualsPropertyDrawer : PropertyDrawer
    {
        private static readonly GUIContent CreateAnimationsLabel = EditorGUIUtility.TrTextContent("Create Animations", "Creates all required animation assets and adds an Animator component if it doesn't already exist.");
        private const string CreateAnimatorControllerWindowTitle = "New Animation Contoller";
        private const string CreateAnimatorControllerMessage = "Create a new animator for the game object '{0}':";
        private const string AnimatorControllerAssetExtension = "controller";

        // Can't use nameof here because the serialized
        // field is private, which makes it inaccessible.
        private const string TransitionTargetName = "transitionTarget";

        private const string TransitionTypeName = nameof(UIControlVisuals.TransitionType);
        private const string TransitionDurationName = nameof(UIControlVisuals.TransitionDuration);

        private const string DefaultColorName = nameof(UIControlVisuals.DefaultColor);
        private const string HoveredColorName = nameof(UIControlVisuals.HoveredColor);
        private const string PressedColorName = nameof(UIControlVisuals.PressedColor);

        private const string SpritesName = nameof(UIControlVisuals.Sprites);
        private const string AnimationsName = nameof(UIControlVisuals.Animations);

        // The colors + transition duration
        private const int NumberOfColorStates = 3;

        private static readonly string[] ColorChangeFields = new string[] { TransitionTargetName, DefaultColorName, HoveredColorName, PressedColorName, TransitionDurationName };
        private static readonly string[] SpriteSwapFields = new string[] { TransitionTargetName, SpritesName };
        private static readonly string[] AnimationFields = new string[] { AnimationsName };

        private static readonly HashSet<string> BaseFields = new HashSet<string>()
        {
            TransitionDurationName,
            TransitionTargetName,
            TransitionTypeName,
            DefaultColorName,
            HoveredColorName,
            PressedColorName,
            SpritesName,
            AnimationsName,
        };

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!property.isExpanded)
            {
                return EditorGUIUtility.singleLineHeight;
            }

            float totalPropertyHeight = EditorGUI.GetPropertyHeight(property, includeChildren: true);

            SerializedProperty transitionTypeProp = property.FindPropertyRelative(TransitionTypeName);

            TransitionType transitionType = (TransitionType)transitionTypeProp.intValue;

            float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            float transitionTargetHeight = lineHeight;
            float transitionDurationHeight = lineHeight;
            float expectedSpritesHeight = GetFieldHeight(property, SpritesName);
            float actualSpritesHeight = lineHeight * GetChildPropertyCount(property, SpritesName);
            float expectedAnimationsHeight = GetFieldHeight(property, AnimationsName);
            float actualAnimationsHeight = lineHeight * GetChildPropertyCount(property, AnimationsName);
            float colorsHeight = NumberOfColorStates * lineHeight;

            totalPropertyHeight -= colorsHeight + expectedSpritesHeight + expectedAnimationsHeight + transitionTargetHeight;

            if (!transitionTypeProp.hasMultipleDifferentValues)
            {
                switch (transitionType)
                {
                    case TransitionType.ColorChange:
                        totalPropertyHeight += colorsHeight + transitionTargetHeight + transitionDurationHeight;
                        break;
                    case TransitionType.SpriteSwap:
                        totalPropertyHeight += actualSpritesHeight + transitionTargetHeight;
                        break;
                    case TransitionType.Animation:
                        totalPropertyHeight += actualAnimationsHeight;
                        break;
                }
            }

            return totalPropertyHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position = DrawProperty(position, property, label);

            if (!property.isExpanded)
            {
                return;
            }

            using (EditorGUI.IndentLevelScope scope = new EditorGUI.IndentLevelScope(1))
            {
                position = DrawAllChildClassFields(position, property.Copy());

                SerializedProperty transitionTypeProp = property.FindPropertyRelative(TransitionTypeName);

                position = DrawProperty(position, transitionTypeProp);

                TransitionType transitionType = (TransitionType)transitionTypeProp.intValue;

                if (transitionTypeProp.hasMultipleDifferentValues)
                {
                    return;
                }

                ItemView itemView = property.serializedObject.targetObject as ItemView;

                switch (transitionType)
                {
                    case TransitionType.ColorChange:
                        position = DrawFields(position, property, ColorChangeFields);
                        break;
                    case TransitionType.SpriteSwap:
                        position = DrawFields(position, property, SpriteSwapFields);
                        break;
                    case TransitionType.Animation:
                        position = DrawFields(position, property, AnimationFields);
#if PACKAGE_ANIMATION
                        if (property.serializedObject.targetObjects.Length == 1)
                        {
                            DrawCreateAnimationsButton(itemView);
                        }
#endif
                        break;
                }
            }
        }

        private static Rect DrawAllChildClassFields(Rect position, SerializedProperty property)
        {
            bool isBaseField = false;

            while (property.NextVisible(!isBaseField))
            {
                isBaseField = BaseFields.Contains(property.name);

                if (isBaseField)
                {
                    continue;
                }
                position = DrawProperty(position, property);
            }

            return position;
        }

        private static Rect DrawFields(Rect position, SerializedProperty property, string[] relativePropertyNames)
        {
            foreach (string relativePropertyName in relativePropertyNames)
            {
                SerializedProperty relativeProperty = property.FindPropertyRelative(relativePropertyName);

                if (relativeProperty.hasVisibleChildren)
                {
                    IEnumerator iterator = relativeProperty.GetEnumerator();

                    while (iterator.MoveNext())
                    {
                        position = DrawProperty(position, iterator.Current as SerializedProperty);
                    }
                }
                else
                {
                    position = DrawProperty(position, relativeProperty);
                }
            }

            return position;
        }

        private static Rect DrawProperty(Rect position, SerializedProperty property, GUIContent label = null)
        {
            position.height = EditorGUI.GetPropertyHeight(property, false);

            EditorGUI.PropertyField(position, property, label, includeChildren: false);

            position.y = position.yMax + EditorGUIUtility.standardVerticalSpacing;

            return position;
        }

        private static float GetFieldHeight(SerializedProperty property, string relativePropertyName)
        {
            SerializedProperty relativeProperty = property.FindPropertyRelative(relativePropertyName);

            return EditorGUI.GetPropertyHeight(relativeProperty, includeChildren: relativeProperty.isExpanded) + EditorGUIUtility.standardVerticalSpacing;
        }

        private static int GetChildPropertyCount(SerializedProperty property, string relativePropertyName)
        {
            SerializedProperty relativeProperty = property.FindPropertyRelative(relativePropertyName);

            if (!relativeProperty.hasVisibleChildren)
            {
                return 0;
            }

            int childCount = 0;

            foreach (var child in relativeProperty)
            {
                childCount++;
            }

            return childCount;
        }

#if PACKAGE_ANIMATION
        private static void DrawCreateAnimationsButton(ItemView itemView)
        {
            if (itemView == null || !itemView.TryGetVisuals(out UIControlVisuals controlVisuals))
            {
                return;
            }

            if (itemView.TryGetComponent(out Animator animator) && animator.runtimeAnimatorController != null)
            {
                return;
            }

            Rect buttonPosition = EditorGUILayout.GetControlRect();
            buttonPosition.xMin += EditorGUIUtility.labelWidth;

            AnimationStates animationStates = controlVisuals.Animations;

            if (!GUI.Button(buttonPosition, CreateAnimationsLabel))
            {
                // Button wasn't clicked
                return;
            }

            AnimatorController controller = CreateAnimatorControllerAsset(animationStates, itemView);

            if (controller == null)
            {
                return;
            }

            if (animator == null)
            {
                animator = Undo.AddComponent<Animator>(itemView.gameObject);
            }

            AnimatorController.SetAnimatorController(animator, controller);
        }

        private static AnimatorController CreateAnimatorControllerAsset(AnimationStates animations, ItemView target)
        {
            if (target == null)
            {
                return null;
            }

            // Where should we create the controller?
            string path = GetSaveControllerPath(target);

            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            // Get animation names
            string defaultAnimation = string.IsNullOrWhiteSpace(animations.DefaultAnimation) ? AnimationStates.DefaultStates.DefaultAnimation : animations.DefaultAnimation;
            string hoveredAnimation = string.IsNullOrWhiteSpace(animations.HoveredAnimation) ? AnimationStates.DefaultStates.HoveredAnimation : animations.HoveredAnimation;
            string pressedAnimation = string.IsNullOrWhiteSpace(animations.PressedAnimation) ? AnimationStates.DefaultStates.PressedAnimation : animations.PressedAnimation;

            // Create controller and hook up transitions.
            AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath(path);

            CreateAnimationForController(controller, defaultAnimation);
            CreateAnimationForController(controller, hoveredAnimation);
            CreateAnimationForController(controller, pressedAnimation);

            AssetDatabase.SaveAssets();
            AssetDatabase.ImportAsset(path);

            return controller;
        }

        private static AnimationClip CreateAnimationForController(AnimatorController controller, string animationName)
        {
            // Create the animation
            AnimationClip animation = AnimatorController.AllocateAnimatorClip(animationName);
            AssetDatabase.AddObjectToAsset(animation, controller);

            // Create a state in the animator controller for this animation
            AnimatorState state = controller.AddMotion(animation);

            // Add a transition property
            controller.AddParameter(animationName, AnimatorControllerParameterType.Trigger);

            // Add an any state transition
            AnimatorStateMachine stateMachine = controller.layers[0].stateMachine;
            AnimatorStateTransition transition = stateMachine.AddAnyStateTransition(state);
            transition.AddCondition(AnimatorConditionMode.If, 0, animationName);

            return animation;
        }

        private static string GetSaveControllerPath(MonoBehaviour target)
        {
            string objectName = target.gameObject.name;
            
            string message = string.Format(CreateAnimatorControllerMessage, objectName);

            return EditorUtility.SaveFilePanelInProject(CreateAnimatorControllerWindowTitle, objectName, AnimatorControllerAssetExtension, message);
        }
#endif
    }
}
