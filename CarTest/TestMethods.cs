using CarLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarTest
{
    public static class TestMethods
    {

        public static T CreateDbContext<T>([CallerMemberName] string name = "Db",bool Unique = false) where T : DbContext
        {
            DbContextOptionsBuilder<T> options = new DbContextOptionsBuilder<T>();

            if (Unique)
            {
                options.UseInMemoryDatabase(name);
            }
            else
            {
                options.UseInMemoryDatabase(name + Random.Shared.Next(1, 3000));
            }

            T context = (T)Activator.CreateInstance(typeof(T), options.Options);

            context.Database.EnsureCreated();

            return context;
        }

    }
}
