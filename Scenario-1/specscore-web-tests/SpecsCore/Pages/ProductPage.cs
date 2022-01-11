using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

public class ProductPage
{
    Helper _helper = new Helper();
    ProductPageObject _productPageObject = new ProductPageObject();

    public void AddProductToBasket()
    {
        _helper.ClickElement(_productPageObject.AddToCart);
    }

    public void CustomizeTheProduct()
    {

        _helper.SendKeysElement(_productPageObject.DynamicText, "CicekSepeti Bootcamp");

        string filePath = System.IO.Directory.GetCurrent‌​Directory() + @"\image.png";

        IWebElement element = Driver.get().FindElement(By.Id("2007339"));


        element.SendKeys(Keys.Return);
        element.SendKeys(filePath);



        Thread.Sleep(5000);
        /*   IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.get();
          executor.ExecuteScript("arguments[0].click();", element); */

    }


    public void DeliveryTimeAndAddToCard()
    {
        _helper.ClickElement(_productPageObject.ProductDeliveryDates[1]);

        _helper.Hover(_productPageObject.DeliveryHourSection);
        _helper.ClickElement(_productPageObject.FirstDeliveryHour);

        _helper.ClickElement(_productPageObject.AddToCart);
    }
}