using System.Xml;
using System.Data;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

[Binding]
public class LoginSteps
{
    LoginPage _loginPage = new LoginPage();


    [When(@"I logged in with the following data:")]
    public void Login(Table table)
    {
        _loginPage.Login(table.Rows[0][0].ToString(), table.Rows[0][1].ToString());
    }

    [When(@"I click the Guest Checkout")]
    public void ClickTheGuestCheckout()
    {
        _loginPage.ClickTheGuestCheckout();
    }


}