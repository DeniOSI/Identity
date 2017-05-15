using System;
using System.Data.Entity;

namespace WebApplication1.Models
{
    internal class IdentityDbInit : DropCreateDatabaseAlways<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        private void PerformInitialSetup(AppIdentityDbContext context)
        {
            
        }
    }
}