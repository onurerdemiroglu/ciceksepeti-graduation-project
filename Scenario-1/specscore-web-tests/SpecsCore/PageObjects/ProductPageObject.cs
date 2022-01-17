using System.Collections.ObjectModel;
using OpenQA.Selenium;

public class ProductPageObject
{
    public IWebElement AddToCart => Driver.get().FindElement(ProductPageLocators.AddToCart);
    public IWebElement DynamicText => Driver.get().FindElement(ProductPageLocators.DynamicText);
    public IWebElement Upload => Driver.get().FindElement(ProductPageLocators.Upload);
    public IWebElement DeliveryHourSection => Driver.get().FindElement(ProductPageLocators.DeliveryHourSection);
    public IWebElement FirstDeliveryHour => Driver.get().FindElement(ProductPageLocators.FirstDeliveryHour);
    public ReadOnlyCollection<IWebElement> ProductDeliveryDates => Driver.get().FindElements(ProductPageLocators.ProductDeliveryDates);

    public static class ProductPageLocators
    {
        public static readonly By AddToCart = By.CssSelector(".js-add-to-cart");
        public static readonly By ProductDeliveryDates = By.CssSelector(".product__dates-col");
        public static readonly By DeliveryHourSection = By.Name("AddToCartModel.DeliveryHour");
        public static readonly By FirstDeliveryHour = By.CssSelector("option:nth-child(2)");
        public static readonly By DynamicText = By.Id("dynamicText0");
        public static readonly By Upload = By.CssSelector(".custom-image__input");
    }
}


