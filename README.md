# Xomega.Examples
Current repository contains examples for building .Net web and desktop apps with Xomega technology and frameworks.

The examples demonstrate working multi-tier applications based on the sample AdventureWorks database in the following technologies:
- ASP.NET WebForms application;
- WPF client-server application;
- WPF distributed application with a WCF middle tier;
- Single Page Application in TypeScript with a REST middle tier based on Web API

AdventureWorks Xomega examples were created by following the [comprehensive Xomega tutorial](http://xomega.net/Tutorials/WalkThrough.aspx).

## Prerequisites
To run these examples you need to have the following software installed:
- Visual Studio 2015 with latest updates.
- [AdventureWorks2012 sample database](https://msftdbprodsamples.codeplex.com/releases/view/93587) running on your local or network SQL server.
- [TypeScript for VS2015](http://www.typescriptlang.org/index.html#download-links) for running the SPA project
- [Xomega.Net for VS2015](http://xomega.net/System/Download.aspx) with a valid license for working with the model project, and regenerating the model.

## Setting up your projects
You need to make the following updates to be able to run the examples.
- Update connection strings in the Web.config and App.config files in the applicable projects to point to your AdventureWorks DB.
- On the properties of the AdventureWorks.Services.Wcf and AdventureWorks.Services.Rest projects select "Don't open a page" option as a Start Action under the Web tab.

## Running the apps
* ASP.NET WebForms - select AdventureWorks.Client.Web as the startup project and run the solution.
* SPA - open solution properties, and select multiple startup projects as follows, and run the solution.
  * AdventureWorks.Client.Spa with 'Start without Debugging' action. (Debugging will be in the browser)
  * AdventureWorks.Services.Rest with 'Start' action.
* WPF  - open solution properties, and select multiple startup projects as follows, and run the solution.
  * AdventureWorks.Client.Wpf with 'Start' action.
  * AdventureWorks.Services.Wcf with 'Start' action.

Use an email address for a person from the AdventureWorks DB as the user name (e.g. ken0@adventure-works.com), and the word 'password' as the password.
