namespace Token.Models.JWT
{
    public interface IJWT
    {
        string Authenticate(string username, string password);
    }
}
