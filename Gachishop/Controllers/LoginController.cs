namespace Gachishop.Controllers;

public class LoginController
{
    private ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }
    
    public User AuthorizedUser { get; set; }
    public void Login()
    {
        while(true)
        {
            Console.WriteLine("Enter username:");
            string name = CustomInput.ReadText();
            Console.WriteLine("Enter password:");
            string password = CustomInput.ReadPassword();
            
            User user = _loginService.FindUser(name, password);
            
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("Wrong name or password");
            }
            else
            {
                AuthorizedUser = user;
                return;
            }
        }
    }
}