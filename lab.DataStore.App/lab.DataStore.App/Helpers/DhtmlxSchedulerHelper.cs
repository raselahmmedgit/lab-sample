using lab.DataStore.App.Helper;
using log4net;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Helpers
{
    public class DhtmlxSchedulerHelper
    {
        #region Global Variable Declaration
        private readonly IHostingEnvironment _iHostingEnvironment;
        private readonly string _fileName = "DhtmlxSchedulerJson.txt";
        private readonly ILog _log;
        #endregion

        #region Constructor
        public DhtmlxSchedulerHelper(IHostingEnvironment iHostingEnvironment)
        {
            _iHostingEnvironment = iHostingEnvironment;
            _log = LogManager.GetLogger(typeof(DhtmlxSchedulerHelper));
        }
        #endregion

        #region Actions

        private List<DhtmlxSchedulerViewModel> GetDhtmlxSchedulers()
        {
            List<DhtmlxSchedulerViewModel> dhtmlxSchedulerViewModelList = new List<DhtmlxSchedulerViewModel>();
            try
            {
                string filePath = $"{_iHostingEnvironment.WebRootPath}\\js\\{_fileName}";
                if (File.Exists(filePath))
                {
                    var jsonText = File.ReadAllText(filePath);
                    var viewModelList = JsonConvert.DeserializeObject<IList<DhtmlxSchedulerViewModel>>(jsonText);
                    dhtmlxSchedulerViewModelList = viewModelList.ToList();
                }
            }
            catch (Exception ex)
            {
                _log.Error(Log4NetMessageHelper.FormateMessageForException(ex, "GetDhtmlxSchedulerData"));
            }

            return dhtmlxSchedulerViewModelList;
        }

        private List<object> GetDhtmlxSchedulerSections()
        {
            var dhtmlxSchedulers = GetDhtmlxSchedulers();
            var sections = new List<object>();
            dhtmlxSchedulers.ForEach(x => {
                sections.Add(new { key = x.id, label = string.Format("Section #: {0}", x.id) });
            });
            return sections;
        }

        private List<object> GetDhtmlxSchedulerItems()
        {
            var dhtmlxSchedulers = GetDhtmlxSchedulers();
            var items = new List<object>();
            dhtmlxSchedulers.ForEach(x => {
                items.Add(new
                {
                    id = x.id,
                    text = string.Format("Item #: {0} - {1}", x.id, x.text),
                    start_date = x.start_date,
                    end_date = x.end_date,
                    section_id = x.id
                });
            });
            return items;
        }

        public DhtmlxSchedulerTimelineViewModel GetDhtmlxSchedulerData()
        {
            var sections = GetDhtmlxSchedulerSections();
            var items = GetDhtmlxSchedulerItems();
            var data = new DhtmlxSchedulerTimelineViewModel() { sections = sections, items = items, date = DateTime.UtcNow.ToString()};
            return data;
        }

        #endregion
    }

    public class DhtmlxSchedulerTimelineViewModel
    {
        public string date { get; set; }
        public List<object> sections { get; set; }
        public List<object> items { get; set; }
    }

    public class DhtmlxSchedulerViewModel
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
    }
    
}
