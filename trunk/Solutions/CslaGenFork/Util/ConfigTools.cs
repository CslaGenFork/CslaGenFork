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
        /// <summary>
        /// Reads the value of a key
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns>The value of the supplied key</returns>
        public static string Get(string key)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = Application.CommonAppDataPath + @"\SharedApp.config"
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
        /// Adds a new key and set its value, or add the given
        /// value to an existing key (values are comma separated)
        /// </summary>
        /// <param name="key">The key name to be added</param>
        /// <param name="value">The value for the added key</param>
        public static void Add(string key, string value)
        {
            var configFile = new ExeConfigurationFileMap
                                 {
                                     ExeConfigFilename = Application.CommonAppDataPath + @"\SharedApp.config"
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
                                     ExeConfigFilename = Application.CommonAppDataPath + @"\SharedApp.config"
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
                                     ExeConfigFilename = Application.CommonAppDataPath + @"\SharedApp.config"
                                 };
            var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}