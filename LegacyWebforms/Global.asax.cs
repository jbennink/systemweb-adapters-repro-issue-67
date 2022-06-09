using Microsoft.AspNetCore.SystemWebAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LegacyWebforms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application.AddSystemWebAdapters()
           .AddProxySupport(options => options.UseForwardedHeaders = true)
           .AddRemoteAppSession(
               options => options.ApiKey = "dummy-key",
               options =>
               {
//                   options.KnownKeys.Add("SomeValueFromSession", typeof(string));
                   options.RegisterKey<string>("SomeValueFromSession");
                    //options.RegisterKey<string>("License");
               });

        }

    }
}