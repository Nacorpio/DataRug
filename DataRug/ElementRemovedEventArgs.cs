using System;

namespace DataRug
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