namespace Gachishop;

public interface ICustomInput
{
    string ReadText();
    string ReadPassword();
    int ReadNumber();
}