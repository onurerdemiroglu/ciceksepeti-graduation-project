using System.Collections.ObjectModel;
using OpenQA.Selenium;

public class OrderPageObject
{
    public IWebElement PersonalizeParagraph => Driver.get().FindElement(OrderInformationLocators.PersonalizeParagraph);
    public IWebElement PersonalizeUpload => Driver.get().FindElement(OrderInformationLocators.PersonalizeUpload);
    public IWebElement ConfirmDesign => Driver.get().FindElement(OrderInformationLocators.ConfirmDesign);
    public IWebElement RecipientName => Driver.get().FindElement(OrderInformationLocators.RecipientName);
    public IWebElement RecipientPhoneNumber => Driver.get().FindElement(OrderInformationLocators.RecipientPhoneNumber);
    public IWebElement FindAddressSection => Driver.get().FindElement(OrderInformationLocators.FindAddressSection);
    public IWebElement AddressDetailSection => Driver.get().FindElement(OrderInformationLocators.AddressDetailSection);
    public ReadOnlyCollection<IWebElement> AddressResults => Driver.get().FindElements(OrderInformationLocators.AddressResults);
    public IWebElement ExteriorInteriorNo => Driver.get().FindElement(OrderInformationLocators.ExteriorInteriorNo);
    public IWebElement PostalCode => Driver.get().FindElement(OrderInformationLocators.PostalCode);
    public IWebElement DeliveryLocation => Driver.get().FindElement(OrderInformationLocators.DeliveryLocation);
    public IWebElement FirstDeliveryLocation => Driver.get().FindElement(OrderInformationLocators.FirstDeliveryLocation);
    public IWebElement NextOrderButton => Driver.get().FindElement(OrderInformationLocators.NextOrderButton);
    public IWebElement NextOptionalProduct => Driver.get().FindElement(OrderInformationLocators.NextOptionalProduct);
    public IWebElement BuyerName => Driver.get().FindElement(SenderInformationLocators.BuyerName);
    public IWebElement CountryCode => Driver.get().FindElement(SenderInformationLocators.CountryCode);
    public IWebElement FirstCountryCode => Driver.get().FindElement(SenderInformationLocators.FirstCountryCode);
    public IWebElement PhoneNumber => Driver.get().FindElement(SenderInformationLocators.PhoneNumber);
    public IWebElement Email => Driver.get().FindElement(SenderInformationLocators.Email);
    public IWebElement OXXO => Driver.get().FindElement(PaymentLocators.OXXO);
    public IWebElement TermsCheckBox => Driver.get().FindElement(PaymentLocators.TermsCheckBox);
    public IWebElement TermsInfo => Driver.get().FindElement(PaymentLocators.TermsInfo);
    public IWebElement TermsInfoAgreeButton => Driver.get().FindElement(PaymentLocators.TermsInfoAgreeButton);
    public IWebElement PayButton => Driver.get().FindElement(PaymentLocators.PayButton);
    public IWebElement SaveGiftNoteButton => Driver.get().FindElement(ReceivedOrderLocators.SaveGiftNoteButton);
    public IWebElement ThanksMessageText => Driver.get().FindElement(ReceivedOrderLocators.ThanksMessageText);
    public IWebElement ProductTitle => Driver.get().FindElement(BasketLocators.ProductTitle);


    public static class OrderInformationLocators
    {
        public static readonly By PersonalizeParagraph = By.Id("dynamicText0");
        public static readonly By PersonalizeUpload = By.CssSelector(".custom-image__input");
        public static readonly By ConfirmDesign = By.CssSelector(".js-customize-confirmation-label");
        public static readonly By RecipientName = By.CssSelector(".js-address-name");
        public static readonly By RecipientPhoneNumber = By.CssSelector(".js-only-number");
        public static readonly By FindAddressSection = By.XPath("//input[@placeholder='Find your address']");
        public static readonly By AddressDetailSection = By.CssSelector(".js-address-line");
        public static readonly By AddressResults = By.CssSelector(".product-location__results-item");
        public static readonly By ExteriorInteriorNo = By.CssSelector(".js-ext-int-no");
        public static readonly By PostalCode = By.CssSelector(".js-postal-code");
        public static readonly By DeliveryLocation = By.XPath("//input[@placeholder='Delivery Location']");
        public static readonly By FirstDeliveryLocation = By.XPath("(//*[@class='selectize-dropdown-content'])[6]/div[1]");
        public static readonly By NextOrderButton = By.CssSelector(".order-next-button");
        public static readonly By NextOptionalProduct = By.CssSelector(".order-next-button--before-summary");
    }

    public static class SenderInformationLocators
    {
        public static readonly By BuyerName = By.Id("BuyerName");
        public static readonly By CountryCode = By.XPath("//input[@placeholder='Country']");
        public static readonly By FirstCountryCode = By.XPath("//*[@class='selectize-dropdown-content']/div[1]");
        public static readonly By PhoneNumber = By.CssSelector(".js-phone-number-validation");
        public static readonly By Email = By.CssSelector(".js-billing-address-email");
    }

    public static class PaymentLocators
    {
        public static readonly By OXXO = By.XPath("//*[text()='OXXO']");
        public static readonly By TermsCheckBox = By.XPath("//p[contains(text(), 'I accept the Terms and Conditions.')]");
        public static readonly By PayButton = By.CssSelector(".js-confirm-basket");
        public static readonly By TermsInfo = By.CssSelector(".preliminary-info__confirmation-link");
        public static readonly By TermsInfoAgreeButton = By.CssSelector(".agree-button");
    }

    public static class ReceivedOrderLocators
    {
        public static readonly By SaveGiftNoteButton = By.CssSelector(".card-message__send-btn");
        public static readonly By ThanksMessageText = By.CssSelector(".thanks__message-text");

    }

    public static class BasketLocators
    {
        public static readonly By ProductTitle = By.CssSelector(".cart__item-col-link");

    }
}


