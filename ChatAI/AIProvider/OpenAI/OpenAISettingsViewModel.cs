using System.Diagnostics;
using System.Threading.Tasks;
using ChatAI.Model;
using ChatAI.Utilities;

namespace ChatAI.AIProvider.OpenAI
{
    

    public class OpenAISettingsViewModel
    {
        private OpenAISettingsUserComponent _openAISettingsUc;
        private OpenAIViewModel             _openAIViewModel;

        public OpenAISettingsViewModel(OpenAISettingsUserComponent openAISettingsUserComponent, OpenAIViewModel openAIViewModel)
        {
            _openAISettingsUc = openAISettingsUserComponent;
            _openAIViewModel  = openAIViewModel;
            _openAISettingsUc.comboBoxBaseUrl.Leave += async (s,e) =>
            {
                Config<AppConfig>.Params.BaseUrl = _openAISettingsUc.comboBoxBaseUrl.Text;
                _openAIViewModel.LoadOpenAIService();
                //todo reload OpenAI model
                await GetModels();
            };
            
        }
        public void SetData()
        {
            Config<AppConfig>.Params.OpenAIKey = _openAISettingsUc.textBoxOpenAiKey.Text;
            Config<AppConfig>.Params.BaseUrl   = _openAISettingsUc.comboBoxBaseUrl.Text;
            Config<AppConfig>.Params.Model     = _openAISettingsUc.comboBoxOpenAiModel.Text;
            _openAIViewModel.LoadOpenAIService();
        }
        public async Task GetDataAsync()
        {
            _openAISettingsUc.textBoxOpenAiKey.Text    = Config<AppConfig>.Params.OpenAIKey;
            _openAISettingsUc.comboBoxBaseUrl.Text     = Config<AppConfig>.Params.BaseUrl;
            _openAIViewModel.LoadOpenAIService();
            await GetModels();
            _openAISettingsUc.comboBoxOpenAiModel.Text = Config<AppConfig>.Params.Model;
        }

        public async Task GetModels()
        {
            _openAISettingsUc.comboBoxOpenAiModel.Items.Clear();
            try
            {
                var models = await _openAIViewModel.GetModels();
                foreach (var model in models)
                {
                    _openAISettingsUc.comboBoxOpenAiModel.Items.Add(model);
                }
            }
            catch (System.Exception){
                Debug.WriteLine("OpenAISettingsViewModel.GetModels() failed");
            }

        }
    }
}


