using System;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CslaGenerator.Util.PropertyBags
{
    /// <summary>
    /// PropertyContext loads an xml file that contains the mappings
    /// that indicate whether or not to show a property in the 
    /// propertygrid for a particular csla object type
    /// cslaobject type + property --> true | false
    /// </summary>
    public class PropertyContext
    {
        private readonly Hashtable _hashTable;

        public PropertyContext()
        {
            /*string[] setting = (string[]) ConfigurationManager.AppSettings.GetValues("PropertyContextFile");
            string xmlFile = setting.Length > 0 ? setting[0] : "" ;*/

            var xmlFile = ConfigurationManager.AppSettings.Get("PropertyContextFile");

            if (string.IsNullOrWhiteSpace(xmlFile))
            {
                xmlFile = "PropertyContext.xml";
                MessageBox.Show(@"Error in ""appSettings"" section of ""CslaGenerator.exe.config"" file." + Environment.NewLine +
                                @"The key ""PropertyContextFile"" is empty or missing." + Environment.NewLine +
                                @"Will use default of """ + xmlFile + @""".",
                                @"CslaGenFork initialization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (File.Exists(xmlFile))
            {
                _hashTable = ParseXML(xmlFile);
            }
        }

        // mappings are loaded into a hash table 
        // for quick retrieval
        public Hashtable HashTable
        {
            get { return _hashTable; }
        }

        // read xml file and strip off attributes
        // note: assumes only key --> value nodes
        // have attributes
        private Hashtable ParseXML(string xmlFile) 
        {
            var attributes = new Hashtable();
            try 
            {
                var reader = new XmlTextReader(xmlFile);
                var key = "";
                var value = "";
                while (reader.Read()) 
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.HasAttributes)
                    {

                        for (int i = 0; i < reader.AttributeCount; i++) 
                        {
                            if (reader.Value == "NameValueList:ObjectType") 
                            {
                                Debug.WriteLine("abcdef");
                            }
                            reader.MoveToFirstAttribute();
                            key = reader.Value;
                            reader.MoveToNextAttribute();
                            value = reader.Value;
                        }
                        attributes.Add(key, value);
                        if (value.Length == 0)
                            Debug.WriteLine("zero");
                    }
                }
                return attributes;
            }
            catch //(XmlException e) 
            {
                return attributes;
            }
        }
        // should "cslaobject:property" be shown in propertygrid?
        public bool ShowProperty(string cslaobjectType, string property)
        {
            var key = cslaobjectType + ":" + property;
            if (_hashTable.ContainsKey(key))
            {
                // return hashTable[key] == "true" ? true : false;
                if (_hashTable[key].Equals("true"))
                {
                    // show property
                    return true;
                }
                
                if (_hashTable[key].Equals("false"))
                {
                    // don't show property
                    return false;
                }
                
                // by default show property
                return true;
            }
            
            // by default show property
            // Console.WriteLine(key);
            return true;
        }
    }
}
