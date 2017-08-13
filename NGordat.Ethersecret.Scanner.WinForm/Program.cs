using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGordat.Ethersecret.Scanner.WinForm.Browser;
using CefSharp.WinForms;
using log4net;

namespace NGordat.Ethersecret.Scanner.WinForm
{
    /// <summary>
    /// EtherSecret Scanner Project.
    /// An automated scanner for EtherSecret (www.ethersecret.com) in order to find Ethereum based private keys with a non zero balance.
    /// <see cref="https://github.com/Land3r/Ethersecret-scanner"/> for more details.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger("Program");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log.Info("Application started.");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initializes Cef settings.
            BrowserController.Init();

            var browser = new BrowserForm();
            Application.Run(browser);

            log.Info("Application ended.");
            log.WarnFormat("Pages parsed: {0}, addresses checked: {1}, keys founds: {2}", BrowserCallbackForJs.pages, BrowserCallbackForJs.pages * 25, BrowserCallbackForJs.keyFound);

            BrowserController.Exit();
        }
    }
}
