using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Shared.Parameters
{
    public class ToDoParameter : QueryParameter
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        public int? Status { get; set; }
    }
}
