using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DI_Mvc_Autofac.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DI_Mvc_Autofac
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {
        }
    }
}