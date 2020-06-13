//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using System;
using System.Collections.Generic;
using System.Text;

namespace ProjOb_lab7.Ui
{
    class MySystem : ISystem
    {
        public IForm Form { get; }

        public IDisplay Display { get; }
        public MySystem(IForm form, IDisplay display) //Tak się nazywa bo "System" to ogólny namespace i się gubił
        {
            this.Form = form;
            this.Display = display;
        }
    }


}
