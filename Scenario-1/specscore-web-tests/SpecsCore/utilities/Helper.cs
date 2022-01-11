
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;


public class Helper
{
    public static IWebDriver driver = Driver.get();
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));


    public void MouseOver(IWebElement element)
    {
        Actions builder = new Actions(driver);
        builder.MoveToElement(element).Build().Perform();
    }

    public void waitClickable(IWebElement element)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public void DragAndDrop(By From, By To)
    {
        IWebElement Drag = (IWebElement)driver.FindElement(From);
        IWebElement Drop = (IWebElement)driver.FindElement(To);

        Actions act = new Actions(driver);
        act.DragAndDrop(Drag, Drop).Build().Perform();
    }


    public void ClickElement(IWebElement element)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
        element.Click();
    }

    public void SendKeysElement(IWebElement element, String value)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
        element.SendKeys(value);
    }

    public string GetText(By by)
    {
        IWebElement element = driver.FindElement(by);
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        return element.Text;
    }

    public Boolean isDisplayed(By by)
    {
        IWebElement element = driver.FindElement(by);
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        return element.Displayed;
    }

    public void WaitForAjax()
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
    }

    public void Hover(IWebElement element)
    {
        Actions builder = new Actions(driver);
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
        builder.MoveToElement(element).Click().Build().Perform();
    }

    public void GoToUrl(string searchKey)
    {
        driver.Navigate().GoToUrl("https://www.mizu.com/" + searchKey);
    }
    public IWebElement ScrollTo(IWebElement element)
    {
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        return element;
    }

    public void ScrollTo(By by)
    {
        IWebElement element = driver.FindElement(by);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
    public string Ocr()
    {
        var ocr = new Tesseract.TesseractEngine(System.IO.Directory.GetCurrent‌​Directory() + "\\tessdata", "tur", Tesseract.EngineMode.Default);
        var page = ocr.Process(Tesseract.Pix.LoadFromFile(System.IO.Directory.GetCurrent‌​Directory() + @"\CaptchaImage\captcha.png"));
        var num1 = int.Parse(page.GetText()[0].ToString());
        var num2 = int.Parse(page.GetText()[2].ToString());


        File.Delete(System.IO.Directory.GetCurrent‌​Directory() + @"\CaptchaImage\captcha.png");

        // _helper.WaitForAjax();  
        //  var img = GetElementScreenShot(driver, _loginPageObject.CaptchaImage);
        // img.Save(System.IO.Directory.GetCurrent‌​Directory() + @"\CaptchaImage\captcha.png", ImageFormat.Png);
        //_helper.SendKeysElement(_loginPageObject.CaptchaField, _helper.Ocr());

        return (num1 + num2).ToString();
    }


    public void test()
    {

    }



}