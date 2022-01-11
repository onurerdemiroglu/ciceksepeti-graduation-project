using System.Runtime.InteropServices;
using System.Reflection;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

public class HomePage
{

    HomePageObject _homePageObject = new HomePageObject();
    Helper _helper = new Helper();

    public void GoToHomePage()
    {
        Driver.get().Navigate().GoToUrl("https://www.mizu.com/");
    }

    public void GoToLoginPage()
    {
        _helper.Hover(_homePageObject.UserMenu);
        _helper.ClickElement(_homePageObject.SignInButton);
    }

    public void CloseAdressFocus()
    {
        while (_homePageObject.SubHeaderOverlay.GetAttribute("style") == "display: block;")
            Driver.get().FindElement(By.CssSelector("body")).Click();

        _helper.WaitForAjax();
    }

    public void CheckAccountSection()
    {
        _helper.WaitForAjax();
        Assert.IsTrue(_homePageObject.MyAccountMenu.Displayed);
    }

}