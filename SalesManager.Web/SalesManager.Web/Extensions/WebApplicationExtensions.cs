using Microsoft.EntityFrameworkCore;
using SalesManager.Core.Entities;
using SalesManager.Data.Repositories;
using System.Collections.ObjectModel;

namespace SalesManager.Web.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void RunMigrationSeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SalesDataContext>();
                context.Database.Migrate();

                if (context.Windows.Any())
                {
                    return;
                }

                SeedData(context);
            };
        }

        private static void SeedData(SalesDataContext context)
        {
            // States
            var ny = new State { Name = "NY" };
            var ca = new State { Name = "CA" };

            // Element types
            var typeDoors = new SubElementType { Name = "Doors" };
            var typeWindow = new SubElementType { Name = "Window" };

            // Elements
            
            var element1 = new SubElement { Element = 1, Type = typeDoors, Width = 1200, Height = 1850 };
            var element2 = new SubElement { Element = 2, Type = typeWindow, Width = 800, Height = 1850 };
            var element3 = new SubElement { Element = 3, Type = typeWindow, Width = 700, Height = 1850 };
            var element4 = new SubElement { Element = 1, Type = typeWindow, Width = 1500, Height = 2000 };
            var element5 = new SubElement { Element = 1, Type = typeDoors, Width = 1400, Height = 2200 };
            var element6 = new SubElement { Element = 2, Type = typeWindow, Width = 600, Height = 2200 };
            var element7 = new SubElement { Element = 1, Type = typeWindow, Width = 1500, Height = 2000 };
            var element8 = new SubElement { Element = 1, Type = typeWindow, Width = 1500, Height = 2000 };

            var window1Elements = new Collection<SubElement> { element1, element2, element3 };
            var window2Elements = new Collection<SubElement> { element4 };
            var window3Elements = new Collection<SubElement> { element5, element6 };
            var window4Elements = new Collection<SubElement> { element7, element8 };

            // WindowsNew York Building 1
            var window1 = new Window { Name = "A51", QuantityOfWindows = 4, TotalSubElements = 3, SubElements = window1Elements };
            var window2 = new Window { Name = "C Zone 5", QuantityOfWindows = 2, TotalSubElements = 1, SubElements = window2Elements };
            var window3 = new Window { Name = "GLB", QuantityOfWindows = 3, TotalSubElements = 2, SubElements = window3Elements };
            var window4 = new Window { Name = "OHF", QuantityOfWindows = 10, TotalSubElements = 2, SubElements = window4Elements };

            var order1Windows = new Collection<Window> { window1, window2 };
            var order2Windows = new Collection<Window> { window3, window4 };

            // Orders
            var order1 = new Order { Name = "New York Building 1", State = ny, Windows = order1Windows };
            var order2 = new Order { Name = "California Hotel AJK", State = ca, Windows = order2Windows };

            // Insertion
            context.Orders.AddRange(order1, order2);
            context.SaveChanges();
        }
    }
}
