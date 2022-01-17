
public class ProductPage
{
    Helper _helper = new Helper();
    ProductPageObject _productPageObject = new ProductPageObject();

    public void DeliveryTimeAndAddToCard()
    {
        _helper.ClickElement(_productPageObject.ProductDeliveryDates[1]);

        _helper.Hover(_productPageObject.DeliveryHourSection);
        _helper.ClickElement(_productPageObject.FirstDeliveryHour);

        _helper.ClickElement(_productPageObject.AddToCart);
    } 
    
    public void AddProductToBasket()
    {
        _helper.ClickElement(_productPageObject.AddToCart);
    }
}