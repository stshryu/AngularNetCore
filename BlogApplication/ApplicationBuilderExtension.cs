using Microsoft.AspNetCore.Builder;

namespace BlogApplication
{
  public static class ApplicationBuilderExtension
  {
    public static void UseAngular(this IApplicationBuilder app)
    {
      //app.UseBrowserLink();
      app.UseDeveloperExceptionPage();
      app.UseSpaRoutingMiddleware();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
    }
  }
}
