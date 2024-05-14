using DAL.Interface;
using DAL.Models;
using DAL.Repos;
using System;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin, int, Admin, String> AdminData()
        {
            return new AdminRepo();
        }

        public static SAuth<bool> AdminAuthicateeData()
        {
            return new AdminRepo();
        }

        public static InRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }


    }


}
