using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NGordat.Ethersecret.Scanner")]
[assembly: AssemblyDescription("EtherSecret Scanner is an autonomous scanner for the EtherSecret website (www.ethersecret.com). It scans pages repeatedly, looking for ethereum private keys with non zero balance.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Nicolas Gordat")]
[assembly: AssemblyProduct("NGordat.Ethersecret.Scanner")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("51146e1f-0ea7-4d93-b1d5-9d7008c09204")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch = true)]