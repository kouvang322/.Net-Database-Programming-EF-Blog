using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Blog.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        // "virtual" setup for later use of "Lazy Loading"
        //  defines the table relationship
        public virtual List<Post> Posts { get; set; }

        public static explicit operator DbSet<object>(Blog v)
        {
            throw new NotImplementedException();
        }
    }
}
