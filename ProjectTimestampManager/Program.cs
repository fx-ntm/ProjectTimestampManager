namespace ProjectTimestampManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLitePCL.Batteries.Init();
            ApplicationConfiguration.Initialize();
            Application.Run(new ProjectSelectionForm());
        }
    }
}