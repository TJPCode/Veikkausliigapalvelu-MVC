using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Veikkausliigapalvelu")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Veikkausliigapalvelu")]
[assembly: AssemblyCopyright("Copyright © Timo-Jaakko Paasila 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("20fa9225-870a-4d9d-8564-46a19fb29183")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("2.2.0.0")]
[assembly: AssemblyFileVersion("2.2.0.0")]
// 1.0 Simple MVC project. There is only 2015 matches page and search feature. Matches are loaded from json file.
// 2.0 Front page added with RSS feeds. User can now view details of certain match. Two league table pages for data from database and json. Cannot modify data yet.
// 2.1 User is able to modify league table data and save it to database.
// 2.2 Front page slider added. Rss feeds are now in partial view so user can now select different rss providers feed without refreshing the whole front page.