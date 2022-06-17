using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;

namespace Web_project_horse_races_web.Infrastructure.Filters
{
    public class UnbannedUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool userBanState = bool.Parse(context.HttpContext.User.FindFirst(u => u.Type == "banState").Value);
            if(userBanState)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                
            }
        }
    }
}
