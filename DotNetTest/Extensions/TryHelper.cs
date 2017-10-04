using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Task<Try<Exception, TSuccess>> TryAsync<TSuccess, TContext>(this TContext context, Func<TContext, TSuccess> @try)
        {
            var task = new Task<Try<Exception, TSuccess>>(() =>
            {
                try
                {
                    return @try(context);
                }
                catch (Exception ex)
                {
                    return ex;
                }
            });
            task.Start();
            return task;
        }

        public static Operation<TResult, TContext, TFail, TSuccess> OnFail<TResult, TContext, TFail, TSuccess>(this Try<TFail, TSuccess> @try, TContext context, Func<TContext, TFail, TResult> fail)
        {
            return new Operation<TResult, TContext, TFail, TSuccess>(context, @try, fail);
        }
        
        public static Operation<Task<TResult>, TContext, Exception, TResult> ThrowAsync<TResult, TContext>(this Try<Exception, TResult> @try, TContext context)
        {
            
            return new Operation<Task<TResult>, TContext, Exception, TResult>(context, @try, (ctx, ex) => 
            {
                var task = new Task<TResult>(() =>
                {
                    if (!(ex is Exception))
                        throw new Exception("Uso inválido do método TryHelper.ThrowAsync. O mesmo só pode ser utilizado para relançar falhas do tipo Exceção");
                    throw (Exception)(object)ex;
                });
                task.Start();
                return task;
            });
        }
    }
}
