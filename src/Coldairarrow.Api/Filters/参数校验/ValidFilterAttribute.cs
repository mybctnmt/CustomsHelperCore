using Coldairarrow.Util;
using Coldairarrow.Util.Primitives;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Coldairarrow.Api
{
    public class ValidFilterAttribute : BaseActionFilterAsync
    {
        public override async Task OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var msgList = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);

                if (context.HttpContext.Request.Path.HasValue && context.HttpContext.Request.Path.Value.Contains("QingdaoPort"))
                {
                    QingdaoPortResult res = new QingdaoPortResult
                    {
                        success = false,
                        message = string.Join(",", msgList),
                    };
                    context.Result = JsonContent(res.ToJson());
                }
                else
                {
                    context.Result = Error(string.Join(",", msgList));
                }
            }

            await Task.CompletedTask;
        }
    }
}
