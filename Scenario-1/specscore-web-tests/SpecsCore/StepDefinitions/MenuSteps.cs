using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

[Binding]
public class MenuSteps
{
    MenuPage _menuPage = new MenuPage();
    ProductPage _productPage = new ProductPage();

    [Then(@"I scrolling down to page (.*) and check see (.*) products displayed per page")]
    public void ScrollToDownPage(int pageNumber, int perPageProduct)
    {
        _menuPage.DownPage(pageNumber, perPageProduct);

    }

    [When(@"I sort result list based on (.*)")]
    public void SortResult(string sortCriterion)
    {
        _menuPage.SelectPriceHighToLow(sortCriterion);
    }


    [Then(@"I should see the prices listed from high to low")]
    public void PricesShouldBeListedHighToLow()
    {
        _menuPage.VerifiyHighToLow();
    }



    [When(@"I choose shipping address '(.*)'")]
    public void IChooseShippingAddress(string address)
    {
        _menuPage.ChooseAdress(address);
    }


    [When(@"I open the first product page")]
    public void OpenFirstProductPage()
    {
        _menuPage.OpenFirstProductPage();
    }


    [When(@"I select the delivery time and click the add to cart button")]
    public void DeliveryTimeAndAddToCard()
    {
        _productPage.DeliveryTimeAndAddToCard();
    }





}