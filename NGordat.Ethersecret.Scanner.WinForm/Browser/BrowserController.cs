using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGordat.Ethersecret.Scanner.WinForm.Browser
{
    public class BrowserController
    {
        /// <summary>
        /// Initializes the CefBrowser.
        /// </summary>
        public static void Init()
        {
            Cef.EnableHighDPISupport();
            CefSharpSettings.ShutdownOnExit = false;

            var settings = new CefSettings();

            // Increase the log severity so CEF outputs detailed information, useful for debugging
            settings.LogSeverity = LogSeverity.Info;
            
            // By default CEF uses an in memory cache, to save cached data e.g. passwords you need to specify a cache path
            // NOTE: The executing user must have sufficient privileges to write to this folder.
            settings.CachePath = "cache";

            Cef.Initialize(settings);
        }

        /// <summary>
        /// Shutdowns the CefBrowser.
        /// </summary>
        public static void Exit()
        {
            Cef.Shutdown();
        }
    }
}
