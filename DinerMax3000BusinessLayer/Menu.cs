using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DinerMax3000.Business.dsDinerMax3000TableAdapters;

namespace DinerMax3000.Business
{
    public class Menu
    {
        public Menu()
        {
            Items = new List<MenuItem>();

        }
        private int _databaseID;

        public void SaveMenuItem(string Name, string Description, double Price)
        {
            MenuItemTableAdapter taMenuItem = new MenuItemTableAdapter();
            taMenuItem.InsertNewMenuItem(Name, Description, Price, DatabaseID);
        }
        public static List<Menu> GetAllMenus()
        {
            MenuTableAdapter taMenu = new MenuTableAdapter();
            MenuItemTableAdapter taMenuItem = new MenuItemTableAdapter();
            var dtMenu = taMenu.GetData();
            List<Menu> allMenus = new List<Menu>();
            foreach( dsDinerMax3000.MenuRow menuRow in dtMenu.Rows)
            {
                Menu currentMenu = new Menu();
                currentMenu.name = menuRow.Name;
                currentMenu.DatabaseID = menuRow.Id;
                allMenus.Add(currentMenu);

                var dtMEnuItems = taMenuItem.GetMenuItemsByMenuId(menuRow.Id);
                foreach(dsDinerMax3000.MenuItemRow menuItemRow in dtMEnuItems.Rows)
                {
                    currentMenu.AddMenuItem(menuItemRow.Name, menuItemRow.Description, menuItemRow.Price);
                }
            }

            return allMenus;
        }

        public void AddMenuItem(string Title, string Description, double price)
        {
            MenuItem item = new MenuItem();
            item.title = Title;
            item.description = Description;
            item.price = price;
            Items.Add(item);
        }
        public string name { get; set; }
        public List<MenuItem> Items { get; set; }

        public int DatabaseID
        {
            get
            {
                return _databaseID;
            }

            set
            {
                _databaseID = value;
            }
        }
    }
}
