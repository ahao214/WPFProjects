using MyToDo.Api.Context;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Service
{

    public interface IToDoService:IBaseService<ToDo>
    {
        Task<ApiResponse> GetAllAsync(ToDoParameter query);

        Task<ApiResponse> Summary();
    }
}
