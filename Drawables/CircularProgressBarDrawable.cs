using Microsoft.Maui.Graphics;
using Maui.CircularProgress.Net.Enums;

namespace Maui.CircularProgress.Net.Drawables
{
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

        public int Progress
        {
            get => (int)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }
        public int MaxProgress
        {
            get => (int)GetValue(MaxProgressProperty);
            set => SetValue(MaxProgressProperty, value);
        }
        public int Size
        {
            get => (int)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }
        public int Thickness
        {
            get => (int)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }
        public Color ProgressColor
        {
            get => (Color)GetValue(ProgressColorProperty);
            set => SetValue(ProgressColorProperty, value);
        }
        public Color ProgressLeftColor
        {
            get => (Color)GetValue(ProgressLeftColorProperty);
            set => SetValue(ProgressLeftColorProperty, value);
        }
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        public bool ShowText
        {
            get => (bool)GetValue(ShowTextProperty);
            set => SetValue(ShowTextProperty, value);
        }
        public LineCap ProgressEdgeShape
        {
            get => (LineCap)GetValue(ProgressEdgeShapeProperty);
            set => SetValue(ProgressEdgeShapeProperty, value);
        }
        public ProgressBarShape Shape
        {
            get => (ProgressBarShape)GetValue(ShapeProperty);
            set => SetValue(ShapeProperty, value);
        }

        #endregion

        #region Draw Method

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

        private void DrawCircular(ICanvas canvas, RectF dirtyRect, int clampedProgress, float percentage)
        {
            float effectiveSize = Size - Thickness;
            float x = Thickness / 2f;
            float y = Thickness / 2f;

            if (percentage < 100)
            {
                float angle = GetAngleCircular(percentage);

                canvas.StrokeColor = ProgressLeftColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);

                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, 90, angle, true, false);
            }
            else
            {
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawEllipse(x, y, effectiveSize, effectiveSize);
            }

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

        private void DrawArch(ICanvas canvas, RectF dirtyRect, int clampedProgress, float percentage)
        {
            float effectiveSize = Size - Thickness;
            float x = Thickness / 2f;
            float y = Thickness / 2f;
                      
            float startAngle = 0f;
            float maxSweep = 180f;
            float progressSweep = maxSweep * (percentage / 100f);

            // 1. Draw Background Track
            canvas.StrokeColor = ProgressLeftColor;
            canvas.StrokeSize = Thickness;
            canvas.StrokeLineCap = ProgressEdgeShape;
            canvas.DrawArc(x, y, effectiveSize, effectiveSize, startAngle, maxSweep, false, false);

            // 2. Draw Progress Arc
            if (percentage > 0)
            {
                canvas.StrokeColor = ProgressColor;
                canvas.StrokeSize = Thickness;
                canvas.StrokeLineCap = ProgressEdgeShape;
                canvas.DrawArc(x, y, effectiveSize, effectiveSize, startAngle, progressSweep, false, false);
            }

            // 3. Draw Text
            if (ShowText)
            {
                float fontSize = effectiveSize / 5f;
                canvas.FontSize = fontSize;
                canvas.FontColor = TextColor;

                // Position text in the center-bottom of the arch area
                RectF textRect = new RectF(x, y + (effectiveSize / 4), effectiveSize, effectiveSize / 2);
                canvas.DrawString($"{clampedProgress}/{MaxProgress}", textRect,
                    HorizontalAlignment.Center, VerticalAlignment.Center);
            }
        }

        private void DrawFlat(ICanvas canvas, RectF dirtyRect, int clampedProgress, float percentage)
        {
            float width = Size;
            float height = Thickness;
            float x = 0;
            float y = (Size - Thickness) / 2;
            float cornerRadius = Thickness / 2;

            canvas.FillColor = ProgressLeftColor;
            canvas.FillRoundedRectangle(x, y, width, height, cornerRadius);

            if (percentage > 0)
            {
                float progressWidth = width * (percentage / 100);
                canvas.FillColor = ProgressColor;
                canvas.FillRoundedRectangle(x, y, progressWidth, height, cornerRadius);
            }

            if (ShowText)
            {
                float fontSize = height * 0.8f;
                canvas.FontSize = fontSize;
                canvas.FontColor = TextColor;

                canvas.DrawString($"{clampedProgress}/{MaxProgress}", x, y - fontSize - 5, width, fontSize,
                    HorizontalAlignment.Center, VerticalAlignment.Top);
            }
        }

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