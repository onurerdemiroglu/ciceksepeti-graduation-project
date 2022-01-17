using System.Collections.Generic;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using System.Linq;

public class MenuPage
{
    public static IWebDriver driver = Driver.get();
    Helper _helper = new Helper();
    MenuPageObject _menuPageObject = new MenuPageObject();
    List<string> links = new List<string>();

    public void DownPage(int pageNumber, int perPageProduct)
    {
        for (int i = 1; i < pageNumber; i++)
        {
            if (!Driver.get().Url.Contains("page=" + pageNumber.ToString())) // ? Is page value equal to i in url?
            {
                int totalProductInPage = _menuPageObject.ProductArray.Count;
                string lastProductLocator = "//a[@data-position='" + Convert.ToString(totalProductInPage) + "']";
                string lastProductNewPage = "//a[@data-position='" + Convert.ToString(totalProductInPage + perPageProduct) + "']";


                Assert.AreEqual(perPageProduct * i, totalProductInPage);

                _helper.ScrollToElement(By.XPath(lastProductLocator));
                _helper.waitElementExist(By.XPath(lastProductNewPage)); // ? Wait for the exist of new products on the page
            }
        }
    }

    public void SortByCriteria(string sortCriterion)
    {
        IWebElement locator = driver.FindElement(By.XPath("//*[text()='" + sortCriterion + "']"));

        _helper.Hover(_menuPageObject.SortDropDown);
        _helper.ClickElement(locator);
        _helper.WaitForAjax();
    }

    public void ScrollToLastPage()
    {
        int TotalProduct = Int32.Parse(_menuPageObject.ProductCount.Text);

        while (_menuPageObject.ProductArray.Count < TotalProduct)
        {
            _helper.ScrollTo(_menuPageObject.ProductArray[_menuPageObject.ProductArray.Count - 1]);
            _helper.WaitForAjax();
        }

         ((IJavaScriptExecutor)driver).
        ExecuteScript("document.querySelectorAll('.price--old').forEach(function(element) {element.remove();});"); // ? Remove Old Prices
    }

    public void VerifiyHighToLow()
    {
        int TotalProduct = Int32.Parse(_menuPageObject.ProductCount.Text);

        Double[] PriceArray = new Double[TotalProduct + 1];

        for (int i = 1; i <= TotalProduct; i++)  // ? Product prices are added to the array
        {
            string locatorPriceInt = "(//span[@class='price__integer-value'])[" + i.ToString() + "]";
            string locatorPriceDec = "(//span[@class='price__decimal-value-with-currency'])[" + i.ToString() + "]";

            double priceInt = Double.Parse(driver.FindElement(By.XPath(locatorPriceInt)).Text);
            double priceDec = Double.Parse("0" + driver.FindElement(By.XPath(locatorPriceDec)).Text);

            PriceArray[i] = priceInt + priceDec;
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

    public void FindMenuLinks()
    {
        for (int j = 0; j < _menuPageObject.MainMenuLinks.Count; j++)   // ? Hover all menus
        {
            _helper.MouseOver(_menuPageObject.MainMenuLinks[j]); // ?Hover Main Menu

            for (int i = 0; i < _menuPageObject.SubMenuLinks.Count; i++)
            {
                if (_menuPageObject.SubMenuLinks[i].Displayed)
                {
                    _helper.MouseOver(_menuPageObject.SubMenuLinks[i]);  // ? Hover Sub Menu
                }
            }
        }

        foreach (var item in _menuPageObject.MainMenuLinks)  // ? Get Main Menu Links
            links.Add(item.GetAttribute("href"));

        foreach (var item in _menuPageObject.SubMenuLinks) // ? Get Sub Menu Links
            links.Add(item.GetAttribute("href"));

        foreach (var item in _menuPageObject.SubMenuItemsLinks) // ? Get Sub Menu Items Links
            links.Add(item.GetAttribute("href"));

        foreach (var item in _menuPageObject.SubMenuItemsLinks2) // ? Get Sub Menu Items Links (Defined in 2 different places)
            links.Add(item.GetAttribute("href"));
    }

    public void VerifyLinks()
    {
        List<string> uniqueMenuLinks = new List<string>();
        uniqueMenuLinks = links.
                            Where(s => !string.IsNullOrWhiteSpace(s)).
                            Distinct().ToList();   // ? empty and same data is cleared


        foreach (var item in uniqueMenuLinks)
        {
            Assert.AreEqual(_helper.IsLinkBroken(item), "link is not broken");
        }
    }
}
