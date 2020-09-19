using System;

using DataRug.API.Common;
using DataRug.API.Common.Collections;

namespace DataRug.Common
{

    public class ElementAddedEventArgs<T> : EventArgs where T : class, IUnique
    {
        public ElementAddedEventArgs(IUniqueMap<T> map, T element)
        {
            Map = map;
            Element = element;
        }

        public IUniqueMap<T> Map { get; }
        public T Element { get; }
    }

}