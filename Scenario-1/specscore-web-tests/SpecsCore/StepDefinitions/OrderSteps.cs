using TechTalk.SpecFlow;

[Binding]
public class OrderSteps
{
    OrderPage _orderPage = new OrderPage();

    [When(@"I fill out the order information form")]
    public void FillOrderInformationForm()
    {
        _orderPage.FillOrderInformationForm();
    }

    [When(@"I fill out the sender information form")]
    public void FillSenderInformationForm()
    {
        _orderPage.FillSenderInformationForm();
    }

    [When(@"I fill out the payment form")]
    public void FillPaymentForm()
    {
        _orderPage.FillPaymentForm();

    }

    [Then(@"I should see the message we received your order")]
    public void VerifyReceivedOrder()
    {
        _orderPage.VerifyReceivedOrder();
    }


    [When(@"I customize the product and click next button")]
    public void PersonalizeProduct()
    {
        _orderPage.PersonalizeProduct();
    }

    [Then(@"I should see the product added to basket")]
    public void VerifyProductAddedToBasket()
    {
        _orderPage.VerifyProductAddedToBasket();
    }

}