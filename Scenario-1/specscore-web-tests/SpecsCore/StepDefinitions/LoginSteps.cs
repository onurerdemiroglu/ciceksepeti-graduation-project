using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

[Binding]
public class LoginSteps
{
    LoginPage _loginPage = new LoginPage();


    [When(@"I logged in with the following data:")]
    public void Login(Table table)
    {
        var user = table.CreateInstance<(string mail, string password)>();

        _loginPage.Login(user.mail, user.password);
    }

    [When(@"I click the Guest Checkout")]
    public void ClickTheGuestCheckout()
    {
        _loginPage.ClickTheGuestCheckout();
    }


}