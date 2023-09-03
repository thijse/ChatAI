using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatAI.Model;
using ChatAI.Utilities;
using ChatAI.ViewModels;

namespace ChatAI
{
	static class Program
	{
        private static ChatMainForm _chatMainForm;
        private static ChatAIViewModel _chatAIVm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main()
		{
            Config<AppConfig>.Load("appsettings.json");

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            _chatMainForm = new ChatMainForm();
            _chatAIVm     = new ChatAIViewModel(_chatMainForm);
            Application.Run(_chatMainForm);
        }
	}
}
