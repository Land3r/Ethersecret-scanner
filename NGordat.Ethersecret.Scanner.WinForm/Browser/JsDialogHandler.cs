using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace NGordat.Ethersecret.Scanner.WinForm.Browser
{
    /// <summary>
    /// Handler for Javascript dialogs.
    /// </summary>
    class JsDialogHandler : IJsDialogHandler
    {
        public void OnDialogClosed(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnJSBeforeUnload(IWebBrowser browserControl, IBrowser browser, string message, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }

        public bool OnJSDialog(IWebBrowser browserControl, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            callback.Continue(true);
            return true;
        }

        public void OnResetDialogState(IWebBrowser browserControl, IBrowser browser)
        {
        }
    }
}