using System;
using System.Collections.Generic;
using System.Text;
using Advanced.DatastructAndAlgorim.线性表;

namespace Advanced.DatastructAndAlgorim.线性表
{
    public class MyList<T> : IDynamicList<T>
    {
        private int size { get; set; }
        private T[] elements;
        private static readonly int DEFAULT_CAPACITY = 10;
        public MyList(int capaticy)
        {
            capaticy = (capaticy < DEFAULT_CAPACITY) ? DEFAULT_CAPACITY : capaticy;
            elements = new T[capaticy];
        }

        public MyList()
        {
            elements = new T[DEFAULT_CAPACITY];
        }
        public void Add(T e)
        {
            throw new NotImplementedException();
        }

        public void Add(int index, T e)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T e)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T e)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public T Remove(int index)
        {
            throw new NotImplementedException();
        }

        public T Set(int index)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
