using TechTalk.SpecFlow;

[Binding]
public class HomeSteps
{
    HomePage _homePage = new HomePage();

    [Given(@"I am on the home page")]
    public void GoToHomePage()
    {
        _homePage.GoToHomePage();
    }

    [When(@"I close the address focus on the home page")]
    public void CloseAdressFocus()
    {
        _homePage.CloseAdressFocus();
    }

    [When(@"I go to login page")]
    public void GoToLoginPage()
    {
        _homePage.GoToLoginPage();
    }

    [Then(@"I should see My Account section")]
    public void CheckAccountSection()
    {
        _homePage.CheckAccountSection();
    }
}