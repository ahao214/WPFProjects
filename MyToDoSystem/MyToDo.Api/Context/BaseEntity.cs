namespace MyToDo.Api.Context
{
    /// <summary>
    /// 基类
    /// </summary>
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }    
        public DateTime UpdateDate { get; set; }
    }
}
