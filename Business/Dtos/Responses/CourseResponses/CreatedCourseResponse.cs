﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.CourseResponses
{
    public class CreatedCourseResponse
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
