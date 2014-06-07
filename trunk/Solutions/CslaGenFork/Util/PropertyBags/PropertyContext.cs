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
        private Hashtable hashTable;

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
                hashTable = ParseXML(xmlFile);
            }
        }

        // mappings are loaded into a hash table 
        // for quick retrieval
        public Hashtable HashTable
        {
            get { return hashTable; }
        }
//		// the xml file that contains the mappings
//		// cslaobject type + property --> true | false
//		public string XmlFile
//		{
//			get { return xmlFile; }
//			set { xmlFile = value; }
//		}
        // read xml file and strip off attributes
        // note: assumes only key --> value nodes
        // have attributes
        private Hashtable ParseXML(string xmlFile) 
        {
            Hashtable attributes = new Hashtable();
            try 
            {
                XmlTextReader reader = new XmlTextReader(xmlFile);
                string _key = "";
                string _value = "";
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
                            _key = reader.Value;
                            reader.MoveToNextAttribute();
                            _value = reader.Value;

                            //reader.MoveToAttribute(i);
//							switch (reader.Name)
//							{
//								case "key":
//									_key = reader.Value;
//									break;
//								case "value":
//									_value = reader.Value;
//									break;
//							}
                        }
                        attributes.Add(_key, _value);
                        if (_value.Length == 0)
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
            string key = cslaobjectType + ":" + property;
            if (hashTable.ContainsKey(key))
            {
                // return hashTable[key] == "true" ? true : false;
                if (hashTable[key].Equals("true"))
                {
                    // show property
                    return true;
                }
                else if (hashTable[key].Equals("false"))
                {
                    // don't show property
                    return false;
                }
                else 
                {
                    // by default show property
                    return true;
                }
            }
            else
            {
                // by default show property
                // Console.WriteLine(key);
                return true;
            }
        }
    }
}
