//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using ProjOb_lab7.Form;

namespace ProjOb_lab7.Factories
{
    static class SystemFactory
    {
        static public ISystem GetSystemXML()
        {
            return new MySystem(new FormXML(), new DisplayXML());
        }
        static public ISystem GetSystemKeyValue()
        {
            return new MySystem(new FormKeyValue(), new DisplayKeyValue());
        }
    }
}
