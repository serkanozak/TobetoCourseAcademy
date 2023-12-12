using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.InstructorResponses
{
    public class UpdatedInstructorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
