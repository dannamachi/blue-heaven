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
        public static readonly int[] TitleHelp = new int[] { 200, 200, 200, 50 };
        public static readonly int[] TitleTextHelp = new int[] { 210, 210, 180, 30 };
        public static readonly int[] TitleCredits = new int[] { 200, 300, 200, 50 };
        public static readonly int[] TitleTextCredits = new int[] { 210, 310, 180, 30 };
        public static readonly int[] TitleReload = new int[] { 200, 400, 200, 50 };
        public static readonly int[] TitleTextReload = new int[] { 210, 410, 180, 30 };
        // help/credits component
        public static readonly int[] InfoFrame = new int[] { 0, 0, 600, 400 };
        public static readonly int[] InfoText = new int[] { 10, 10, 580, 340 };
        public static readonly int[] UpButton = new int[] { 550, 375, 50, 25 };
        public static readonly int[] UpText = new int[] { 560, 375, 30, 25 };
        public static readonly int[] DownButton = new int[] { 500, 375, 50, 25 };
        public static readonly int[] DownText = new int[] { 510, 375, 30, 25 };
        // story component
        public static readonly int[] SpeakerFrame = new int[] { 10, 410, 75, 25 };
        public static readonly int[] StoryFrame = new int[] { 0, 400, 600, 200 };
        public static readonly int[] TextFrame = new int[] { 10, 435, 580, 155 };
        // choice component
        public static readonly int[] ChoiceFrame = new int[] { 0, 400, 600, 200 };
        public static readonly int[] ChoiceBox1 = new int[] { 0, 400, 600, 60 };
        public static readonly int[] ChoiceTextFrame1 = new int[] { 10, 410, 580, 40 };
        public static readonly int[] ChoiceBox2 = new int[] { 0, 470, 600, 60 };
        public static readonly int[] ChoiceTextFrame2 = new int[] { 10, 480, 580, 40 };
        public static readonly int[] ChoiceBox3 = new int[] { 0, 540, 600, 60 };
        public static readonly int[] ChoiceTextFrame3 = new int[] { 10, 550, 580, 40 };
        // navigation component
        public static readonly int[] NavigationBar = new int[] { 600, 0, 200, 600 };
        public static readonly int[] NavigationTitle = new int[] { 600, 0, 200, 100 };
        public static readonly int[] NavigationTextTitle = new int[] { 610, 10, 180, 180 };
        public static readonly int[] NavigationReading = new int[] { 600, 150, 200, 100 };
        public static readonly int[] NavigationTextReading = new int[] { 610, 160, 180, 180 };
        public static readonly int[] NavigationSetting = new int[] { 600, 300, 200, 100 };
        public static readonly int[] NavigationTextSetting = new int[] { 610, 310, 180, 180 };
        // personality component
        public static readonly int[] EditingFrame = new int[] { 50, 50, 350, 500 };
        public static readonly int[] EditingTitle = new int[] { 70, 70, 300, 30 };
        public static readonly int[] EditingTitle1 = new int[] { 70, 120, 300, 30 };
        public static readonly int[] ToggleButton1 = new int[] { 125, 125, 200, 50 };
        public static readonly int[] ToggleButton2 = new int[] { 125, 225, 200, 50 };
        public static readonly int[] ToggleButton3 = new int[] { 125, 325, 200, 50 };
        public static readonly int[] ToggleButton4 = new int[] { 125, 425, 200, 50 };
        // reset component
        public static readonly int[] ResetFrame = new int[] { 400, 50, 350, 500 };
        // reload component
    }
}