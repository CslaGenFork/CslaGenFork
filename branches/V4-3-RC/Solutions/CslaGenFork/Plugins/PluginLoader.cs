using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using CslaGenerator.Controls;
namespace CslaGenerator.Plugins
{
    class PluginLoader
    {
        public static List<ISimplePlugin> LoadPlugins()
        {
            DirectoryInfo pluginDir = new DirectoryInfo(Application.StartupPath + "\\Plugins");
            if (!pluginDir.Exists)
                return null;
            List<ISimplePlugin> lst = new List<ISimplePlugin>();
            foreach (FileInfo file in pluginDir.GetFiles("*.dll"))
            {
                try
                {
                    byte[] assemblyBytes =  File.ReadAllBytes(file.FullName);
                    Assembly pluginAssembly = Assembly.Load(assemblyBytes);
                    foreach (Type pluginType in pluginAssembly.GetExportedTypes())
                    {
                        if (IsPlugin(pluginType))
                        {
                            try
                            {
                                ISimplePlugin plugin = (ISimplePlugin)Activator.CreateInstance(pluginType);
                                lst.Add(plugin);
                            }
                            catch (Exception ex)
                            {
                                OutputWindow.Current.AddOutputInfo("Error creating plugin instance:");
                                OutputWindow.Current.AddOutputInfo(ex.Message);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    OutputWindow.Current.AddOutputInfo("Error loading plugin dll:");
                    OutputWindow.Current.AddOutputInfo(ex.Message);
                }


            }

            return lst;
        }
        static bool IsPlugin(Type type)
        {
            try
            {
                foreach (Type interfaceType in type.GetInterfaces())
                    if (interfaceType.Equals(typeof(ISimplePlugin)))
                        return true;
            }
            catch (Exception)
            {
                return false;                
            }
            return false;
        }
    }
}
