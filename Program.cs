using System;
using System.Windows.Forms;

namespace SimpleTeamViewer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm()); // Start with MainMenuForm
        }
    }
}
