using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Text.Json;
using System.Configuration;

namespace winforms_chat.Utilities
{

    public class Config<TConfig> where TConfig : new()
    {
        private static volatile Config<TConfig> _instance;
        private static readonly object InstanceLock = new object();
        private ConfigurationSerializer<TConfig> _configurationSerializer;
        private TConfig _configuration;
        private string _fileName;

        public static Config<TConfig> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (_instance == null) _instance = new Config<TConfig>();
                    }
                }

                return _instance;
            }
        }

        public static TConfig Params
        {
            get
            {
                return Instance.ConfigParameters;
            }
        }
        public static void Save()
        {
            Instance.SaveConfig();
        }

        public static void Load()
        {
            Instance.LoadConfig();
        }

        public static void Load(string fileName)
        {
            Filename = fileName;
            Instance.LoadConfig();
        }

        public static string Filename
        {
            get { return Instance.GetFileName(); }
            set { Instance.SetFileName(value); }
        }

        private TConfig ConfigParameters
        {
            get
            {
                DefaultInitialization();
                return _configuration;
            }
            set { _configuration = value; }
        }


        private string GetFileName()
        {
            return _fileName;
        }

        private void SetFileName(string fileName)
        {
            _configuration = new TConfig();
            _fileName = fileName; // use as filename, even if it doesn't exist. Will be created anyway
            _configurationSerializer = new ConfigurationSerializer<TConfig>(fileName, _configuration);
            _configuration = _configurationSerializer.Deserialize();
        }

        private void DefaultInitialization()
        {
            if (!string.IsNullOrWhiteSpace(_fileName)) return;

            // string appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
            _fileName = $"configuration.json";
            _configuration = new TConfig();
            _configurationSerializer = new ConfigurationSerializer<TConfig>(_fileName, _configuration);
            _configuration = _configurationSerializer.Deserialize();
        }

        public void SaveConfig()
        {
            DefaultInitialization();
            _configurationSerializer.Serialize(_configuration);
        }

        public void LoadConfig()
        {
            DefaultInitialization();
            _configuration = _configurationSerializer.Deserialize();
        }
    }

    public class ConfigurationSerializer<TConfig> where TConfig : new()
    {
        private readonly JsonSerializerOptions _options;
        private readonly string _fileName;

        public ConfigurationSerializer(string fileName, TConfig configuration)
        {
            _fileName = fileName;
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };


            if (!File.Exists(_fileName))
            {
                Serialize(configuration);
            }
        }
        public ConfigurationSerializer(string fileName)
        {
            _fileName = fileName;
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
        }


        public void Serialize(TConfig configuration)
        {
            // Save way to serialize, with backup
            try
            {
                //if(!FileUtils.CreateDirectoryForFile(_fileName)) return; 
                if (configuration == null) return;
                var tempFileName = Path.GetTempFileName();
                using (FileStream createStream = File.Create(tempFileName))
                {
                    JsonSerializer.Serialize(createStream, configuration, configuration.GetType(), _options);
                }
                var fileNameOld = _fileName + ".bck";
                if (File.Exists(fileNameOld)) File.Delete(fileNameOld);
                if (File.Exists(_fileName)) File.Move(_fileName, fileNameOld);
                File.Move(tempFileName, _fileName);
                File.Delete(fileNameOld);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Serialization of " + _fileName + " failed on " + exception.Message);
            }
        }


        public TConfig Deserialize()
        {
            if (!File.Exists(_fileName)) return new TConfig();
            try
            {
                using FileStream openStream = File.OpenRead(_fileName);
                return JsonSerializer.Deserialize<TConfig>(openStream);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Deserialization of " + _fileName + " failed on " + exception.Message);

                return new TConfig();
            }
        }


    }
}
