using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

public class TestPage
{
    Helper _helper = new Helper();
    public TestPage()
    {
        PageFactory.InitElements(Driver.get(), this);
    }

    public void test()
    {
        int MainMenuNumber = Driver.get().FindElements(By.CssSelector(".main-menu__link")).Count;
        int MegaMenuNumber = Driver.get().FindElements(By.CssSelector(".js-mega-menu-second")).Count;
        int SubMenuNumber = Driver.get().FindElements(By.CssSelector(".main-submenu__item-link")).Count;

        IWebElement element = Driver.get().FindElement(By.CssSelector(".js-product-search-input"));

        element.SendKeys("Main Menu Sayısı " + MainMenuNumber.ToString());
        element.SendKeys(" MegaMenuNumber " + MegaMenuNumber.ToString());
        element.SendKeys(" SubMenuNumber " + SubMenuNumber.ToString());
    }

}