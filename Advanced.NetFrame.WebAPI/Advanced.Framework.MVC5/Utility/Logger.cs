using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;

namespace Advanced.Framework.MVC5.Utility
{
    public class Logger
    {
        static Logger() 
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine
                (AppDomain.CurrentDomain.BaseDirectory, "CfgFiles\\log4net.cfg.xml")));
            ILog log = LogManager.GetLogger(typeof(Logger));
            log.Info("系统初始化Logger模块");
        }

        private ILog logger = null;

        public Logger(Type type) 
        {
            logger = LogManager.GetLogger(type);
        }

        public void Error(string msg="出现异常", Exception ex= null) {
            Console.WriteLine(msg);
            logger.Error(msg, ex);
        }



    }
}