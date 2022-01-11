using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

public class OrderPage
{
    Helper _helper = new Helper();
    OrderPageObject _orderPageObject = new OrderPageObject();


    public void FillOrderInformationForm()
    {
        _helper.SendKeysElement(_orderPageObject.RecipientName, "CicekSepeti Bootcamp");
        _helper.SendKeysElement(_orderPageObject.RecipientPhoneNumber, "1252152134");

        _helper.SendKeysElement(_orderPageObject.FindAddressSection, "Mexico City");
        _helper.MouseOver(_orderPageObject.AddressResults[0]);
        _helper.ClickElement(_orderPageObject.AddressResults[0]);
        _helper.WaitForAjax();
        _helper.SendKeysElement(_orderPageObject.ExteriorInteriorNo, "21");
        _helper.SendKeysElement(_orderPageObject.PostalCode, "02820");
        _helper.ClickElement(_orderPageObject.DeliveryLocation);
        _helper.ClickElement(_orderPageObject.FirstDeliveryLocation);

        _helper.ClickElement(_orderPageObject.NextOrderButton);
        _helper.ClickElement(_orderPageObject.NextOptionalProduct);

    }

    public void FillSenderInformationForm()
    {
        _helper.SendKeysElement(_orderPageObject.BuyerName, "Onur CicekSepeti");

        _helper.ClickElement(_orderPageObject.CountryCode);
        _helper.ClickElement(_orderPageObject.FirstCountryCode);
        _helper.SendKeysElement(_orderPageObject.PhoneNumber, "1231232133");
        _helper.SendKeysElement(_orderPageObject.Email, "ciceksepetioe@gmail.com");
        _helper.ClickElement(_orderPageObject.NextOrderButton);
    }

    public void FillPaymentForm()
    {
        _helper.ClickElement(_orderPageObject.OXXO);
        _helper.ClickElement(_orderPageObject.TermsCheckBox);
        _helper.ClickElement(_orderPageObject.PayButton);
    }

    public void VerifyReceivedOrder()
    {
        _helper.waitClickable(_orderPageObject.CardMessageTextArea);

        Assert.IsTrue(_orderPageObject.ThanksMessageText.Displayed);

    }
}