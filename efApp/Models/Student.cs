using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efApp.Models
{
    public class Student : Person
    {
        public int StudentNumber { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
