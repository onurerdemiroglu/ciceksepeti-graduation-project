


public class LoginPage
{
    Helper _helper = new Helper();
    LoginPageObject _loginPageObject = new LoginPageObject();

    public void Login(string email, string pass)
    {
        _helper.SendKeysElement(_loginPageObject.EmailField, email);
        _helper.SendKeysElement(_loginPageObject.PasswordField, pass);
        _helper.ClickElement(_loginPageObject.SubmitButton);
    }

    public void ClickTheGuestCheckout()
    {
        _helper.ClickElement(_loginPageObject.GuestCheckOut);
    }

}