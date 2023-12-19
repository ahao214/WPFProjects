using Joker.SmartPacking.Server.IService;
using Joker.SmartPacking.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            var users = _loginService.Query<SysUserInfo>(u => u.UserName == username && u.Password == password);
            if (users?.Count() > 0)
            {
                var userInfo = users.ToList();
                SysUserInfo sysUserInfo = userInfo[0];

                // 菜单

                return Ok(sysUserInfo);
            }
            else
            {
                return NoContent();
            }
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
