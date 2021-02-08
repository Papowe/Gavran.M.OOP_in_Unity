using System.IO;
using System.Xml;
using UnityEngine;

namespace GavranGame
{
    public sealed class XMLData : IData<SavedData>
    {
        public void Save(SavedData player, string path = null)
        {
            var xmlDocument = new XmlDocument();

            XmlNode rootNode = xmlDocument.CreateElement("Player");
            xmlDocument.AppendChild(rootNode);

            var element = xmlDocument.CreateElement("Name");
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);
            
            element = xmlDocument.CreateElement("PosX");
            element.SetAttribute("value", player.Position.X.ToString());
            rootNode.AppendChild(element);
            
            element = xmlDocument.CreateElement("PosY");
            element.SetAttribute("value", player.Position.Y.ToString());
            rootNode.AppendChild(element);
            
            element = xmlDocument.CreateElement("PosZ");
            element.SetAttribute("value", player.Position.Z.ToString());
            rootNode.AppendChild(element);
            
            element = xmlDocument.CreateElement("IsEnable");
            element.SetAttribute("value", player.IsEnable.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDocument.CreateElement("Info");
            var atribute = xmlDocument.CreateAttribute("Unity");
            atribute.Value = Application.unityVersion;
            userNode.Attributes.Append(atribute);
            userNode.InnerText = $"System Language: {Application.systemLanguage}";
            rootNode.AppendChild(userNode);
            
            xmlDocument.Save(path);
        }

        public SavedData Load(string path = null)
        {
            var result = new SavedData();

            if (!File.Exists(path)) return result;

            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Name";
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                    }
                    key = "PosX";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.X = reader.GetAttribute("value").TrySingle();
                    }
                    key = "PosY";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Y = reader.GetAttribute("value").TrySingle();
                    }
                    key = "PosZ";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Z = reader.GetAttribute("value").TrySingle();
                    }
                    key = "IsEnable";
                    if (reader.IsStartElement(key))
                    {
                        result.IsEnable = reader.GetAttribute("value").TryBool();
                    }
                }
            }
            return result;
        }
    }
}