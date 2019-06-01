using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            if (key != null)
            {
                int nx = 0;
                char[] chs = key.ToCharArray();
                for (int i = 0; i < chs.Length; i++)
                    nx += Convert.ToInt32(chs[i]);
                return (55 * nx + 3) % 95 % size;
            }
            return 0;
        }

        public bool IsKey(string key)
        {
            if (key != null)
            {
                int nx = HashFun(key);
                for (int i = 0; i < size; i++)
                {
                    if (slots[nx] == key) return true;
                    nx++;
                    if (nx <= size) nx = 0;
                }
            }
            return false;
        }

        public void Put(string key, T value)
        {
            if (!IsKey(key) && key != null && value != null)
            {
                int nx = HashFun(key);
                for (int i = 0; i < size; i++)
                {
                    if (slots[nx] == null)
                    {
                        slots[nx] = key;
                        values[nx] = value;
                        break;
                    }
                    nx++;
                    if (nx >= size) nx = 0;
                }
            }
        }

        public T Get(string key)
        {
            int nx = HashFun(key);
            for (int i = 0; i < size; i++)
            {
                if (slots[nx] == key) return values[nx];
                nx++;
                if (nx >= size) nx = 0;
            }
            return default(T);
        }
    }
}