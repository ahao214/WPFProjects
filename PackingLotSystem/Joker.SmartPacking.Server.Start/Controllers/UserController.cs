using Joker.SmartPacking.Server.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Joker.SmartPacking.Server.Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILoginService _loginService;
        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("login")]
        public string Login([FromForm] string username, [FromForm] string password)
        {

            return "kuteng";
        }

        #region MD5 加密
        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string GetMd5Str(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            byte[] result = Encoding.Default.GetBytes(str);
            MD5 md = new MD5CryptoServiceProvider();
            byte[] output = md.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");

        } 
        #endregion
    }
}
