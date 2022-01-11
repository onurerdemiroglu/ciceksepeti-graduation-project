using System.IO;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Newtonsoft.Json.Linq;

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