//---------------------------------------------------------------------------------------------
// This file was AUTO-GENERATED by "Blazor Views" Xomega.Net generator.
//
// Manual CHANGES to this file WILL BE LOST when the code is regenerated.
//---------------------------------------------------------------------------------------------

using System.Collections.Generic;
using Xomega.Framework.Blazor.Components;

namespace AdventureWorks.Client.Blazor.Common.Views
{
    public class MainMenu
    {
        public static List<MenuItem> Items = new List<MenuItem>()
        {
            new MenuItem()
            {
                ResourceKey = "Module_Sales_NavMenu",
                IconClass = "bi bi-columns",
                Items = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        ResourceKey = "CustomerListView_NavMenu",
                        IconClass = "bi bi-card-list",
                        Href = "CustomerListView"
                    },
                    new MenuItem()
                    {
                        ResourceKey = "SalesOrderView_NavMenu",
                        IconClass = "bi bi-pencil-square",
                        Href = "SalesOrderView?_action=create"
                    },
                    new MenuItem()
                    {
                        ResourceKey = "SalesOrderListView_NavMenu",
                        IconClass = "bi bi-card-list",
                        Href = "SalesOrderListView"
                    },
                }
            },
        };
    }
}