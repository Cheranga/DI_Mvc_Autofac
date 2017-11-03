
### Using Autofac with MVC5 and Owin
This MVC5 application will use Autofac for injecting dependencies including, for identity components.
This exercise is based on this [article](https://developingsoftware.com/configuring-autofac-to-work-with-the-aspnet-identity-framework-in-mvc-5/)

### Steps
- [x] Install required Autofac packages
   - `Install-Package Autofac.Mvc5`
   - `Install-Package Autofac.Mvc5.Owin`

- [x] Create a custom "UserStore"
   - `ApplicationUserStore class`.

- [x] Register dependencies through Autofac
   - Comment out the `Startup.Auth -> ConfigureAuth method`, which creates `ApplicationDbContext`, `ApplicationUserManager` and `ApplicationSignInManager` instances.
   - Modify the `AccountController` to have only one constructor and it to accept `ApplicationUserManager`, `ApplicationSignInManager` and `IAuthenticationManager` instances from DI.
Then modify the corresponding properties to get them from these injected instances instead of doing service locator.
   - Finally comment out the `Dispose` method. Autofac will handle the disposing of the registered resources.

- [x] Adding Web API2 to the existing MVC application
   - `Install-Package Microsoft.AspNet.WebApi`
   - `Install-Package Microsoft.AspNet.WebApi.Client`
   - `Install-Package Microsoft.AspNet.WebApi.Core`
   - `Install-Package Microsoft.AspNet.WebApi.WebHost`

- [x] Modifying the RouteConfig (Web API routing must be registered before the MVC routes)




