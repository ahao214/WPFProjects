using CourseManager.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.ViewModel
{
    public class FirstPageViewModel : NotifyBase
    {
        private int _instrumentValue { get; set; }

        public int InstrumentValue
        {
            get { return _instrumentValue; }
            set { _instrumentValue = value; this.DoNofity(); }
        }

        Random rand = new Random();
        bool taskSwitch = true;
        List<Task> listTask = new List<Task>();
        public FirstPageViewModel()
        {
            this.RefreshInstrumentValue();
        }

        private void RefreshInstrumentValue()
        {
            var task = Task.Factory.StartNew(new Action(async () =>
             {
                 while (taskSwitch)
                 {
                     InstrumentValue = rand.Next(Math.Max(this.InstrumentValue - 5, -10), Math.Min(this.InstrumentValue + 5, 90));
                     await Task.Delay(1000);
                 }
             }));
            listTask.Add(task);
        }

        public void Dispose()
        {
            try
            {
                taskSwitch = false;
                Task.WaitAll(this.listTask.ToArray());
            }
            catch 
            {

            }
        }

    }

}