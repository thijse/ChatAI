using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms_chat.Model;
using winforms_chat.Utilities;
using winforms_chat.ViewModels;

namespace winforms_chat
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
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            _chatMainForm = new ChatMainForm();
            _chatAIVm     = new ChatAIViewModel(_chatMainForm);
            Application.Run(_chatMainForm);
        }
	}
}
