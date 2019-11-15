using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.WebCoreApp.DataTablesWrapper
{
    public static class AppDataTablesResponse
    {
        public static object CreateResponse(AppDataTablesRequest request, int totalRecord, int totalDisplayRecord, object dataList)
        {

            //string[] data = dataList.ConvertAll(x => x.ToString()).ToArray();

            string data = (JsonConvert.SerializeObject(new { dataList }));

            return new
            {
                sEcho = request.sEcho,
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = totalDisplayRecord,
                aaData = data
            };
        }

        public static object CreateResponse(AppDataTablesRequest request, int totalRecord, int totalDisplayRecord, string[] data)
        {
            return new
            {
                sEcho = request.sEcho,
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = totalDisplayRecord,
                aaData = data
            };
        }
    }
}
