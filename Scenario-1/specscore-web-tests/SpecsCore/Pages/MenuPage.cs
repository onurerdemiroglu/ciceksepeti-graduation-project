using OpenQA.Selenium;
using System;
using NUnit.Framework;

public class MenuPage
{

    Helper _helper = new Helper();
    MenuPageObject _menuPageObject = new MenuPageObject();

    public void DownPage(int pageNumber, int perPageProduct)
    {
        for (int i = 1; i < pageNumber; i++)
        {
            if (!Driver.get().Url.Contains("page=" + pageNumber.ToString()))
            {
                _helper.WaitForAjax();

                int TotalProduct = _menuPageObject.ProductArray.Count;
                string LastProductLocator = ".js-category-item-hover:nth-child(" + Convert.ToString(TotalProduct) + ")";

                Assert.AreEqual(perPageProduct * i, TotalProduct);

                _helper.ScrollTo(By.CssSelector(LastProductLocator));
            }
        }
    }

    public void SelectPriceHighToLow(string sortCriterion)
    {
        IWebElement locator = Driver.get().FindElement(By.XPath("//*[text()='" + sortCriterion + "']"));

        _helper.Hover(_menuPageObject.SortDropDown);
        _helper.ClickElement(locator);
    }

    public void VerifiyHighToLow()
    {
        int TotalProduct = _menuPageObject.ProductArray.Count;
        Double[] PriceArray = new Double[TotalProduct + 1];


        for (int i = 1; i <= TotalProduct; i++)  // Product prices are added to the array
        {
            string locatorPriceInt = "(//span[@class='price__integer-value'])[" + i.ToString() + "]";
            string locatorPriceDec = "(//span[@class='price__decimal-value-with-currency'])[" + i.ToString() + "]";

            double priceInt = Double.Parse(Driver.get().FindElement(By.XPath(locatorPriceInt)).Text);
            double PriceDec = Double.Parse("0" + Driver.get().FindElement(By.XPath(locatorPriceDec)).Text);

            PriceArray[i] = priceInt + PriceDec;
        }

        for (int i = 1; i < TotalProduct; i++)
        {
            Assert.GreaterOrEqual(PriceArray[i], PriceArray[i + 1]);
        }
    }

    public void ChooseAdress(string address)
    {
        _helper.ClickElement(_menuPageObject.AddressSearchButton);
        _helper.SendKeysElement(_menuPageObject.AddressSearchInput, address);
        _helper.ClickElement(_menuPageObject.AddressResults[4]);
    }

    public void OpenFirstProductPage()
    {
        _helper.ClickElement(_menuPageObject.ProductArray[0]);
    }



}