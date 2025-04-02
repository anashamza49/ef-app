using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efApp.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}
