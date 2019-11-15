using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RnD.Apps.DataTablesWrapper
{
    public static class DataTablesResponse
    {
        public static object CreateResponse(DataTablesRequest request, int totalRecord, int totalDisplayRecord, List<object> dataList)
        {

            string[] data = dataList.ConvertAll(x => x.ToString()).ToArray();

            return new
            {
                sEcho = request.sEcho,
                iTotalRecords = totalRecord,
                iTotalDisplayRecords = totalDisplayRecord,
                aaData = data
            };
        }

        public static object CreateResponse(DataTablesRequest request, int totalRecord, int totalDisplayRecord, string[] data)
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