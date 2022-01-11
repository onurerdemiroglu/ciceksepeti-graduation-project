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
public class OrderSteps
{
    OrderPage _orderPage = new OrderPage();
    Helper _helper = new Helper();

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




}