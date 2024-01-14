using Nova;
using System.Text;
using UnityEngine;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// The style of a progress bar
    /// </summary>
    public enum ProgressBarStyle
    {
        /// <summary>
        /// Radial, expands clockwise as Percent increases
        /// </summary>
        Clockwise,

        /// <summary>
        /// Radial, expands counterclockwise as Percent increases
        /// </summary>
        CounterClockwise,

        /// <summary>
        /// Linear, expands vertically as Percent increases
        /// </summary>
        Vertical,

        /// <summary>
        /// Linear, expands horizontally as Percent increases
        /// </summary>
        Horizontal,
    }

    /// <summary>
    /// A simple example of a ProgressBar component which can be used to display a value between [0, 1] in a variety of <see cref="ProgressBarStyle"/>s.
    /// </summary>
    public class ProgressBar : MonoBehaviour
    {
        const int MinDecimals = 0;
        const int MaxDecimals = 4;

        // Special handling of 0% and 100% text formats
        private const string ZeroFormat = "0";
        private const string OneHundredFormat = "100";
        private const string ZeroPercentFormat = "0%";
        private const string OneHundredPercentFormat = "100%";
        
        [SerializeField, Range(0, 1), Tooltip("The current percent/progress amount.")]
        private float percent = 0.5f;

        [Header("Progress Indicator")]
        [Tooltip("The UI Block 2D whose properties will be modified to indicate the progress state.")]
        public UIBlock2D Fill = null;
        [Tooltip("How the Percent will be visualized.")]
        public ProgressBarStyle Style = ProgressBarStyle.CounterClockwise;

        [Header("Text Format")]
        [Tooltip("The Text Block use to display the fill percent.")]
        public TextBlock Text = null;
        [SerializeField, Range(MinDecimals, MaxDecimals), Tooltip("The decimal precision of the text string.")]
        private int decimalCount = 0;
        [SerializeField, Tooltip("Should \"%\" be appended onto the text string?")]
        private bool displayPercentSymbol = true;

        /// <summary>
        /// A string builder used internal to generate the <see cref="textFormat"/> string.
        /// </summary>
        private StringBuilder textFormatBuilder = new StringBuilder();

        /// <summary>
        /// The format to use when displaying the current 
        /// progress state on the <see cref="Text"/> visual.
        /// </summary>
        private string textFormat = string.Empty;

        /// <summary>
        /// Assign the current progress percent 
        /// and update visuals accordingly.
        /// </summary>
        public float Percent
        {
            get => percent;

            set 
            {
                percent = Mathf.Clamp01(value);
                UpdateProgressVisuals();
            }
        }

        /// <summary>
        /// Should '%' be appended to the displayed text?
        /// </summary>
        public bool DisplayPercentSymbol
        {
            get => displayPercentSymbol;
            set
            {
                if (displayPercentSymbol != value)
                {
                    displayPercentSymbol = value;
                    UpdateTextFormat();
                }

                UpdateTextVisual();
            }
        }

        /// <summary>
        /// The decimal precision of the displayed text.
        /// </summary>
        public int DecimalCount
        {
            get => decimalCount;
            set
            {
                if (decimalCount != value)
                {
                    decimalCount = value;
                    UpdateTextFormat();
                }

                UpdateTextVisual();
            }
        }

        private void Awake()
        {
            UpdateTextFormat();
        }

        /// <summary>
        /// Update the fill and text visuals
        /// </summary>
        private void UpdateProgressVisuals()
        {
            UpdateFillVisual();

            UpdateTextVisual();
        }

        /// <summary>
        /// Update the <see cref="Fill"/> visual based on <see cref="Percent"/>.
        /// </summary>
        private void UpdateFillVisual()
        {
            if (Fill == null)
            {
                return;
            }

            if (Percent == GetDisplayedPercent())
            {
                // Currently displaying the right percent.
                return;
            }

            switch (Style)
            {
                case ProgressBarStyle.Clockwise:
                    Fill.RadialFill.Enabled = true;
                    Fill.RadialFill.FillAngle = Percent * -360;
                    break;
                case ProgressBarStyle.CounterClockwise:
                    Fill.RadialFill.Enabled = true;
                    Fill.RadialFill.FillAngle = Percent * 360;
                    break;
                case ProgressBarStyle.Vertical:
                    Fill.AutoSize.Y = AutoSize.None;
                    Fill.Size.Y = Length.Percentage(Percent * (1 - Fill.CalculatedMargin.Y.Sum().Percent));
                    break;
                case ProgressBarStyle.Horizontal:
                    Fill.AutoSize.X = AutoSize.None;
                    Fill.Size.X = Length.Percentage(Percent * (1 - Fill.CalculatedMargin.X.Sum().Percent));
                    break;
            }
        }

        /// <summary>
        /// Update the <see cref="Text"/> visual based on <see cref="Percent"/>.
        /// </summary>
        private void UpdateTextVisual()
        {
            if (Text == null)
            {
                return;
            }

            string format = textFormat;

            // Special case 0 and 1 for "cleaner" visuals
            if (Percent == 0)
            {
                format = DisplayPercentSymbol ? ZeroPercentFormat : ZeroFormat;
            }
            else if (Percent == 1)
            {
                format = DisplayPercentSymbol ? OneHundredPercentFormat : OneHundredFormat;
            }

            // The percent string formats handle the 100x multiplication,
            // but the non-percent formats do not. 
            float scaledPercent = DisplayPercentSymbol ? Percent : Percent * 100;
            string text = string.Format(format, scaledPercent);

            if (Text.Text == text)
            {
                return;
            }

            Text.Text = text;
        }

        /// <summary>
        /// Update the desired text format based on the <see cref="DecimalCount"/> and <see cref="DisplayPercentSymbol"/>.
        /// </summary>
        private void UpdateTextFormat()
        {
            textFormatBuilder.Clear();

            // If decimal count is 0, don't append a '.'
            textFormatBuilder.Append(DecimalCount == 0 ? "{0:00" : "{0:00.");

            // Append however many decimals we want
            for (int i = 0; i < DecimalCount; ++i)
            {
                textFormatBuilder.Append("0");
            }

            // Append the % symbol if we want it
            if (DisplayPercentSymbol)
            {
                textFormatBuilder.Append("%");
            }

            // End the format
            textFormatBuilder.Append("}");

            // Apply to the text format
            textFormat = textFormatBuilder.ToString();
        }

        /// <summary>
        /// Get the percent currently displayed based on the properties of the <see cref="Fill"/> visual.
        /// </summary>
        private float GetDisplayedPercent()
        {
            switch (Style)
            {
                case ProgressBarStyle.Clockwise:
                    return Fill.RadialFill.FillAngle / -360;
                case ProgressBarStyle.CounterClockwise:
                    return Fill.RadialFill.FillAngle / 360;
                case ProgressBarStyle.Vertical:
                    return Fill.CalculatedSize.Y.Percent / Mathf.Clamp01(1 - Fill.CalculatedMargin.Y.Sum().Percent);
                default: // ProgressStyle.Horizontal
                    return Fill.CalculatedSize.X.Percent / Mathf.Clamp01(1 - Fill.CalculatedMargin.X.Sum().Percent);
            }
        }

        /// <summary>
        /// Update the visual state in editor
        /// </summary>
        private void OnValidate()
        {
            UpdateTextFormat();

            // This handles ensuring percent is clamped
            // and will update the visuals in edit mode.
            Percent = percent;
        }
    }
}
