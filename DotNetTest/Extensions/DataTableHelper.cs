using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTest.Extensions
{
    public static class DataTableCollection
    {
        public static DataTable Filter(this DataTable dataSource, Func<DataRow, bool> filter)
        {
            DataTable dt = dataSource.Clone();
            dataSource.Rows.Cast<DataRow>().Where(filter).CopyToDataTable(dt, LoadOption.Upsert);
            return dt;
        }

        public static Task<DataTable> FilterAsync(this DataTable dataSource, Func<DataRow, bool> filter, params string[] columnsToRemove)
        {
            //return TryHelper.TryAsync(dataSource, (ctx) =>
            //{
            //    DataTable dt = dataSource.Clone();
            //    dataSource.Rows.Cast<DataRow>().Where(filter).CopyToDataTable(dt, LoadOption.Upsert);
            //    if (columnsToRemove?.Length == 0)
            //        return dt;
            //    foreach (var column in columnsToRemove)
            //        dt.Columns.Remove(column);
            //    return dt;

            //});

            Task<DataTable> task = new Task<DataTable>(() =>
            {
                DataTable dt = dataSource.Clone();
                dataSource.Rows.Cast<DataRow>().Where(filter).CopyToDataTable(dt, LoadOption.Upsert);
                if (columnsToRemove?.Length == 0)
                    return dt;
                foreach (var column in columnsToRemove)
                    dt.Columns.Remove(column);
                return dt;
            });
            task.Start();
            return task;
        }
    }
}
