using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CourseSeriesModel
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        public SeriesCollection SeriesColection { get; set; }

        public ObservableCollection <SeriesModel> SeriesList { get; set; }
    }
}
