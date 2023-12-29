
using MyToDo.Shared.Dtos;

namespace MyToDo.Services
{
    public class ToDoService : BaseService<ToDoDto>,IToDoService
    {
        public ToDoService(HttpRestClient client):base(client,"ToDo")
        {
            
        }

    }
}
