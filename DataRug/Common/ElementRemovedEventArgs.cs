using System;

using DataRug.API.Common;
using DataRug.API.Common.Collections;

namespace DataRug.Common
{

    public class ElementRemovedEventArgs<T> : EventArgs where T : class, IUnique
    {
        public ElementRemovedEventArgs(IUniqueMap<T> map, T element)
        {
            Map     = map;
            Element = element;
        }

        public IUniqueMap<T> Map { get; }
        public T Element { get; }
    }

}