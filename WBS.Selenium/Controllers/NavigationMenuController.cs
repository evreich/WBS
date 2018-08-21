using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Serialization;
using System.IO;
using WBS.Selenium.Models;
using WBS.Selenium.Controllers.UIControllers;

namespace WBS.Selenium.Controllers
{
    public class NavigationMenuController
    {
        private MenuNode menu;
        private Context context;
        private Stack<string> path;

        public void Initialize(Context context)
        {
            this.context = context;
            menu = new MenuNode();
            menu.Title = "root";
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDi‌​rectory, "Configs\\NavigationMenu.xml"));

            XmlSerializer serializer = new XmlSerializer(typeof(List<MenuNode>), new XmlRootAttribute("navigationMenu"));
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                menu.Children = (List<MenuNode>)serializer.Deserialize(stream);
            }
        }

        public void OpenPage(string title)
        {
            bool found = false;
            FindNode(menu, title, ref found);
            //нажимает на иконку с меню
            IWebElement menuController = context.Driver.FindElement(By.XPath("//header//button[contains(@class,'MuiButtonBase')]"));
            menuController.Click();
            //ожидает появления навигационного меню
            context.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'MuiPaper') and contains(@class,'SideMenuComponent')]")));
            MenuNodeController node = new MenuNodeController();
            node.Initialize(context, path.Pop());
            MenuNodeController nextNode = new MenuNodeController();

            while (path.Count != 0)
            {
                nextNode = new MenuNodeController();
                nextNode.Initialize(context, path.Pop());

                if (!nextNode.IsVisible())
                    node.Click();

                node = nextNode;
            }

            nextNode.Click();

            //закрыть меню
            IWebElement closeMenu=context.Driver.FindElement(By.CssSelector("path[d*='M15.41 7.41L14']"));
            closeMenu.Click();
        }
        private void FindNode(MenuNode node, string title, ref bool found)
        {
            if (node.Title == title)
            {
                found = true;
                path = new Stack<string>();
                path.Push(node.Title);
            }
            else
            {
                foreach (MenuNode child in node.Children)
                {
                    FindNode(child, title, ref found);
                    if (found)
                    {
                        if (node.Title != "root")
                            path.Push(node.Title);
                        break;
                    }
                }
            }
        }
    }
}
