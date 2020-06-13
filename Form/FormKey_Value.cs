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
    class FormKeyValue : IForm
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
                    throw new ArgumentException($"\"{name}\" cannot be bool");
                }    
                
            }
            throw new ArgumentException($"\"{name}\" is not in this Form");
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
                    throw new ArgumentException($"\"{name}\" is not numeric");
                }
            }
            throw new ArgumentException($"\"{name}\" is not in this Form");
        }

        public string GetTextValue(string name)
        {
            if (Request.TryGetValue(name, out string value))
            {
                return value;
            }
            throw new ArgumentException($"\"{name}\" is not in this Form"); 
        }

        public void Insert(string command)
        {
            int eqIndex = command.IndexOf('=');
            if (eqIndex < 0)
            {
                throw new ArgumentException($"Invalid command:\n \"{command}\"");
            }
            string name = command.Substring(0, eqIndex);
            string value = command.Substring(eqIndex + 1, command.Length - eqIndex - 1);
            if (Request.ContainsKey(name))
            {
                Request[name] = value;
            }
            else
            {
                Request.Add(name, value);
            }
            

        }
    }
}
