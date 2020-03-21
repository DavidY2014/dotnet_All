using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using AdvancedLibraies.IDAL;
using AdvancedLibraies.Model;

namespace AdvancedLibraies.DAL
{
    public class BaseDAL : IBaseDAL
    {
        private static string ConnectionStr = ConfigurationManager.
    ConnectionStrings[""].ConnectionString;
        public bool Add<T>(T t) where T : BaseModel
        {
            Type type = t.GetType();
            string columnString = string.Join(",", type.GetProperties(
                BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                .Select(p => $"[{p.Name}]"));

            string valueColumn = string.Join(",", type.GetProperties(
                BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => $"[{p.Name}]"));

            var parameterList = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => new SqlParameter($"@{p.Name}", p.GetValue(t) ?? DBNull.Value));


            string sql = $"Insert into [{type.Name}] ({columnString}) values({valueColumn})";
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(parameterList.ToArray());
                conn.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool Delete<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }

        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            var sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} FROM " +
                $"[{type.Name}] WHERE Id= {id}";
            object oObject = Activator.CreateInstance(type);
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        //如果为空类型，数据库存储为null时，赋值会报错
                        prop.SetValue(oObject, reader[prop.Name] is DBNull ? null : reader[prop.Name]);

                    }
                    return (T)oObject;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public List<T> FindAll<T>() where T : BaseModel
        {
            Type type = typeof(T);
            var sql = $"SELECT {string.Join(",", type.GetProperties().Select(p => $"[{p.Name}]"))} FROM " +
                $"[{type.Name}]";
           
            using (SqlConnection conn = new SqlConnection(ConnectionStr))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                var reader = command.ExecuteReader();
                List<T> tList = new List<T>();
                while (reader.Read())
                {
                    object oObject = Activator.CreateInstance(type);
                    foreach (var prop in type.GetProperties())
                    {
                        //如果为空类型，数据库存储为null时，赋值会报错
                        prop.SetValue(oObject, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                    tList.Add((T)oObject);
                }
                return tList;
            }
        }

        public bool Update<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }
    }
}
