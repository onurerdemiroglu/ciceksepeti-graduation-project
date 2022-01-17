using OpenQA.Selenium;

public class HomePageObject
{

    public IWebElement SubHeaderOverlay => Driver.get().FindElement(HomePageLocator.SubHeaderOverlay);
    public IWebElement UserMenu => Driver.get().FindElement(HomePageLocator.UserMenu);
    public IWebElement MyAccountMenu => Driver.get().FindElement(HomePageLocator.MyAccountMenu);
    public IWebElement SignInButton => Driver.get().FindElement(HomePageLocator.SignInButton);


    public static class HomePageLocator
    {
        public static readonly By SubHeaderOverlay = By.CssSelector(".js-subheader-overlay");
        public static readonly By UserMenu = By.CssSelector(".user-menu__icon--account");
        public static readonly By MyAccountMenu = By.CssSelector(".user-menu__icon--account");
        public static readonly By SignInButton = By.ClassName("users-process-list__btn");
    }
}