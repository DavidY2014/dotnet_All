using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedNet
{
    /// <summary>
    /// Unity 不依赖细节注册，通过反射+配置文件实现
    /// </summary>
    public class CustomUnity
    {
        public static  void Init()
        {
            //配置Unity
            System.Configuration.ExeConfigurationFileMap fileMap = new System.Configuration.ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "configFiles\\Unity.Config");
            System.Configuration.Configuration configuration   = System.Configuration.ConfigurationManager.
                OpenMappedExeConfiguration(fileMap, System.Configuration.ConfigurationUserLevel.None);
            Microsoft.Practices.Unity.Configuration.UnityConfigurationSection configSection = (Microsoft.Practices.Unity.Configuration.UnityConfigurationSection)configuration.GetSection(Microsoft.Practices.Unity.Configuration.UnityConfigurationSection.SectionName);
           //IUnityContainer container = new Unity.UnityContainer();
        }
    }
}
