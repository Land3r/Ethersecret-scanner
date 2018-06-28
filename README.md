# Ethersecret-scanner
An automated scanner for ethersecret addresses

EtherSecret Scanner is an autonomous scanner for the EtherSecret website (www.ethersecret.com).

The EtherSecret website is a project where people have generated the **entire keyspace of possible private keys** for ethereum (based on SHA-256) which gave all the possible 2^256(115792089237316195423570985008687907853269984665640564039457584007913129639936) keys.

This program automatically scraps pages looking for positive balance accounts.

Note that the chances of actually finding an account are very tiny.

# Build

The underlying browser used cannot be compiled using 'Any CPU' configuration. Please set the Active Configuration Platform to 'x86' or 'x64' depending on your architecture.

Additionally, you will need Visual Studio 2017 or higher and .NET 4.5.2 to compile the solution (or you can upgrade it).

# Run

In order to run this application, you will need the VC++ 2013 Runtime (https://www.microsoft.com/en-us/download/details.aspx?id=40784)
