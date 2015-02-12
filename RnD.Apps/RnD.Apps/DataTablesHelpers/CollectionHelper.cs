using RnD.Apps.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace RnD.Apps.DataTablesHelpers
{
    /// <summary>
    /// Contains sorting helpers for In Memory collections.
    /// </summary>
    public static class CollectionHelper
    {
        public static IOrderedEnumerable<TSource> CustomSort<TSource, TKey>(this IEnumerable<TSource> items, SortingDirection direction, Func<TSource, TKey> keySelector)
        {
            if (direction == SortingDirection.Ascending)
            {
                return items.OrderBy(keySelector);
            }

            return items.OrderByDescending(keySelector);
        }

        public static IOrderedEnumerable<TSource> CustomSort<TSource, TKey>(this IOrderedEnumerable<TSource> items, SortingDirection direction, Func<TSource, TKey> keySelector)
        {
            if (direction == SortingDirection.Ascending)
            {
                return items.ThenBy(keySelector);
            }

            return items.ThenByDescending(keySelector);
        }
    }

    public static class InMemoryCategoryRepository
    {
        private static AppDbContext _db = new AppDbContext();
        private static IList<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }

        public static IList<Category> GetCategories(int startIndex,
            int pageSize,
            ReadOnlyCollection<SortedColumn> sortedColumns,
            out int totalRecordCount,
            out int searchRecordCount,
            string searchString)
        {
            var categories = GetAllCategories();

            totalRecordCount = categories.Count;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            searchRecordCount = categories.Count;

            IOrderedEnumerable<Category> sortedCategories = null;
            foreach (var sortedColumn in sortedColumns)
            {
                switch (sortedColumn.PropertyName)
                {
                    case "Name":
                        sortedCategories = sortedCategories == null ? categories.CustomSort(sortedColumn.Direction, cust => cust.Name)
                            : sortedCategories.CustomSort(sortedColumn.Direction, cust => cust.Name);
                        break;
                }
            }

            return sortedCategories.Skip(startIndex).Take(pageSize).ToList();
        }
    }
}