using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGordat.Ethersecret.Scanner.WinForm.Ethereum
{
    /// <summary>
    /// Defines the Arguments that are thrown by <see cref="EthereumService"/>.
    /// </summary>
    public class EthereumServiceEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the event.
        /// </summary>
        public string UsedAccounts { get; set; }

        /// <summary>
        /// Gets or sets the value of the event.
        /// </summary>
        public string PagesParsed { get; set; }

        /// <summary>
        /// Gets or sets the value of the event.
        /// </summary>
        public string AddressesParsed { get; set; }

        /// <summary>
        /// Gets or sets the value of the event.
        /// </summary>
        public string KeysFounds { get; set; }
    }
}
