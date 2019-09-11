using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsFinder.Data;
using SportsFinder.Data.Models;
using TestSupport.EfHelpers;
using TestSupport.EfSchemeCompare;

namespace SportsFinder.Test.Data
{
    [TestClass]
    public class SqliteTest
    {

        
        [TestMethod]
        public void VerifyEnitityFrameworkContext()
        {

            //SETUP
            //Here create the options using SQLite CreateOptions
            var options = SqliteInMemory
                .CreateOptions<ApplicationDbContext>();
            //I create an instance of my DbContext
            using (var context = new ApplicationDbContext(options))
            {

                context.Database.Migrate();
                ApplicationUser newUser = new ApplicationUser();
                newUser.Id = "Test";
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
    }
}
