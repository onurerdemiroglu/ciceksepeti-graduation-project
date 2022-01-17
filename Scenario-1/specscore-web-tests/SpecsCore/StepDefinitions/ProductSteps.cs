using TechTalk.SpecFlow;

[Binding]
public class ProductSteps
{
    ProductPage _productPage = new ProductPage();
    Helper _helper = new Helper();

    [Given(@"I open the '(.*)' url")]
    public void OpenTheUrl(string searchKey)
    {
        _helper.GoToUrl(searchKey);
    }

    [When(@"I add product to basket")]
    public void AddProductToBasket()
    {
        _productPage.AddProductToBasket();
    }

    [When(@"I select the delivery time and click the add to cart button")]
    public void DeliveryTimeAndAddToCard()
    {
        _productPage.DeliveryTimeAndAddToCard();
    }
}