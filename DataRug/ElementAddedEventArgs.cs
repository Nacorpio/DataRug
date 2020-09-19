using System;

namespace DataRug
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