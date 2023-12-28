namespace MyToDo.Api.Context
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class User: BaseEntity
    {
        public string Account {  get; set; }    

        public string UserName { get; set; }    

        public string Password { get; set; }    

    }
}
