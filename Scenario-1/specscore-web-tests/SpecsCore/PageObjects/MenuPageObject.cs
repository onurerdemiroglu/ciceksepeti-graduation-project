using System.Collections.ObjectModel;
using OpenQA.Selenium;

public class MenuPageObject
{
    public IWebElement SortDropDown => Driver.get().FindElement(MenuPageLocators.SortDropDown);
    public IWebElement AddressSearchButton => Driver.get().FindElement(MenuPageLocators.AddressSearchButton);
    public IWebElement AddressSearchInput => Driver.get().FindElement(MenuPageLocators.AddressSearchInput);
    public IWebElement ProductCount => Driver.get().FindElement(MenuPageLocators.ProductCount);
    public IWebElement OldProductPrice => Driver.get().FindElement(MenuPageLocators.OldProductPrice);
    public ReadOnlyCollection<IWebElement> AddressResults => Driver.get().FindElements(MenuPageLocators.AddressResults);
    public ReadOnlyCollection<IWebElement> ProductArray => Driver.get().FindElements(MenuPageLocators.ProductArray);
    public ReadOnlyCollection<IWebElement> MainMenuLinks => Driver.get().FindElements(MenuPageLocators.MainMenuLinks);
    public ReadOnlyCollection<IWebElement> SubMenuLinks => Driver.get().FindElements(MenuPageLocators.SubMenuLinks);
    public ReadOnlyCollection<IWebElement> SubMenuItemsLinks => Driver.get().FindElements(MenuPageLocators.SubMenuItemsLinks);
    public ReadOnlyCollection<IWebElement> SubMenuItemsLinks2 => Driver.get().FindElements(MenuPageLocators.SubMenuItemsLinks2);

    public static class MenuPageLocators
    {
        public static readonly By SortDropDown = By.CssSelector(".js-filter-sort-item");
        public static readonly By AddressSearchButton = By.CssSelector(".district-search-button__text");
        public static readonly By AddressSearchInput = By.CssSelector(".district-search__input");
        public static readonly By AddressResults = By.CssSelector(".district-search__link");
        public static readonly By ProductArray = By.CssSelector(".js-category-item-hover");
        public static readonly By MainMenuLinks = By.CssSelector(".main-menu__link");
        public static readonly By ProductCount = By.CssSelector(".js-order-count");
        public static readonly By SubMenuLinks = By.CssSelector(".js-mega-menu-hover > a");
        public static readonly By OldProductPrice = By.CssSelector(".price--old");
        public static readonly By SubMenuItemsLinks = By.CssSelector(".main-submenu__item.no-more-submenu > a");
        public static readonly By SubMenuItemsLinks2 = By.CssSelector(".main-submenu__item.no-more-sub > a");

    }




}


