using NGordat.Ethersecret.Scanner.WinForm.Ethereum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NGordat.Ethersecret.Scanner.WinForm.Controls;
using System.Threading;

namespace NGordat.Ethersecret.Scanner.WinForm.Components
{
    /// <summary>
    /// Statistics page.
    /// </summary>
    public partial class Stats : Form
    {
        private EthereumService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stats"/> class.
        /// </summary>
        public Stats()
        {
            InitializeComponent();

            service = new EthereumService();

            this.usedAddressesValueLinkLabel.Text = "0";
            this.totalAddressesValueLabel.Text = EthereumService.TotalAddresses;
            this.propabilityPerPageValueLabel.Text = "0";

            service.UsedAddressesRetrieved += OnUsedAddressesUpdated;
            service.ParsedPagesRetrieved += OnTotalPagesParsedUpdated;

            service.GetUsedAddresses();
            service.GetParsedPages();
        }

        /// <summary>
        /// Event handler for Used Addresses UsedAccounts Link.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event.</param>
        private void usedAddressesValueLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(EthereumService.EtherscanAccountsUrl);
        }

        /// <summary>
        /// Event handler for Used Addresses Updated by Ethereum Service.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event.</param>
        protected void OnUsedAddressesUpdated(object sender, EthereumServiceEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => { 
                this.usedAddressesValueLinkLabel.Text = args.UsedAccounts;
                this.propabilityPerPageValueLabel.Text = Convert.ToString(25 * EthereumService.PercentageUsed(args.UsedAccounts, EthereumService.TotalAddresses));
            });
        }

        /// <summary>
        /// Event handler for the total of pages parsed by Ethereum Service.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event.</param>
        protected void OnTotalPagesParsedUpdated(object sender, EthereumServiceEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() =>
            {
                this.addressesParsedValueLabel.Text = args.AddressesParsed;
                this.pagesParsedValueLabel.Text = args.PagesParsed;
                this.keysFoundsValueLabel.Text = args.KeysFounds;
            });
        }
    }
}
