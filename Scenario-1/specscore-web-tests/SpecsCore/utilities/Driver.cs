using System.Threading;
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
using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class Driver
{
    public static IWebDriver driver;
    public static ConfigReader _configReader = new ConfigReader();

    public static WebDriver get()
    {

        if (driver == null)
        {
            string browser = _configReader.get("browserName");

            switch (browser.ToLower())
            {

                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "chrome-headless":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--headless");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "firefox-headless":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--headless");
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "ie":
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver();
                    break;

                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

                default:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
            }
        }
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        return (WebDriver)driver;
    }

    [AfterScenario]
    public static void closeDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }

}