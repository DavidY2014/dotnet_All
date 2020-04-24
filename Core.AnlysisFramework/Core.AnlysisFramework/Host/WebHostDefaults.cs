using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AnlysisFramework.Host
{
    //定义了一些常量名
    public class WebHostDefaults
    {
        public static readonly string ApplicationKey = "applicationName";
        public static readonly string StartupAssemblyKey = "startupAssembly";
        public static readonly string HostingStartupAssembliesKey = "hostingStartupAssemblies";
        public static readonly string HostingStartupExcludeAssembliesKey = "hostingStartupExcludeAssemblies";

        public static readonly string DetailedErrorsKey = "detailedErrors";
        public static readonly string EnvironmentKey = "environment";
        public static readonly string WebRootKey = "webroot";
        public static readonly string CaptureStartupErrorsKey = "captureStartupErrors";
        public static readonly string ServerUrlsKey = "urls";
        public static readonly string ContentRootKey = "contentRoot";
        public static readonly string PreferHostingUrlsKey = "preferHostingUrls";
        public static readonly string PreventHostingStartupKey = "preventHostingStartup";
        public static readonly string SuppressStatusMessagesKey = "suppressStatusMessages";

        public static readonly string ShutdownTimeoutKey = "shutdownTimeoutSeconds";
        public static readonly string StaticWebAssetsKey = "staticWebAssets";
    }
}
