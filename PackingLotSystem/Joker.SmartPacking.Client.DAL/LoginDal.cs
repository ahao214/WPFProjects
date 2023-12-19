using Joker.SmartPacking.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Joker.SmartPacking.Client.DAL
{
    public class LoginDal : WebDataAccess, ILoginDal
    {
        public Task<string> Login(string username, string password)
        {
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("username", new StringContent(username));
            contents.Add("password", new StringContent(password));

            return this.PostDatas("user/login", contents);
        }
    }
}
