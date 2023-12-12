using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.CourseResponses
{
    public class GetCourseResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string CategoryName { get; set; }
        public string InstructorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
