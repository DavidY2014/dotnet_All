using System;
using System.Collections.Generic;
using AdvancedLibraies.Model;

namespace AdvancedLibraies.IDAL
{
    public interface IBaseDAL
    {
        bool Add<T>(T t) where T : BaseModel;
        bool Delete<T>(T t) where T : BaseModel;

        List<T> FindAll<T>() where T : BaseModel;

        T Find<T>(int id) where T : BaseModel;

        bool Update<T>(T t) where T : BaseModel;
    }
}
