using NUnit.Framework;
using System.IO;
public class OrderPage
{
    Helper _helper = new Helper();
    OrderPageObject _orderPageObject = new OrderPageObject();

    public void FillOrderInformationForm()
    {
        _helper.SendKeysElement(_orderPageObject.RecipientName, "CicekSepeti Bootcamp");
        _helper.SendKeysElement(_orderPageObject.RecipientPhoneNumber, "1252152134");
        _helper.SendKeysElement(_orderPageObject.FindAddressSection, "Mexico City, Mexico");
        _helper.SendKeysElement(_orderPageObject.AddressDetailSection, "Mexico City, Mexico");

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
        _helper.JsClick(_orderPageObject.TermsInfo);
        _helper.ClickElement(_orderPageObject.TermsInfoAgreeButton);
        _helper.ClickElement(_orderPageObject.PayButton);
    }

    public void VerifyReceivedOrder()
    {
        Assert.IsTrue(_orderPageObject.ThanksMessageText.Displayed);
    }

    public void PersonalizeProduct()
    {
        string imagePath = Directory.GetCurrent‌​Directory() + "\\image.png";
        string personalizeText = "CicekSepeti Bootcamp";

        _helper.SendKeysElement(_orderPageObject.PersonalizeParagraph, personalizeText);
        _helper.JsClick(_orderPageObject.PersonalizeUpload);
        _orderPageObject.PersonalizeUpload.SendKeys(imagePath);
        _helper.CloseOpenFileDialog();
        _helper.ClickElement(_orderPageObject.ConfirmDesign);
        _helper.ClickElement(_orderPageObject.NextOrderButton);
    }

    public void VerifyProductAddedToBasket()
    {
        Assert.IsTrue(_orderPageObject.ProductTitle.Displayed);
    }
}