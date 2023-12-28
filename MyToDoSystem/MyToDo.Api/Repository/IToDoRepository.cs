using MyToDo.Api.Context;

namespace MyToDo.Api.Repository
{
    public interface IToDoRepository
    {
        Task<bool> Add(ToDo toDo);
        Task<bool> Update(ToDo toDo);
        Task<bool> Delete(int id);
    }

    public class ToDoRepository : IToDoRepository
    {
        private readonly MyToDoContext _context;

        public ToDoRepository(MyToDoContext context)
        {
            _context = context;
        }

        public Task<bool> Add(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
