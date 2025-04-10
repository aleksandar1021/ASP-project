using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application.DTO
{
    public class ResponseErrorLogDTO
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string StrackTrace { get; set; }
    }
}
