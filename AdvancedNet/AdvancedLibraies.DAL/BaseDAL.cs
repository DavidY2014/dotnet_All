using System;
using System.Collections.Generic;
using AdvancedLibraies.IDAL;
using AdvancedLibraies.Model;

namespace AdvancedLibraies.DAL
{
    public class BaseDAL : IBaseDAL
    {
        public bool Add<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public bool Delete<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll<T>() where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }
    }
}
