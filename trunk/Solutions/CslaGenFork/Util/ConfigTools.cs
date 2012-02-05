using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace CslaGenerator.Util
{

    /// <summary>
    /// Methods for manipulating the key/value pair settings in the app.config file 
    /// (rather the executable.exe.config file).
    /// </summary>
    public static class ConfigTools
    {
        private static string SharedAppConfig
        {
            get
            {
                return Application.CommonAppDataPath.Substring(0, Application.CommonAppDataPath.LastIndexOf("\\"))
                       + @"\SharedApp.config";
            }
        }

        /// <summary>
        /// Reads the value of a key
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns>The value of the supplied key</returns>
        public static string OriginalGet(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var response = string.Empty;
            try
            {
                response = config.AppSettings.Settings[key].Value;
            }
            catch (System.NullReferenceException)
            {

            }
            return response;
        }

        /// <summary>
        /// Reads the value of a key
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns>The value of the supplied key</returns>
        public static string Get(string key)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = SharedAppConfig
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            var response = string.Empty;
            try
            {
                response = config.AppSettings.Settings[key].Value;
            }
            catch (System.NullReferenceException)
            {
            }

            return response;
        }

        /// <summary>
        /// Reads the value of all MRU keys
        /// </summary>
        /// <returns>The value of all MRU keys</returns>
        public static List<string> GetMru()
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = SharedAppConfig
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            var response = new List<string>();
            for (var i = 0; i < 9; i++)
            {
                try
                {
                    response.Add(config.AppSettings.Settings["MruItem" + i].Value);
                }
                catch (System.NullReferenceException)
                {
                }
            }

            return response;
        }

        /// <summary>
        /// Adds a new key and set its value, or add the given
        /// value to an existing key (values are comma separated)
        /// </summary>
        /// <param name="key">The key name to be added</param>
        /// <param name="value">The value for the added key</param>
        public static void Add(string key, string value)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = SharedAppConfig
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Removes a key
        /// </summary>
        /// <param name="key">The key name to be removed</param>
        public static void Remove(string key)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = SharedAppConfig
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Removes a key, adds the same key and sets its value
        /// </summary>
        /// <param name="key">The key name of the value to be changed</param>
        /// <param name="value">The new value</param>
        public static void Change(string key, string value)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = SharedAppConfig
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Removes all MRU key, adds all MRU and sets their value
        /// </summary>
        /// <param name="value">The new value</param>
        public static void ChangeMru(List<string> value)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = SharedAppConfig
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            for (var i = 0; i < 9; i++)
            {
                try
                {
                    config.AppSettings.Settings.Remove("MruItem" + i);
                }
                catch (System.NullReferenceException)
                {
                }
            }

            for (var i = 0; i < 9; i++)
            {
                if (i < value.Count)
                {
                    try
                    {
                        config.AppSettings.Settings.Add("MruItem" + i, value[i]);
                    }
                    catch (System.NullReferenceException)
                    {
                    }
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}