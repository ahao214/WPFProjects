using MyToDo.Common.Models;
using System.Collections.ObjectModel;
using MyToDo.Shared.Dtos;
using Prism.Commands;
using Prism.Services.Dialogs;
using MyToDo.Common;
using Prism.Ioc;
using MyToDo.Services;
using Prism.Regions;
using MyToDo.Extensions;

namespace MyToDo.ViewModels
{
    public class IndexViewModel : NavigationViewModel
    {
        private readonly IToDoService toDoService;
        private readonly IMemoService memoService;
        private readonly IDialogHostService dialog;
        private readonly IRegionManager regionManager;

        public IndexViewModel(IContainerProvider provider,
            IDialogHostService dialog) : base(provider)
        {
            Title = $"你好，{AppSession.UserName}，欢迎使用备忘录!{DateTime.Now.GetDateTimeFormats('D')[1].ToString()}";
            CreateTaskBars();
            //TaskBars = new ObservableCollection<TaskBar>();

            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.toDoService = provider.Resolve<IToDoService>();
            this.memoService = provider.Resolve<IMemoService>();
            this.regionManager = provider.Resolve<IRegionManager>();
            _dialog = dialog;
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            EditToDoCommand = new DelegateCommand<ToDoDto>(AddToDo);
            ToDoCompltedCommand = new DelegateCommand<ToDoDto>(Complted);
            NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
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

        private readonly IDialogHostService _dialog;
        private SummaryDto summary;
        /// <summary>
        /// 首页统计
        /// </summary>
        public SummaryDto Summary
        {
            get { return summary; }
            set { summary = value; RaisePropertyChanged(); }
        }

        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }


        #endregion

        #region 模块点击跳转

        private void Navigate(TaskBar obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Target)) return;

            NavigationParameters param = new NavigationParameters();

            if (obj.Title == "已完成")
            {
                param.Add("Value", 2);
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.Target, param);
        }

        #endregion


        #region 完成

        private async void Complted(ToDoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var updateResult = await toDoService.UpdateAsync(obj);
                if (updateResult.Status)
                {
                    var todo = summary.ToDoList.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (todo != null)
                    {
                        summary.ToDoList.Remove(todo);
                        summary.CompletedCount += 1;
                        summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                        this.Refresh();
                    }
                    aggregator.SendMessage("已完成!");
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

        #endregion

        #region 添加
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增待办": AddToDo(null); break;
                case "新增备忘录": AddMemo(null); break;
            }
        }

        #endregion

        #region 新增待办事项

        async void AddToDo(ToDoDto model)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
            {
                param.Add("Value", model);
            }

            var dialog = await _dialog.ShowDialog("AddToDoView", param);
            if (dialog.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);
                    var todo = dialog.Parameters.GetValue<ToDoDto>("Value");
                    if (todo.Id > 0)
                    {
                        var updResult = await toDoService.UpdateAsync(todo);
                        if (updResult.Status)
                        {
                            var todoModel = summary.ToDoList.FirstOrDefault(t => t.Id.Equals(todo.Id));
                            if (todoModel != null)
                            {
                                todoModel.Title = todo.Title;
                                todoModel.Content = todo.Content;
                            }
                        }
                    }
                    else
                    {
                        var addResult = await toDoService.AddAsync(todo);
                        if (addResult.Status)
                        {
                            summary.Sum += 1;
                            summary.ToDoList.Add(addResult.Result);
                            summary.CompletedRatio = (summary.CompletedCount / (double)summary.Sum).ToString("0%");
                            this.Refresh();
                        }
                    }
                }
                finally
                {
                    UpdateLoading(false);
                }
            }
        }

        #endregion


        #region 新增备忘录

        async void AddMemo(MemoDto model)
        {
            DialogParameters param = new DialogParameters();
            if (model != null)
            {
                param.Add("Value", model);
            }

            var dialog = await _dialog.ShowDialog("AddMemoView", param);
            if (dialog.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);
                    var memo = dialog.Parameters.GetValue<MemoDto>("Value");
                    if (memo.Id > 0)
                    {
                        var updResult = await memoService.UpdateAsync(memo);
                        if (updResult.Status)
                        {
                            var memoModel = summary.MemoList.FirstOrDefault(t => t.Id.Equals(memo.Id));
                            if (memoModel != null)
                            {
                                memoModel.Title = memo.Title;
                                memoModel.Content = memo.Content;
                            }
                        }
                    }
                    else
                    {
                        var memoResult = await memoService.AddAsync(memo);
                        if (memoResult.Status)
                        {
                            summary.MemoeCount += 1;
                            summary.MemoList.Add(memoResult.Result);
                            this.Refresh();
                        }
                    }
                }
                finally
                {
                    UpdateLoading(false);
                }
               
            }
        }

        #endregion


        #region 创建左侧菜单

        void CreateTaskBars()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            TaskBars.Add(new TaskBar { Icon = "ClockFast", Title = "汇总", Color = "#FF0CA0FF", Target = "ToDoView" });
            TaskBars.Add(new TaskBar { Icon = "ClockCheckOutline", Title = "已完成", Color = "#FF1ECA3A", Target = "ToDoView" });
            TaskBars.Add(new TaskBar { Icon = "ChartLineVariant", Title = "完成比例", Color = "#FF02C6DC", Target = "" });
            TaskBars.Add(new TaskBar { Icon = "PlaylistStar", Title = "备忘录", Color = "#FFFFA000", Target = "MemoView" });

        }

        #endregion

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var summaryResult = await toDoService.SummaryAsync();
            if (summaryResult.Status)
            {
                Summary = summaryResult.Result;
                Refresh();
            }
            base.OnNavigatedTo(navigationContext);
        }

        void Refresh()
        {
            TaskBars[0].Content = summary.Sum.ToString();
            TaskBars[1].Content = summary.CompletedCount.ToString();
            TaskBars[2].Content = summary.CompletedRatio;
            TaskBars[3].Content = summary.MemoeCount.ToString();
        }

    }
}
