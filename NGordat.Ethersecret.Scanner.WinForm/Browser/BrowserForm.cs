using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGordat.Ethersecret.Scanner.WinForm.Controls;
using System.Configuration;
using NGordat.Ethersecret.Scanner.WinForm.Components;
using System.IO;
using System.Diagnostics;

namespace NGordat.Ethersecret.Scanner.WinForm.Browser
{
    public partial class BrowserForm : Form
    {
        /// <summary>
        /// Chromium browser control.
        /// </summary>
        private readonly ChromiumWebBrowser browser;

        /// <summary>
        /// EtherSecret base domain.
        /// </summary>
        private readonly string ethersecret_base = ConfigurationManager.AppSettings["ethersecret_url"].ToString().Substring(0, 26);

        /// <summary>
        /// Initializes a new instance of <see cref="BrowserForm"/> class.
        /// </summary>
        public BrowserForm()
        {
            InitializeComponent();

            Text = "CefSharp";
            WindowState = FormWindowState.Maximized;

            browser = new ChromiumWebBrowser("about:blank")
            {
                Dock = DockStyle.Fill,
            };
            // Register BrowserCallbackForJs class as javascript callback.
            browser.RegisterJsObject("dotnetcallback", new BrowserCallbackForJs(this));

            toolStripContainer.ContentPanel.Controls.Add(browser);

            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;

            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var version = String.Format("EtherSecret Scanner {3} loaded. Using chromium {0}, cef {1} and cefsharp {2} {3}.", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
            DisplayOutput(version);
        }

        #region Browser

        /// <summary>
        /// Event handler for incoming javascript console messages.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        /// <summary>
        /// Event handler for incoming http messages.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }

        /// <summary>
        /// Event handler for browser loaded changes.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            if (!args.IsLoading && args.Browser.MainFrame.Url.StartsWith(ethersecret_base))
            {
                string script;
                string styles;
                using(TextReader tr = new StreamReader(@"Scripts/Payload.js"))
	            {
                    script = tr.ReadToEnd();
	            }
                using (TextReader tr = new StreamReader(@"Scripts/StylesInjector.js"))
                {
                    styles = tr.ReadToEnd();
                }

                browser.ExecuteScriptAsync(styles);
                browser.ExecuteScriptAsync(script);
            }

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }

        /// <summary>
        /// Event handler for browser webpage title change.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = string.Format("EtherSecret Scanner : {0} addresses parsed. {1} ", BrowserCallbackForJs.pages * 25 , args.Title));
        }

        /// <summary>
        /// Event handler for browser webpage address change.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => urlTextBox.Text = args.Address);
        }

        /// <summary>
        /// Enables or Disables the 'Go back' button.
        /// </summary>
        /// <param name="canGoBack">If true, button is enabled.</param>
        private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => backButton.Enabled = canGoBack);
        }

        /// <summary>
        /// Enables or Disables the 'Go forward' button.
        /// </summary>
        /// <param name="canGoBack">If true, button is enabled.</param>
        private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => forwardButton.Enabled = canGoForward);
        }

        /// <summary>
        /// Enables or Disables the 'Status' indicator.
        /// </summary>
        /// <param name="canGoBack">If true, indicator is red.</param>
        private void SetIsLoading(bool isLoading)
        {
            goButton.Text = isLoading ? "Stop" : "Go";
            goButton.Image = isLoading ? Properties.Resources.nav_plain_red : Properties.Resources.nav_plain_green;

            HandleToolStripLayout();
        }

        /// <summary>
        /// Sets the output message of the console.
        /// </summary>
        /// <param name="output">The output message.</param>
        public void DisplayOutput(string output)
        {
            this.InvokeOnUiThreadIfRequired(() => outputLabel.Text = output);
        }

        /// <summary>
        /// Event handler for Resizing the HandleToolStripLayout control.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }

        /// <summary>
        /// Resizes the HandleToolStripLayout control.
        /// </summary>
        private void HandleToolStripLayout()
        {
            var width = toolStrip1.Width;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 18);
        }


        /// <summary>
        /// Event handler for the Go button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void GoButtonClick(object sender, EventArgs e)
        {
            LoadUrl(urlTextBox.Text);
        }

        /// <summary>
        /// Event handler for the Go Back button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void BackButtonClick(object sender, EventArgs e)
        {
            browser.Back();
        }

        /// <summary>
        /// Event handler for the Go Forward button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ForwardButtonClick(object sender, EventArgs e)
        {
            browser.Forward();
        }

        /// <summary>
        /// Event handler for the Url textbox for keystrokes.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void UrlTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            LoadUrl(urlTextBox.Text);
        }

        /// <summary>
        /// Loads an url if valid into the browser.
        /// </summary>
        /// <param name="url">The url of the page to load.</param>
        private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }

        #endregion Browser

        #region Menu

        /// <summary>
        /// Event handler for the Exit button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            browser.Dispose();
            Cef.Shutdown();
            Close();
        }

        /// <summary>
        /// Event handler for the About menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        /// <summary>
        /// Event handler for the Start menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GoToNextPage();
        }

        /// <summary>
        /// Event handler for the Stop menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadUrl("about:blank");
        }

        /// <summary>
        /// Event handler for the Restart menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadUrl("about:blank");
            this.GoToNextPage();
        }

        /// <summary>
        /// Event handler for the View Logs menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void viewLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("logs");
        }

        /// <summary>
        /// Event handler for the View Console menu button
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void viewConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }

        /// <summary>
        /// Event handler for the View Keys menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void viewKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("logs"+Path.DirectorySeparatorChar+"golden.txt");
        }

        /// <summary>
        /// Event handler for the View Stats menu button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void viewStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stats stats = new Stats();
            stats.Show();
        }

        #endregion Menu

        #region Logic

        /// <summary>
        /// 
        /// </summary>
        public void GoToNextPage()
        {
            this.LoadUrl(ConfigurationManager.AppSettings["ethersecret_url"].ToString());
        }

        #endregion Logic
    }
}
