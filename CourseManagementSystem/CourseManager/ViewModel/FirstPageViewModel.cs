using CourseManager.Common;
using CourseManager.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<CourseSeriesModel> CourseSeriesList { get; set; } = new ObservableCollection<CourseSeriesModel>();


        Random rand = new Random();
        bool taskSwitch = true;
        List<Task> listTask = new List<Task>();
        public FirstPageViewModel()
        {
            this.RefreshInstrumentValue();
            this.InitCourseSeries();
        }

        private void InitCourseSeries()
        {
            CourseSeriesList.Add(new CourseSeriesModel
            {
                CourseName = "VIP Class",
                SeriesColection = new LiveCharts.SeriesCollection { new PieSeries {
                    Title="Joker",
                    Values=new ChartValues<ObservableValue>{ new ObservableValue(123)},
                    DataLabels=false},new PieSeries {
                    Title="Joker",
                    Values=new ChartValues<ObservableValue>{ new ObservableValue(123)},
                    DataLabels=false}
                },
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="云课堂",CurrentValue=15,IsGrowing=false,ChangeRate=89},
                    new SeriesModel{SeriesName="计算机",CurrentValue=15,IsGrowing=false,ChangeRate=89},
                    new SeriesModel{SeriesName="计算机",CurrentValue=15,IsGrowing=false,ChangeRate=89},
                    new SeriesModel{SeriesName="计算机",CurrentValue=15,IsGrowing=false,ChangeRate=89},
                    new SeriesModel{SeriesName="计算机",CurrentValue=15,IsGrowing=false,ChangeRate=89},
                }
            });
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