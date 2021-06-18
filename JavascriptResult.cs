using Microsoft.AspNetCore.Mvc;

namespace Holodeck
{
    public class JavascriptResult : ContentResult
        {
            public JavascriptResult(string script)
            {
                Content = script;
                ContentType = "application/javascript; charset=UTF-8";
            }
        }
 
}