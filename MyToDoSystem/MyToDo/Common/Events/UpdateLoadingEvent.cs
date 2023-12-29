using Prism.Events;

namespace MyToDo.Common.Events
{

    public class UpdateModel
    {
        public bool IsOpen { get; set; }
    }

    /// <summary>
    /// 登录Event
    /// </summary>
    public class UpdateLoadingEvent : PubSubEvent<UpdateModel>
    {
    }
}
