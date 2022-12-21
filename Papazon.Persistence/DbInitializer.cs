using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papazon.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PapazonDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
