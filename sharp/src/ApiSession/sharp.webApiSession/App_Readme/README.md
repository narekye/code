Install-Package Ninject.Web.WebApi 
For additional info click this [link](http://nodogmablog.bryanhogan.net/2016/04/web-api-2-and-ninject-how-to-make-them-work-together/)
## NOTE this will install 
**Ninject** and **Ninject.Web.Common** package.

After all need to install this.

Install-Package Ninject.Web.Common.WebHost

That will add a reference to WebActivatorEx package.

Look at solution explorer, there will be a App_Start folder which includes `NinjectWebCommon.cs` file.

Register some services.

Example.

```c#
private static void RegisterServices(IKernel kernel)
{
    kernel.Bind<ICaclulator>().To<Caclulator>();
}
```


And finnaly use it all.
```c#
public class ValuesController : ApiController
{
    private readonly ICaclulator _caclulator;
    public ValuesController(ICaclulator calculator)
    {
        _caclulator = calculator;
    }
 
    public int Get(int num1, int num2)
    {
        return _caclulator.Add(num1, num2);
    }
}
```
Dont forget about ` HttpConfiguration ` in Owin startup class.
```c# 
private void ConfigureWebApi(HttpConfiguration config)
{
     config.DependencyResolver = new NinjectDependencyResolver(new Bootstrapper().Kernel);
     config.MapHttpAttributeRoutes();
     config.Routes.MapHttpRoute(
          name: "default",
          routeTemplate: "api/{controller}/{action}",
          defaults: new { action = RouteParameter.Optional }
      );
}
```