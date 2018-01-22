using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGordat.Ethersecret.Scanner.WinForm.Browser
{
    /// <summary>
    /// Callback class for Javascript.
    /// Allows to call .NET methods from JS stack.
    /// </summary>
    public class BrowserCallbackForJs
    {
        /// <summary>
        /// The parent caller.
        /// </summary>
        private BrowserForm caller;

        /// <summary>
        /// The number of pages parsed.
        /// </summary>
        public static int pages = 0;

        /// <summary>
        /// The number of keys found.
        /// </summary>
        public static int keyFound = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowserCallbackJs"/> class.
        /// </summary>
        /// <param name="caller">The parent caller.</param>
        public BrowserCallbackForJs(BrowserForm caller)
        {
            this.caller = caller;
        }

        /// <summary>
        /// Youpi! You found an ethereum account with some ethers.
        /// </summary>
        /// <param name="privateKey">The raw private key.</param>
        /// <param name="publicKey">The raw publib key.</param>
        /// <param name="amount">The amount of ether found.</param>
        public void foundKey(string url, string privateKey, string publicKey, string amout)
        {
            keyFound++;
            ILog log = LogManager.GetLogger("_____KEYFOUND_____");
            log.FatalFormat("A non empty account was found on page {0}", url);
            log.FatalFormat("A non empty account was found. PrivateKey:'{0}', PublicKey:'{1}', Amount:'{2}'", privateKey, publicKey, amout);

            // Spawning new thread for MessageBox in order not to block parsing thread.
            Thread t = new Thread(() => MessageBox.Show("A non empty account was found !",
                "KEY FOUND",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information));
            t.Start();
        }
           

        /// <summary>
        /// Logs a message to a file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void logMessage(string message)
        {
            ILog log = LogManager.GetLogger("Browser");
            log.Info(message);
        }

        /// <summary>
        /// Change the page to have new data.
        /// </summary>
        public void callNextPage()
        {
            caller.GoToNextPage();
            pages++;
        }
    }
}
