namespace Maui.CircularProgress.Net.Enums
{
    /// <summary>
    /// Defines the shape of the progress bar
    /// </summary>
    public enum ProgressBarShape
    {
        /// <summary>
        /// Full 360° circular progress bar starting from top (12 o'clock) going clockwise
        /// </summary>
        Circular,

        /// <summary>
        /// Semi-circle (180°) progress bar starting from bottom-left going to bottom-right
        /// </summary>
        Arch,

        /// <summary>
        /// Horizontal progress bar with rounded corners
        /// </summary>
        Flat
    }
}