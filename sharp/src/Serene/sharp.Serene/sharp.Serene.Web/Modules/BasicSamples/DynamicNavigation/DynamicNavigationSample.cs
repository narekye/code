﻿using sharp.Serene.Northwind.Entities;
using Serenity.Data;
using Serenity.Navigation;
using System.Collections.Generic;

namespace sharp.Serene.BasicSamples
{
    public class DynamicNavigationSample : INavigationItemSource
    {
        public List<NavigationItemAttribute> GetItems()
        {
            var items = new List<NavigationItemAttribute>
            {
                new NavigationMenuAttribute(7970, "Basic Samples/Dynamic Navigation", "icon-paper-plane")
            };

            // Add product categories as dynamic navigation items for demo purpose
            using (var connection = SqlConnections.NewByKey("Northwind"))
            {
                var categories = connection.List<CategoryRow>();
                foreach (var category in categories)
                    items.Add(new NavigationLinkAttribute(7970,
                        path: "Basic Samples/Dynamic Navigation/" + category.CategoryName.Replace("/", "//"),
                        url: "~/Northwind/Product?cat=" + category.CategoryID,
                        permission: Northwind.PermissionKeys.General,
                        icon: "icon-folder-alt"));
            }

            return items;
        }
    }
}