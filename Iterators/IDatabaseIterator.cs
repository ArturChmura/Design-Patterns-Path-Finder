//  Potwierdzam samodzielność powyższej pracy oraz niekorzystanie przeze mnie z niedozwolonych źródeł
//  Artur Chmura

using ProjOb_lab7.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjOb_lab7.Iterators
{
    public interface IDatabaseIterator<T>
    {
        bool HasNext();
        T GetCurrent();
    }
}
