using Microsoft.AspNetCore.Builder;
using System.IO;
using System.Net;

namespace BlogApplication
{
  public static class SpaRoutingMiddleware
  {
    public static void UseSpaRoutingMiddleware(this IApplicationBuilder app)
    {
      app.Use(async (context, next) =>
      {
        await next();
        if ((context.Response.StatusCode == (int)HttpStatusCode.NotFound) && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api"))
        {
          context.Request.Path = "/index.html";
          context.Response.StatusCode = (int)HttpStatusCode.OK;
          await next();
        }
      });
    }
  }
}
