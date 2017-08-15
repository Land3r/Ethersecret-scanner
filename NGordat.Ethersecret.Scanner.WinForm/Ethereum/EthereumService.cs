using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NGordat.Ethersecret.Scanner.WinForm.Ethereum
{
    /// <summary>
    /// Service used for retrieving some informations about the ethereum Network and Logs.
    /// </summary>
    public class EthereumService
    {
        /// <summary>
        /// The url for gettings accounts statistics.
        /// </summary>
        public static string EtherscanAccountsUrl = ConfigurationManager.AppSettings["etherscan_accounts_url"].ToString();

        /// <summary>
        /// Gets the total number of possible Ethereum addresses.
        /// </summary>
        public static string TotalAddresses = "115792089237316195423570985008687907853269984665640564039457584007913129639935";

        /// <summary>
        /// Gets or sets the number of used ethereum addresses.
        /// </summary>
        private string UsedAddresses = "";

        /// <summary>
        /// Gets or sets the number of parsed pages.
        /// </summary>
        private string ParsedPages = "";

        /// <summary>
        /// Gets or sets the number of parsed addresses.
        /// </summary>
        private string ParsedAddresses = "";

        /// <summary>
        /// Gets or sets the number of found keys.
        /// </summary>
        private string KeysFounds = "";

        #region Events

        /// <summary>
        /// Event triggered when the the number of used addresses is known.
        /// </summary>
        public event EventHandler<EthereumServiceEventArgs> UsedAddressesRetrieved;

        /// <summary>
        /// Event handler to launch event listeners.
        /// </summary>
        /// <param name="e">The event to forward.</param>
        protected virtual void OnUsedAddressesRetrieved(string value)
        {
            EventHandler<EthereumServiceEventArgs> handler = UsedAddressesRetrieved;
            EthereumServiceEventArgs args = new EthereumServiceEventArgs()
            {
                Name = "UsedAddressesRetrieved",
                UsedAccounts = value
            };

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Event triggered when the the number of used addresses is known.
        /// </summary>
        public event EventHandler<EthereumServiceEventArgs> ParsedPagesRetrieved;

        /// <summary>
        /// Event handler to launch event listeners.
        /// </summary>
        /// <param name="e">The event to forward.</param>
        protected virtual void OnParsedPagesRetrieved(string parsedPages, string parsedAccounts, string keysFounds)
        {
            EventHandler<EthereumServiceEventArgs> handler = ParsedPagesRetrieved;
            EthereumServiceEventArgs args = new EthereumServiceEventArgs()
            {
                Name = "ParsedPagesRetrieved",
                PagesParsed = parsedPages,
                AddressesParsed = parsedAccounts,
                KeysFounds = keysFounds
            };

            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion Events

        /// <summary>
        /// Gets the number of total non empty ethereum accounts.
        /// </summary>
        public void GetUsedAddresses()
        {
            if (!string.IsNullOrEmpty(UsedAddresses))
            {
                OnUsedAddressesRetrieved(this.UsedAddresses);
            }
            else
            {
                try
                {
                    Thread t = new Thread(getUsedAddresses);
                    t.IsBackground = true;
                    t.Start();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Retrieves the number of used addresses from a remote source.
        /// </summary>
        private void getUsedAddresses()
        {
            string url = EthereumService.EtherscanAccountsUrl;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            // Hardcoded XPATH to retrieve the stats bloc.
            string accountsWithBalance = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[4]/div[1]/div[1]/span[2]")[0].InnerText;
            if (!string.IsNullOrEmpty(accountsWithBalance))
            {
                // Hardcoded Regex to extract the number of active accounts.
                Match match = Regex.Match(accountsWithBalance, @"A total of ([0-9]+) accounts found");
                if (match.Success)
                {
                    this.UsedAddresses = Convert.ToString(match.Groups[1].Value);
                    OnUsedAddressesRetrieved(this.UsedAddresses);
                }
            }
        }

        /// <summary>
        /// Gets the percentage a value represents compared to another, based on the digits numbers.
        /// Note that this method is mathematicall incorrect but gives a gross estimate.
        /// </summary>
        /// <param name="used">The value that will represents the percentage.</param>
        /// <param name="total">The total value against which the percentage will be applied.</param>
        /// <returns>The ratio between the two values.</returns>
        public static double PercentageUsed(string used, string total)
        {
            return Math.Pow(10, (total.Length - used.Length) * -1);
        }

        /// <summary>
        /// Gets the number of already parsed pages and addresses.
        /// </summary>
        public void GetParsedPages()
        {
            if (!string.IsNullOrEmpty(this.ParsedPages) && !string.IsNullOrEmpty(this.ParsedAddresses) && !string.IsNullOrEmpty(this.KeysFounds))
            {
                OnParsedPagesRetrieved(this.ParsedPages, this.ParsedAddresses, this.KeysFounds);
            }
            else
            {
                try
                {
                    Thread t = new Thread(getParsedPages);
                    t.IsBackground = true;
                    t.Start();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// Retrieves the number of already parsed pages and addresses from a remote source.
        /// </summary>
        private void getParsedPages()
        {
            double pagesParsed = 0;
            double addressesParsed = 0;
            int keysFounds = 0;

            Regex statsRegex = new Regex(@"\[WARN\] Program - Pages parsed: (?<pages>\d+)+, addresses checked: (?<addresses>\d+)+, keys founds: (?<keys>\d+)+");
            string[] dirs = Directory.GetFiles("logs", "log*");
            foreach (string dir in dirs)
            {
                using (StreamReader file = new StreamReader(dir))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.ToString().Substring(20).StartsWith("[WARN]"))
                        {
                            Match match = statsRegex.Match(line.ToString().Substring(20));

                            if (match.Success)
                            {
                                pagesParsed += Convert.ToDouble(match.Groups["pages"].Value);
                                addressesParsed += Convert.ToDouble(match.Groups["addresses"].Value);
                                keysFounds += Convert.ToInt32(match.Groups["keys"].Value);
                            }
                        }
                    }
                }
            }
            OnParsedPagesRetrieved(pagesParsed.ToString(), addressesParsed.ToString(), keysFounds.ToString());
        }
    }
}
