using Microsoft.Maui.Graphics;
using Maui.CircularProgress.Net.Enums;

namespace Maui.CircularProgress.Net.Drawables
{
    /// <summary>
    /// Drawable class for rendering circular progress bars with multiple shape options
    /// </summary>
    public class CircularProgressBarDrawable : BindableObject, IDrawable
    {
        #region Bindable Properties

        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create(nameof(Progress), typeof(int), typeof(CircularProgressBarDrawable), 0);

        public static readonly BindableProperty MaxProgressProperty =
            BindableProperty.Create(nameof(MaxProgress), typeof(int), typeof(CircularProgressBarDrawable), 100);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBarDrawable), 100);

        public static readonly BindableProperty ThicknessProperty =
            BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBarDrawable), 10);

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBarDrawable), Colors.Blue);

        public static readonly BindableProperty ProgressLeftColorProperty =
            BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBarDrawable), Colors.LightGray);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CircularProgressBarDrawable), Colors.Black);

        public static readonly BindableProperty ShowTextProperty =
            BindableProperty.Create(nameof(ShowText), typeof(bool), typeof(CircularProgressBarDrawable), true);

        public static readonly BindableProperty ProgressEdgeShapeProperty =
            BindableProperty.Create(nameof(ProgressEdgeShape), typeof(LineCap), typeof(CircularProgressBarDrawable), LineCap.Butt);

        public static readonly BindableProperty ShapeProperty =
            BindableProperty.Create(nameof(Shape), typeof(ProgressBarShape), typeof(CircularProgressBarDrawable), ProgressBarShape.Circular);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the current progress value
        /// </summary>
        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        /// <summary>
        /// Gets or sets the maximum progress value
        /// </summary>
        public int MaxProgress
        {
            get => (int)GetValue(MaxProgressProperty);
            set => SetValue(MaxProgressProperty, value);
        }

        /// <summary>
        /// Gets or sets the size (diameter for circular/arch, width for flat)
        /// </summary>
        public int Size
        {
            get => (int)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the thickness of the progress bar
        /// </summary>
        public int Thickness
        {
            get => (int)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the completed progress
        /// </summary>
        public Color ProgressColor
        {
            get => (Color)GetValue(ProgressColorProperty);
            set => SetValue(ProgressColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the remaining progress
        /// </summary>
        public Color ProgressLeftColor
        {
            get => (Color)GetValue(ProgressLeftColorProperty);
            set => SetValue(ProgressLeftColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the progress text
        /// </summary>
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets whether to show the progress text
        /// </summary>
        public bool ShowText
        {
            get => (bool)GetValue(ShowTextProperty);
            set => SetValue(ShowTextProperty, value);
        }

        /// <summary>
        /// Gets or sets the edge shape (Butt for flat, Round for rounded)
        /// </summary>
        public LineCap ProgressEdgeShape
        {
            get => (LineCap)GetValue(ProgressEdgeShapeProperty);
            set => SetValue(ProgressEdgeShapeProperty, value);
        }

        /// <summary>
        /// Gets or sets the shape of the progress bar (Circular, Arch, or Flat)
        /// </summary>
        public ProgressBarShape Shape
        {
            get => (ProgressBarShape)GetValue(ShapeProperty);
            set => SetValue(ShapeProperty, value);
        }

        #endregion

        #region Draw Method

        /// <summary>
        /// Draws the progress bar on the canvas
        /// </summary>
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            int clampedProgress = Math.Clamp(Progress, 0, MaxProgress);
            float percentage = MaxProgress > 0 ? (float)clampedProgress / MaxProgress * 100 : 0;

            switch (Shape)
            {
                case ProgressBarShape.Circular:
                    DrawCircular(canvas, dirtyRect, clampedProgress, percentage);
                    break;
                case ProgressBarShape.Arch:
                    DrawArch(canvas, dirtyRect, clampedProgress, percentage);
                    break;
                case ProgressBarShape.Flat:
                    DrawFlat(canvas, dirtyRect, clampedProgress, percentage);
                    break;
            }
        }

        #endregion

        #region Private Drawing Methods

        /// <summary>
        /// Draws a circular (360°) progress bar
        /// </summary>
        private void DrawCircular(ICanvas canvas, RectF dirtyRect, int clampedProgress, float percentage)
        {
            float effectiveSize = Size - Thickness;
            float x = Thickness / 2f;
            float y = Thickness / 2f;

            if (percentage < 100)
            {
                float angle = GetAngleCircular(percentage);

                // Draw background circle (progress left)
                canvas.StrokeColor = ProgressLeftColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);

                // Draw arc (progress done)
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, 90, angle, true, false);
            }
            else
            {
                // Draw full circle when complete
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);
            }

            // Draw progress text
            if (ShowText)
            {
                float fontSize = effectiveSize / 2.86f;
                canvas.FontSize = fontSize;
                canvas.FontColor = TextColor;

                float verticalPosition = ((Size / 2) - (fontSize / 2)) * 1.15f;
                canvas.DrawString($"{clampedProgress}/{MaxProgress}", x, verticalPosition, effectiveSize, effectiveSize / 4,
                    HorizontalAlignment.Center, VerticalAlignment.Center);
            }
        }

        /// <summary>
        /// Draws an arch (180° semi-circle) progress bar
        /// </summary>
        private void DrawArch(ICanvas canvas, RectF dirtyRect, int clampedProgress, float percentage)
        {
            float effectiveSize = Size - Thickness;
            float x = Thickness / 2f;
            float y = Thickness / 2f;

            // Arch goes from 180° to 0° (bottom-left to bottom-right)
            float startAngle = 180;
            float maxSweep = 180;
            float sweepAngle = (percentage / 100f) * maxSweep;

            // Draw background arch (full 180° from left to right at bottom)
            canvas.StrokeColor = ProgressLeftColor;
            canvas.StrokeSize = Thickness;
            canvas.StrokeLineCap = ProgressEdgeShape;
            canvas.DrawArc(x, y, effectiveSize, effectiveSize, startAngle, maxSweep, true, false);

            // Draw progress arch
            if (percentage > 0)
            {
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, startAngle, sweepAngle, true, false);
            }

            // Draw progress text (only if ShowText is true)
            if (ShowText)
            {
                float fontSize = Size / 8f;
                canvas.FontSize = fontSize;
                canvas.FontColor = TextColor;

                // Position text at the bottom center of the arch
                float textY = Size - Thickness - (fontSize * 1.5f);
                canvas.DrawString($"{clampedProgress}/{MaxProgress}",
                    0, textY, Size, fontSize * 2,
                    HorizontalAlignment.Center, VerticalAlignment.Center);
            }
        }

        /// <summary>
        /// Draws a flat (horizontal) progress bar
        /// </summary>
        private void DrawFlat(ICanvas canvas, RectF dirtyRect, int clampedProgress, float percentage)
        {
            float width = Size;
            float height = Thickness;
            float x = 0;
            float y = (Size - Thickness) / 2; // Center vertically

            float cornerRadius = Thickness / 2;

            // Draw background
            canvas.FillColor = ProgressLeftColor;
            canvas.FillRoundedRectangle(x, y, width, height, cornerRadius);

            // Draw progress
            if (percentage > 0)
            {
                float progressWidth = width * (percentage / 100);
                canvas.FillColor = ProgressColor;
                canvas.FillRoundedRectangle(x, y, progressWidth, height, cornerRadius);
            }

            // Draw progress text
            if (ShowText)
            {
                float fontSize = height * 0.8f;
                canvas.FontSize = fontSize;
                canvas.FontColor = TextColor;

                canvas.DrawString($"{clampedProgress}/{MaxProgress}", x, y - fontSize - 5, width, fontSize,
                    HorizontalAlignment.Center, VerticalAlignment.Top);
            }
        }

        /// <summary>
        /// Calculates the angle for circular progress based on percentage
        /// </summary>
        private float GetAngleCircular(float percentage)
        {
            float factor = 90f / 25f;

            if (percentage > 75)
                return -180 - ((percentage - 75) * factor);
            else if (percentage > 50)
                return -90 - ((percentage - 50) * factor);
            else if (percentage > 25)
                return 0 - ((percentage - 25) * factor);
            else
                return 90 - (percentage * factor);
        }

        #endregion
    }
}