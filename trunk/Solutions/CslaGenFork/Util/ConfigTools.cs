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
        public static string DefaultXml
        {
            get
            {
                return Application.LocalUserAppDataPath.Substring(0, Application.LocalUserAppDataPath.LastIndexOf("\\"))
                       + @"\Default.xml";
            }
        }

        private static string SharedAppConfig
        {
            get
            {
                return Application.LocalUserAppDataPath.Substring(0, Application.LocalUserAppDataPath.LastIndexOf("\\"))
                       + @"\SharedApp.config";
            }
        }

        /// <summary>
        /// Reads the value of a key in App.config file.
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns>The value of the supplied key</returns>
        internal static string AppConfigGet(string key)
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
        /// Reads the value of a key in SharedApp.config file.
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns>The value of the supplied key</returns>
        internal static string SharedAppConfigGet(string key)
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
        /// Reads the value of all MRU keys from SharedApp.config file.
        /// </summary>
        /// <returns>The value of all MRU keys</returns>
        internal static List<string> SharedAppConfigGetMru()
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
        
        #region unsed Add and Remove methods

        /// <summary>
        /// Adds a new key and set its value, or add the given
        /// value to an existing key (values are comma separated)
        /// to SharedApp.config file.
        /// </summary>
        /// <param name="key">The key name to be added</param>
        /// <param name="value">The value for the added key</param>
        /// <remarks>Unused</remarks>
        internal static void SharedAppConfigAdd(string key, string value)
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
        /// Removes a key in SharedApp.config file.
        /// </summary>
        /// <param name="key">The key name to be removed</param>
        /// <remarks>Unused</remarks>
        internal static void SharedAppConfigRemove(string key)
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
        
        #endregion

        /// <summary>
        /// Removes a key, adds the same key and sets its value in SharedApp.config file.
        /// </summary>
        /// <param name="key">The key name of the value to be changed</param>
        /// <param name="value">The new value</param>
        internal static void SharedAppConfigChange(string key, string value)
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
        /// Removes all MRU key, adds all MRU and sets their value in SharedApp.config file.
        /// </summary>
        /// <param name="value">The new value</param>
        internal static void SharedAppConfigChangeMru(List<string> value)
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