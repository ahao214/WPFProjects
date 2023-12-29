using Prism.Services.Dialogs;
using System.Windows.Ink;

namespace MyToDo.ViewModels.Dialogs
{
    /// <summary>
    /// ToDo对话框
    /// </summary>
    public class AddToDoViewModel : IDialogAware
    {
        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
