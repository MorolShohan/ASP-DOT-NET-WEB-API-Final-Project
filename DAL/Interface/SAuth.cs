namespace DAL.Interface
{
    public interface SAuth<Ret>
    {
        Ret Authenticatee(string Email, string password);
    }
}
