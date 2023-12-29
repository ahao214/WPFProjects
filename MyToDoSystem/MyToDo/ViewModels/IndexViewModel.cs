using Prism.Mvvm;
using MyToDo.Common.Models;
using System.Collections.ObjectModel;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Services.Dialogs;
using MyToDo.Common;
using Prism.Ioc;
using MyToDo.Services;
using Prism.Regions;
using System.Numerics;
using MyToDo.Extensions;

namespace MyToDo.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;
        private readonly IDialogHostService dialog;
        //private readonly IRegionManager regionManager;
        public IndexViewModel(IContainerProvider provider,
            IDialogHostService dialog) : base(provider)
        {
            CreateTaskBars();
            //TaskBars = new ObservableCollection<TaskBar>();
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();

            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.toDoService = provider.Resolve<IToDoService>();
            this.memoService = provider.Resolve<IMemoService>();
            //this.regionManager = provider.Resolve<IRegionManager>();
            _dialog = dialog;
            //EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            //EditToDoCommand = new DelegateCommand<ToDoDto>(AddToDo);
            //ToDoCompltedCommand = new DelegateCommand<ToDoDto>(Complted);
            //NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
        }

        private void Navigate(TaskBar obj)
        {
            //if (string.IsNullOrWhiteSpace(obj.Target)) return;

            //NavigationParameters param = new NavigationParameters();

            //if (obj.Title == "已完成")
            //{
            //    param.Add("Value", 2);
            //}
            //regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Target, param);
        }

        private async void Complted(ToDoDto obj)
        {
            //try
            //{
            //    UpdateLoading(true);
            //    var updateResult = await toDoService.UpdateAsync(obj);
            //    if (updateResult.Status)
            //    {
            //        var todo = summary.ToDoList.FirstOrDefault(t => t.Id.Equals(obj.Id));
            //        if (todo != null)
            //        {
            //            summary.ToDoList.Remove(todo);
            //            summary.CompletedCount += 1;
            //            summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
            //            this.Refresh();
            //        }
            //        aggregator.SendMessage("已完成!");
            //    }
            //}
            //finally
            //{
            //    UpdateLoading(false);
            //}
        }



        #region 属性

        public DelegateCommand<ToDoDto> ToDoCompltedCommand { get; private set; }
        public DelegateCommand<ToDoDto> EditToDoCommand { get; private set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; private set; }
        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public DelegateCommand<TaskBar> NavigateCommand { get; private set; }

        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MemoDto> memoDtos;
        private readonly IDialogHostService _dialog;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }
        #endregion


        #region 添加
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增待办": AddToDo(); break;
                case "新增备忘录": AddMemo(); break;
            }
        }

        #endregion





        #region 新增待办事项

        async void AddToDo()
        {
            var dialog = await _dialog.ShowDialog("AddToDoView", null);
            if (dialog.Result == ButtonResult.OK)
            {
                var todo = dialog.Parameters.GetValue<ToDoDto>("Value");
                if (todo.Id > 0)
                {

                }
                else
                {
                    var addResult = await toDoService.AddAsync(todo);
                    if (addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                    }
                }
            }
        }

        #endregion


        #region 新增备忘录

        async void AddMemo()
        {
            var dialog = await _dialog.ShowDialog("AddMemoView", null);
            if (dialog.Result == ButtonResult.OK)
            {
                var memo = dialog.Parameters.GetValue<MemoDto>("Value");
                if (memo.Id > 0)
                {

                }
                else
                {
                    var memoResult = await memoService.AddAsync(memo);
                    if (memoResult.Status)
                    {
                        MemoDtos.Add(memoResult.Result);
                    }
                }
            }
        }

        #endregion


        #region 创建左侧菜单

        void CreateTaskBars()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            TaskBars.Add(new TaskBar { Icon = "ClockFast", Title = "汇总", Content = "9", Color = "#FF0CA0FF", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ClockCheckOutline", Title = "已完成", Content = "9", Color = "#FF1ECA3A", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "ChartLineVariant", Title = "完成比例", Content = "100%", Color = "#FF02C6DC", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "PlaylistStar", Title = "备忘录", Content = "19", Color = "#FFFFA000", Target = "" });

        }

        #endregion


    }
}
