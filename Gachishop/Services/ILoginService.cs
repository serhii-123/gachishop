namespace Gachishop;

public interface ILoginService
{
    User FindUser(string name, string password);
}