using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace RnD.Apps.Helpers
{
    public class DataTableHelper
    {
        public static DataTableResult<T> ParseGridData<T>(IQueryable<T> collection, DataTableParamModel requestParams)
        {
            return ReturnGridData<T>(requestParams, ref collection);
        }

        private static DataTableResult<T> ReturnGridData<T>(DataTableParamModel requestParams, ref IQueryable<T> collection)
        {
            List<T> gridData = new List<T>();

            try
            {
                //If only paging
                var skipCollection = collection.Skip(requestParams.iDisplayStart).Take(requestParams.iDisplayLength).ToList().AsQueryable();

                ////If the sort Order is provided perform a sort on the specified column
                //if (requestParams.iSortingCols > 0)
                //{
                //    //var sortCollection = Sort<T>(collection, requestParams.SortOn, requestParams.SortOrd);
                //    var sortCollection = Sort<T>(skipCollection, requestParams.SortOn, requestParams.SortOrd);

                //    //If sort and paging
                //    //gridData = sortCollection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
                //    gridData = sortCollection.ToList();
                //}
                //if (requestParams.FilterField.IsNotEmpty() && requestParams.FilterOperator.IsNotEmpty() && requestParams.FilterValue.IsNotEmpty())
                //{
                //    //var filterCollection = Filter<T>(collection, requestParams.FilterField, requestParams.FilterOperator, requestParams.FilterValue);
                //    var filterCollection = Filter<T>(skipCollection, requestParams.FilterField, requestParams.FilterOperator, requestParams.FilterValue);

                //    //If sort and paging
                //    //gridData = filterCollection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
                //    gridData = filterCollection.ToList();
                //}
                //else
                //{
                //    //If only paging
                //    //gridData = collection.Skip(requestParams.Skip).Take(requestParams.PageSize).ToList();
                //    //gridData = skipCollection.ToList();
                //}
            }
            catch
            {

            }

            return new DataTableResult<T>
            {
                sEcho = requestParams.sEcho,
                aaData = gridData.Count > 0 ? gridData : collection.ToList(),
                iTotalRecords = collection.Count(),
                iTotalDisplayRecords = gridData.Count(),
            };
        }

        private static IQueryable<T> Sort<T>(IQueryable<T> collection, string sortOn, string sortOrd)
        {
            var param = Expression.Parameter(typeof(T));

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortOn), typeof(object)), param);

            switch (sortOrd.ToLower())
            {
                case "asc":
                    return collection.AsQueryable<T>().OrderBy<T, object>(sortExpression);
                default:
                    return collection.AsQueryable<T>().OrderByDescending<T, object>(sortExpression);

            }
        }

        private static IQueryable<T> Filter<T>(IQueryable<T> collection, string filterField, string filterOperator, string filterValue)
        {
            IQueryable<T> filteredCollection = from item in collection select item;

            Func<T, bool> expression = item =>
            {
                var itemValue = item.GetType()
                    .GetProperty(filterField)
                    .GetValue(item, null);

                if (itemValue == null)
                {
                    return false;
                }

                var value = filterValue;
                switch (filterOperator)
                {
                    case "eq":
                        return itemValue.ToString() == value;
                    case "startswith":
                        return itemValue.ToString().StartsWith(value);
                    case "contains":
                        return itemValue.ToString().Contains(value);
                    case "endswith":
                        return itemValue.ToString().EndsWith(value);
                }

                return true;
            };

            filteredCollection = filteredCollection.Where(expression).AsQueryable();

            return filteredCollection;
        }

        public class DataTableResult<T>
        {
            public string sEcho { get; set; }
            public int iTotalRecords { get; set; }
            public int iTotalDisplayRecords { get; set; }
            public IEnumerable<T> aaData { get; set; }
        }
    }
}