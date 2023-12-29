using MyToDo.Services;
using MyToDo.Shared.Dtos;
using MyToDo.Shared.Parameters;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Net;


namespace MyToDo.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        public MemoViewModel(IMemoService service, IContainerProvider provider) : base(provider)
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            SelectedCommand = new DelegateCommand<MemoDto>(Selected);
            DeleteCommand = new DelegateCommand<MemoDto>(Delete);
            _service = service;
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


        public DelegateCommand AddCommand { get; private set; }

        private ObservableCollection<MemoDto> memoDtos;
        private readonly IMemoService _service;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增": Add(); break;
                case "查询": GetDataAsync(); break;
                case "保存": Save(); break;
            }
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<MemoDto> SelectedCommand { get; private set; }
        public DelegateCommand<MemoDto> DeleteCommand { get; private set; }


        #region 删除备忘录
        /// <summary>
        /// 删除备忘录
        /// </summary>
        /// <param name="dto"></param>
        private async void Delete(MemoDto dto)
        {
            try
            {
                UpdateLoading(true);
                var result = await _service.DeleteAsync(dto.Id);
                if (result.Status)
                {
                    var model = MemoDtos.FirstOrDefault(t => t.Id.Equals(dto.Id));
                    if (model != null)
                    {
                        MemoDtos.Remove(model);
                    }
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        #endregion

        #region 添加备忘录

        /// <summary>
        /// 添加备忘录
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Add()
        {
            CurrentDto = new MemoDto();
            IsRightDrawerOpen = true;
        }

        #endregion

        #region 保存备忘录
        /// <summary>
        /// 保存备忘录
        /// </summary>
        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
                string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;

            UpdateLoading(true);

            try
            {
                if (CurrentDto.Id > 0)
                {
                    var updateResult = await _service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var todo = MemoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                        }
                    }
                    IsRightDrawerOpen = false;
                }
                else
                {
                    var addResult = await _service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        MemoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        #endregion

        #region 搜索条件

        private string search;
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Search
        {
            get { return search; }
            set { search = value; }
        }

        #endregion

        #region 选中MemoDto事项的事件

        private MemoDto currentDto;

        /// <summary>
        /// 编辑选中/新增时对象
        /// </summary>
        public MemoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 选中ToDo事项的事件
        /// </summary>
        /// <param name="obj"></param>
        private async void Selected(MemoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var todoResult = await _service.GetFirstOrDefaultAsync(obj.Id);
                if (todoResult.Status)
                {
                    CurrentDto = todoResult.Result;
                    IsRightDrawerOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取数据
        /// </summary>
        async void GetDataAsync()
        {
            UpdateLoading(true);

            var todoResult = await _service.GetAllAsync(new ToDoParameter()
            {
                PageIndex = 0,
                PageSize = 100,
                Search = Search                
            });

            if (todoResult.Status)
            {
                MemoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    MemoDtos.Add(item);
                }
            }
            UpdateLoading(false);
        }

        #endregion

        #region 导航数据

        /// <summary>
        /// 导航数据
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetDataAsync();
        }

        #endregion


    }
}
