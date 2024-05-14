using DAL.Models;

namespace DAL.Repos
{
    internal class Repo
    {
        protected EContext db;
        protected Repo()
        {
            db = new EContext();
        }
    }
}
