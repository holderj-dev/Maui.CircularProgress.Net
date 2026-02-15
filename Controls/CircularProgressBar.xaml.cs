using Microsoft.Maui.Graphics;
using Maui.CircularProgress.Net.Enums;

namespace Maui.CircularProgress.Net.Controls
{
    /// <summary>
    /// A customizable circular progress bar control for .NET MAUI
    /// </summary>
    public partial class CircularProgressBar : ContentView
    {
        #region Constructor

        public CircularProgressBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Bindable Properties

        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create(nameof(Progress), typeof(int), typeof(CircularProgressBar), 0);

        public static readonly BindableProperty MaxProgressProperty =
            BindableProperty.Create(nameof(MaxProgress), typeof(int), typeof(CircularProgressBar), 100);

        public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(int), typeof(CircularProgressBar), 100);

        public static readonly BindableProperty ThicknessProperty =
            BindableProperty.Create(nameof(Thickness), typeof(int), typeof(CircularProgressBar), 10);

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularProgressBar), Colors.Blue);

        public static readonly BindableProperty ProgressLeftColorProperty =
            BindableProperty.Create(nameof(ProgressLeftColor), typeof(Color), typeof(CircularProgressBar), Colors.LightGray);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CircularProgressBar), Colors.Black);

        public static readonly BindableProperty ShowTextProperty =
            BindableProperty.Create(nameof(ShowText), typeof(bool), typeof(CircularProgressBar), true);

        public static readonly BindableProperty ProgressEdgeShapeProperty =
            BindableProperty.Create(nameof(ProgressEdgeShape), typeof(LineCap), typeof(CircularProgressBar), LineCap.Butt);

        public static readonly BindableProperty ShapeProperty =
            BindableProperty.Create(nameof(Shape), typeof(ProgressBarShape), typeof(CircularProgressBar), ProgressBarShape.Circular);

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

        #region Protected Methods

        /// <summary>
        /// Handles property changes
        /// </summary>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == SizeProperty.PropertyName)
            {
                HeightRequest = Size;
                WidthRequest = Size;
            }
        }

        #endregion
    }
}