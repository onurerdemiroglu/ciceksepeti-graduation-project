using TechTalk.SpecFlow;

[Binding]
public class ProductSteps
{
    Helper _helper = new Helper();
    ProductPage _productPage = new ProductPage();


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

}