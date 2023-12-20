using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joker.SmartPacking.Server.Models
{
    /// <summary>
    /// 用户
    /// </summary>    
    [Table("sys_user_info")]
    public class SysUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int UserId { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("user_icon")]
        public string UserIcon { get; set; }

    }


}
