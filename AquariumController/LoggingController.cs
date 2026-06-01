using AquariumData;
using AquariumData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquariumController
{
    public class LoggingController
    {
        private AquariumContext context;
        public LoggingController()
        {
            context = new AquariumContext();
        }
        public LoggingController(AquariumContext context)
        {
            this.context = context;
        }
        public async Task<Userr> Login(string username, string email, string password)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Email == email && x.Password == password);
        }
    }
}
