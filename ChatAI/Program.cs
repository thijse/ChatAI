using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using winforms_chat.ViewModels;

namespace winforms_chat
{
	static class Program
	{
       
        private static ChatAIViewModel _chatAIVm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main()
		{
            //_chatGPT = new ChatGPT.OpenAIGPTViewModel();

            _chatAIVm = new ChatAIViewModel();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatMainForm(_chatAIVm));
        }
	}
}
