using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class OperationResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public long Key { get; set; }
    }
}
