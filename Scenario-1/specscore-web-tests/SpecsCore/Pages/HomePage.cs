using OpenQA.Selenium;
using NUnit.Framework;

public class HomePage
{
    public static IWebDriver driver = Driver.get();
    HomePageObject _homePageObject = new HomePageObject();
    Helper _helper = new Helper();

    public void GoToHomePage()
    {
        driver.Navigate().GoToUrl("https://www.mizu.com/");
    }

    public void GoToLoginPage()
    {
        _helper.Hover(_homePageObject.UserMenu);
        _helper.ClickElement(_homePageObject.SignInButton);
    }

    public void CloseAdressFocus()
    {
        while (_homePageObject.SubHeaderOverlay.GetAttribute("style") == "display: block;")
            driver.FindElement(By.CssSelector("body")).Click();

        _helper.WaitForAjax();
    }

    public void CheckAccountSection()
    {
        _helper.WaitForAjax();
        Assert.IsTrue(_homePageObject.MyAccountMenu.Displayed);
    } 
}