using System;
using System.Reflection;
using AdvancedLibraies.DAL;
using AdvancedLibraies.IDAL;

namespace AdvancedLibraries.Factory
{
    /// <summary>
    /// 工厂模式访问数据库，通过反射的方法
    /// </summary>
    public class SimpleFactory
    {
        //通过配置文件修改dll
        private static string DllName = "";
        private static string TypeName = "";
        public static IBaseDAL CreateInstance()
        {
            Assembly assembly = Assembly.Load(DllName);
            Type type = assembly.GetType(TypeName);
            return (IBaseDAL)Activator.CreateInstance(type);
        }

    }
}
