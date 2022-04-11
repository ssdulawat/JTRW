using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JobTracker.ConnectionStringSetting
{
    public class ConnectionStringsSetting
    {
        private static void SaveConnectionString(string value,int index)
        {
            System.Xml.XmlDocument LocalString = new System.Xml.XmlDocument();
            LocalString.Load(cGlobal.ConnectionStringFilePath);
            XmlNode ConnectionString = LocalString.SelectSingleNode("/JT/ConnectionString");
            ConnectionString.ChildNodes[index].InnerText = value;
            LocalString.Save(cGlobal.ConnectionStringFilePath);
        }
        
        private static XmlNode GetConnectionString()
        {
            System.Xml.XmlDocument LocalString = new System.Xml.XmlDocument();
            LocalString.Load(cGlobal.ConnectionStringFilePath);
            return LocalString.SelectSingleNode("/JT/ConnectionString");
        }

        public static string LocalConnectionString
        {
            get
            {
                XmlNode ConnectionString = GetConnectionString();
                return ConnectionString.ChildNodes[1].InnerText;
            }
            set
            {
                SaveConnectionString(value,1);
            }
        }
        
        public static bool IsLocalDatabase
        {
            get
            {
                XmlNode ConnectionString = GetConnectionString();
                return Convert.ToBoolean(ConnectionString.ChildNodes[0].InnerText.Trim());
            }
            set
            {
                SaveConnectionString(value.ToString(), 0);
            }
        }
    }
}
