using System.Collections.ObjectModel;
using OpenQA.Selenium;

public class MenuPageObject
{
    public IWebElement SortDropDown => Driver.get().FindElement(MenuPageLocators.SortDropDown);
    public IWebElement AddressSearchButton => Driver.get().FindElement(MenuPageLocators.AddressSearchButton);
    public IWebElement AddressSearchInput => Driver.get().FindElement(MenuPageLocators.AddressSearchInput);
    public ReadOnlyCollection<IWebElement> AddressResults => Driver.get().FindElements(MenuPageLocators.AddressResults);
    public ReadOnlyCollection<IWebElement> ProductArray => Driver.get().FindElements(MenuPageLocators.ProductArray);

    public static class MenuPageLocators
    {
        public static readonly By SortDropDown = By.CssSelector(".js-filter-sort-item");
        public static readonly By AddressSearchButton = By.CssSelector(".district-search-button__text");
        public static readonly By AddressSearchInput = By.CssSelector(".district-search__input");
        public static readonly By AddressResults = By.CssSelector(".district-search__link");
        public static readonly By ProductArray = By.CssSelector(".js-category-item-hover");

    }



}


