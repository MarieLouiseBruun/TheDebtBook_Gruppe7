using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary; 
using TheDebtBook_Gruppe7.Model;
using System.Xml.Serialization;

namespace TheDebtBook_Gruppe7
{
    public class DebitorFileHandler
    {
        public bool FileDoesNotExist { get; set; }
        private FileStream fs;
        private ObservableCollection<Debitor> debitorList;
        private string filename = "debitorList.xml";

        public ObservableCollection<Debitor> ReadFromFile()
        {
            try
            {
                fs = new FileStream(filename, FileMode.Open);
                XmlSerializer deserializer = new XmlSerializer(typeof(ObservableCollection<Debitor>));               
                debitorList = (ObservableCollection<Debitor>)deserializer.Deserialize(fs);
               
            }
            catch (FileNotFoundException e)
            {
                throw e; 
            }

            return debitorList;

        }

        public void CreateFile(ObservableCollection<Debitor> debitorList)
        {
            try
            {
                fs = new FileStream(filename, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Debitor>));
                serializer.Serialize(fs, debitorList);

                fs.Close();
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }

        }
    }
}
