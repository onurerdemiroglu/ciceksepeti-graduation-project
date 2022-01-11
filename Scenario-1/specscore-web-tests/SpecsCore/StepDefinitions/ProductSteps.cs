using System.Reflection;
using System.Xml;
using System.Data;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.NUnit;
using TechTalk.SpecFlow.Infrastructure;
using OpenQA.Selenium;

[Binding]
public class ProductSteps
{
    ProductPage _productPage = new ProductPage();
    Helper _helper = new Helper();

    [When(@"I add product to basket")]
    public void AddProductToBasket()
    {
        _productPage.AddProductToBasket();
    }

    [Then(@"I customize the product")]
    public void CustomizeTheProduct()
    {
        _productPage.CustomizeTheProduct();
    }



    [Given(@"I open the '(.*)' url")]
    public void OpenTheUrl(string searchKey)
    {
        _helper.GoToUrl(searchKey);
    }




}