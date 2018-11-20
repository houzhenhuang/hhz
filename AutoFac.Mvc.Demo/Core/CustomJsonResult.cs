using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoFac.Mvc.Demo.Core
{
    public class CustomJsonResult : JsonResult
    {
        public string FormateStr { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data != null)
            {
                IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
                timeFormat.DateTimeFormat = FormateStr?? "yyyy-MM-dd HH:mm:ss";
                string jsonString = JsonConvert.SerializeObject(this.Data, Formatting.Indented, timeFormat);//数据，缩进，格式
                response.Write(jsonString);
            }
        }
    }
}