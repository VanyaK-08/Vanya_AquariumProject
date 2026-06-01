using AquariumData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestControllers.Saving
{
    public class TestDBStuff
    {
        public static AquariumContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AquariumContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            AquariumContext context = new AquariumContext(options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
