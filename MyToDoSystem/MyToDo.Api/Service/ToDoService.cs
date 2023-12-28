using MyToDo.Api.Context;
using MyToDo.Shared.Parameters;

namespace MyToDo.Api.Service
{
    /// <summary>
    /// 待办事项的实现
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _work;

        public ToDoService(IUnitOfWork work)
        {
            _work = work;
        }

        public async Task<ApiResponse> AddAsync(ToDo model)
        {
            try
            {
                await _work.GetRepository<ToDo>().InsertAsync(model);
                if (await _work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, model);
                return new ApiResponse("添加数据失败");
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message);
            }

        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var repository = _work.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));

                repository.Delete(todo);
                if (await _work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, "");
                return new ApiResponse("删除数据失败");
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message);
            }
        }

        public async Task<ApiResponse> GetAllAsync(QueryParameter query)
        {
            try
            {
                var repository = _work.GetRepository<ToDo>();
                var todos = await repository.GetAllAsync();

                return new ApiResponse(true, todos);
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message);
            }
        }

        public Task<ApiResponse> GetAllAsync(ToDoParameter query)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> GetSingleAsync(int id)
        {
            try
            {
                var repository = _work.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(id));

                return new ApiResponse(true, todo);
            }
            catch (Exception ex)
            {

                return new ApiResponse(ex.Message);
            }
        }

        public Task<ApiResponse> Summary()
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> UpdateAsync(ToDo model)
        {
            try
            {
                var repository = _work.GetRepository<ToDo>();
                var todo = await repository.GetFirstOrDefaultAsync(predicate: x => x.Id.Equals(model.Id));

                todo.Title = model.Title;
                todo.Content = model.Content;
                todo.Status = model.Status;
                todo.UpdateDate = DateTime.Now;

                repository.Update(todo);

                if (await _work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, todo);
                return new ApiResponse("更新数据失败");
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message);
            }
        }
    }
}
