﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetTest.Extensions
{
    public static class GridViewHelper
    {
        public static void DataSourceAsync<T>(this DataGridView grid, Task<Try<Exception, T>> asyncDataSource)
        {
            Task runner = new Task(() =>
            {
                asyncDataSource.Result.OnFail(grid, (ctx, ex) =>
                {
                    ctx.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show(ex.Message, "Ops! Ocorreu um erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                    return false;
                }).OnSuccess((ctx, result) =>
                {
                    ctx.BeginInvoke(new Action(() =>
                    {
                        ctx.DataSource = result; ;
                        ctx.Refresh();
                    }));
                    return true;
                });
            });
            runner.Start();
        }
        public static void DataSourceAsync<T>(this DataGridView grid, Task<T> asyncDataSource)
        {
            Task runner = new Task(() =>
            {
                asyncDataSource.Wait();

                grid.BeginInvoke(new Action(() =>
                {
                    grid.DataSource = asyncDataSource.Result;
                    grid.Refresh();
                }));
            });
            runner.Start();
        }
    }
}
