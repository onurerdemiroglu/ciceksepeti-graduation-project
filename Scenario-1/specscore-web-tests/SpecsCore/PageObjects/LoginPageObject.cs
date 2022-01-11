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

public class LoginPageObject
{
    public IWebElement EmailField => Driver.get().FindElement(LoginPageLocators.EmailField);
    public IWebElement PasswordField => Driver.get().FindElement(LoginPageLocators.PasswordField);
    public IWebElement SubmitButton => Driver.get().FindElement(LoginPageLocators.SubmitButton);
    public IWebElement CaptchaImage => Driver.get().FindElement(LoginPageLocators.CaptchaImage);
    public IWebElement CaptchaField => Driver.get().FindElement(LoginPageLocators.CaptchaField);
    public IWebElement GuestCheckOut => Driver.get().FindElement(LoginPageLocators.GuestCheckOut);

    public static class LoginPageLocators
    {
        public static readonly By EmailField = By.CssSelector("input#EmailLogin");
        public static readonly By PasswordField = By.CssSelector("input#Password");
        public static readonly By SubmitButton = By.ClassName("js-login-button");
        public static readonly By CaptchaImage = By.Id("img-captcha");
        public static readonly By CaptchaField = By.Id("Captcha");
        public static readonly By GuestCheckOut = By.CssSelector(".order-login__no-membership");

    }



}


