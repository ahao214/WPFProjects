using MyToDo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;


namespace MyToDo.ViewModels
{
    public class MemoViewModel: BindableBase
    {
        public MemoViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            CreateToDoList();
            AddCommand = new DelegateCommand(Add);
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

        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }


        void CreateToDoList()
        {
            for (int i = 0; i < 25; i++)
            {
                MemoDtos.Add(new MemoDto
                {
                    Title = "标题" + i,
                    Content = "内容" + i
                });
            }
        }
    }
}
