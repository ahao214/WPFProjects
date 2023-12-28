using MyToDo.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using MyToDo.Shared.Dtos;

namespace MyToDo.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        public ToDoViewModel(IToDoService service)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();           
            AddCommand = new DelegateCommand(Add);
            _service = service;
            CreateToDoList();
        }

        private bool isRightDrawerOpen;
        /// <summary>
        /// 右侧编辑窗口是否展开
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加待办事项
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Add()
        {
            IsRightDrawerOpen = true;
        }

        public DelegateCommand AddCommand { get; private set; }

        private ObservableCollection<ToDoDto> toDoDtos;
        private readonly IToDoService _service;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }


        async void CreateToDoList()
        {
            var todoResult = await _service.GetAllAsync(new Shared.Parameters.QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100
            });

            if (todoResult.Status)
            {
                foreach (var item in todoResult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
            }
        }
    }
}
