//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;
using ProjOb_lab7.Ui;
using System.Linq;
using System.Xml.Linq;
using ProjOb_lab7.Api;

namespace ProjOb_lab7.Form
{
    class FormXML : IForm
    {
        public Dictionary<string, string> Request { get; set; } = new Dictionary<string, string>();

        public bool GetBoolValue(string name)
        {
            if (Request.TryGetValue(name, out string value))
            {
                if (bool.TryParse(value, out bool ret))
                {
                    return ret;
                }
                else
                {
                    throw new ArgumentException("This value cannot be bool");
                }

            }
            throw new ArgumentException("There is not such thing in this Form");
        }

        public int GetNumericValue(string name)
        {
            if (Request.TryGetValue(name, out string value))
            {
                if (int.TryParse(value, out int ret))
                {
                    return ret;
                }
                else
                {
                    throw new ArgumentException("This value in not numeric");
                }
            }
            throw new ArgumentException("There is not such thing in this Form");
        }

        public string GetTextValue(string name)
        {
            if (Request.TryGetValue(name, out string value))
            {
                return value;
            }
            throw new ArgumentException("There is not such thing in this Form");
        }

        public void Insert(string command)
        {
            XDocument xml = XDocument.Parse(command);
            if (Request.ContainsKey(xml.Root.Name.ToString()))
            {
                Request[xml.Root.Name.ToString()] = xml.Root.Value;
            }
            else
            {
                Request.Add(xml.Root.Name.ToString(), xml.Root.Value);
            }
           

        }
    }
}
