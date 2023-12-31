﻿using ChatAI.AIProvider.OpenAI;
using ChatAI.View;

namespace ChatAI.ViewModels
{
    public class SettingsViewModel
    {
        private SettingsForm _settingsForm;
        public OpenAISettingsViewModel OpenAISettings { get; set; }

        public SettingsViewModel(SettingsForm settingsForm, OpenAISettingsViewModel openAISettings)
        {
            _settingsForm = settingsForm;
            OpenAISettings = openAISettings;
        }


        // Set data from viewmodel in form
        public void SetData()
        {
            OpenAISettings.SetData();
        }

        // Get data from form and put in viewmodel
        public void GetData()
        {
            OpenAISettings.GetDataAsync();

        }

    }
}
