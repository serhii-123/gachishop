namespace Gachishop
{
    public interface ILoginService
    {
        IUser AuthorizedUser { get; set; }
        void Login();
    }
}