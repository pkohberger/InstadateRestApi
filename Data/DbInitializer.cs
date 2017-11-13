using InstadateRestApi.Models;
using System;
using System.Linq;

namespace InstadateRestApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InstadateRestApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any() || context.FilePaths.Any())
            {
                return;
            }

            context.SaveChanges();
        }
    }
}