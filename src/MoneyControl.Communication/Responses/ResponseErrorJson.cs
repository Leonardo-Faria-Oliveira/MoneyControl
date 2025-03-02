using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Communication.Responses
{
    public class ResponseErrorJson
    {

        public required ICollection<string> ErrorMessage { get; set; } = [];

    }
}
