﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.InstructorRequests
{
    public class UpdateInstructorRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
