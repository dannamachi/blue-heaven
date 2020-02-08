namespace BlueHeaven.src.Enums
{
    /// <summary>
    /// Dimention constants for display (x,y,w,h)
    /// </summary>
    public static class GraphicDimension
    {
        // game window (could write it so everything else depends on game window size)
        public static readonly int[] MainWindow = new int[] { 800, 600 };
        // root component
        public static readonly int[] MainBackground = new int[] { 0, 0, 800, 600 };
        // title component
        public static readonly int[] TitleBackground = new int[] { 0, 0, 600, 600 };
        // story component
        public static readonly int[] StoryFrame = new int[] { 0, 400, 600, 200 };
        public static readonly int[] TextFrame = new int[] { 10, 410, 580, 180 };
        // choice component
        public static readonly int[] ChoiceBox1 = new int[] { 0, 400, 600, 60 };
        public static readonly int[] ChoiceBox2 = new int[] { 0, 470, 600, 60 };
        public static readonly int[] ChoiceBox3 = new int[] { 0, 540, 600, 60 };
        // navigation component
        public static readonly int[] NavigationBar = new int[] { 600, 0, 200, 600 };
        public static readonly int[] NavigationTitle = new int[] { 600, 0, 200, 200 };
        public static readonly int[] NavigationReading = new int[] { 600, 200, 200, 200 };
        public static readonly int[] NavigationSetting = new int[] { 600, 400, 200, 200 };
        // personality component
        public static readonly int[] EditingFrame = new int[] { 50, 50, 350, 500 };
        public static readonly int[] InactiveOverlay = new int[] { 75, 75, 300, 450 };
        public static readonly int[] ToggleButton1 = new int[] { 125, 125, 200, 50 };
        public static readonly int[] ToggleButton2 = new int[] { 125, 225, 200, 50 };
        public static readonly int[] ToggleButton3 = new int[] { 125, 325, 200, 50 };
        public static readonly int[] ToggleButton4 = new int[] { 125, 425, 200, 50 };
        // reset component
        public static readonly int[] ResetFrame = new int[] { 400, 50, 350, 500 };
    }
}