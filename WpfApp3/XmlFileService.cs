using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

namespace WpfApp3
{
    public class XmlFileService : IFileService
    {
        public List<Employees> Open(string filename)
        {
            List<Employees> empList = new List<Employees>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "employee")
                {
                    Employees emp = new Employees();
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                            emp.Name = childnode.InnerText;
                        if (childnode.Name == "age")
                            emp.Age = Convert.ToInt32(childnode.InnerText);
                        if (childnode.Name == "position")
                            emp.Position = (Position)Enum.Parse(typeof(Position), childnode.InnerText, true);
                        if (childnode.Name == "experience")
                            emp.Experience = Convert.ToDouble(childnode.InnerText.Replace('.',','));
                        if (childnode.Name == "retiree")
                            emp.Retiree = Convert.ToBoolean(childnode.InnerText);
                    }
                    empList.Add(emp);
                }
            }
            return empList;
        }

        public void Save(string filename, List<Employees> phonesList)
        {
            XElement doc = new XElement("employees");
            foreach (Employees xnode in phonesList)
                doc.Add(new XElement("employee", new XElement("name", xnode.Name), new XElement("age", xnode.Age), new XElement("position", xnode.Position),
                    new XElement("experience", xnode.Experience), new XElement("retiree", xnode.Retiree)));
            doc.Save(filename);
        }
    }

    public interface IFileService
    {
        List<Employees> Open(string filename);
        void Save(string filename, List<Employees> phonesList);
    }
}
