using System.Collections;

namespace GenericDemo
{
    internal class MyCollection<T> : IOperations<T>, IEnumerable<T>
    {
        T[] items;
        int index;
        public MyCollection()
        {
            items = new T[4];
        }
        public void Add(T x)
        {
            if (index == items.Length)
            {
                T[] temp = new T[items.Length * 2];
                items.CopyTo(temp, 0);
                items = temp;
            }

            items[index] = x;
            index++;
        }

        public IEnumerator<T> GetEnumerator()
        {            
            for (int i = 0; i < index; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int i]
        {
            get
            {
                if (i < 0 || i >= index)
                    throw new IndexOutOfRangeException();
                return items[i];
            }
            set
            {
                if (i < 0 || i >= index)
                    throw new IndexOutOfRangeException();
                items[i] = value;
            }
        }
        public int Count => index;
        public int Capacity => items.Length;
    }
}
