using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced.DatastructAndAlgorim.线性表
{
    public interface IDynamicList<T>
    {
        int Size();
        bool IsEmpty();
        bool Contains(T e);
        void Add(T e);
        T Get(int index);
        T Set(int index);
        void Add(int index, T e);
        T Remove(int index);
        int IndexOf(T e);
        void Clear();

    }
}
