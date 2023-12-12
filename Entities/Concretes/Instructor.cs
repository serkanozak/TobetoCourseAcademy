using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes
{
    public class Instructor : Entity<Guid>
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
