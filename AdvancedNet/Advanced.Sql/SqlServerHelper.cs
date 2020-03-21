using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Advanced.Sql
{
    public class SqlServerHelper
    {
        private static string ConnectionStr = ConfigurationManager.
            ConnectionStrings[""].ConnectionString;

        public SqlServerHelper()
        {

        }

        public void Query()
        { 
        
        }

        /// <summary>
        /// 泛型查找
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id)
        {
            Type type = typeof(T);
            var sql = $"SELECT {string.Join(",", type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM " +
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
                        prop.SetValue(oObject, reader[prop.Name]  is DBNull? null:reader[prop.Name]);
                     
                    }
                    return (T)oObject;
                }
                else
                {
                    return default(T);
                }
            }
     
        }


    }
}
