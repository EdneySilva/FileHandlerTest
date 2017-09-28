using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Extensions
{
    public static class TryHelper
    {
        public static Try<Exception, TSuccess> Try<TSuccess, TContext>(this TContext context, Func<TContext, TSuccess> @try)
        {
            try
            {
                return @try(context);
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Operation<TResult, TContext, TFail, TSuccess> OnFail<TResult, TContext, TFail, TSuccess>(this Try<TFail, TSuccess> @try, TContext context, Func<TContext, TFail, TResult> fail)
        {
            return new Operation<TResult, TContext, TFail, TSuccess>(context, @try, fail);
        }
    }
}
