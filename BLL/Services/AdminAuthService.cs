using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;

namespace BLL.Services
{
    public class AdminAuthService
    {

        public static TokenDTO Authenticatee(string Email, string password)
        {
            var res = DataAccessFactory.AdminAuthicateeData().Authenticatee(Email, password);

            if (res)
            {
                var userId = DataAccessFactory.AdminData().Reademail(Email);


                if (userId != null)
                {


                    var token = new Token();
                    token.UserId = userId.Email.ToString();
                    token.CreatedAt = DateTime.Now;
                    token.TKey = Guid.NewGuid().ToString();

                    var ret = DataAccessFactory.TokenData().create(token);

                    if (ret != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });

                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(ret);
                    }

                }

            }


            return null;
        }
        public static bool IsTokenValid(string tkey)
        {

            var extk = DataAccessFactory.TokenData().get(tkey);
            if (extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().get(tkey);
            extk.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().update(extk) != false)
            {
                return true;
            }
            return false;
        }
    }
}

