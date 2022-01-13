using System.Net;
using System.Net.Http;
using System.IO;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using WindowsInput;
using WindowsInput.Native;
using System.Threading;

public class Helper
{
    public static IWebDriver driver = Driver.get();
    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));


    public void MouseOver(IWebElement element)
    {
        Actions builder = new Actions(driver);
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
        builder.MoveToElement(element).ClickAndHold().Build().Perform();
    }

    public void waitClickable(IWebElement element)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
    }

    public void waitElementExist(By by)
    {
        wait.Until(ExpectedConditions.ElementExists(by));
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

    public void CloseOpenFileDialog()
    {
        Thread.Sleep(1000);
        InputSimulator sim = new InputSimulator();
        sim.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);
    }
    public void SendKeysElement(IWebElement element, String value)
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(element));
        element.SendKeys(value);
    }

    public void JsClick(IWebElement element)
    {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.get();
        executor.ExecuteScript("arguments[0].click();", element);
    }
    public void JsSendValue(IWebElement element, string value)
    {
        IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.get();
        executor.ExecuteScript("arguments[0].value='" + value + "';", element);
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
    public string IsLinkWorking(string url)
    {
        var webClient = new HttpClient();
        var response = webClient.GetAsync(url).Result;

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return url + " is broken";
        }
        else
        {
            return "link is not broken";
        }
    }
    public string IsLinkBroken(string url)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.AllowAutoRedirect = true;

        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.Close();
                return "link is not broken";
            }
            else
            {
                return url + " is broken";
            }
        }
        catch
        {
            return url + " is broken";
        }
    }

    public void ScrollToElement(By by)
    {
        IWebElement element = driver.FindElement(by);
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
    public string Ocr() //  ciceksepeti login bypass captcha
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


}