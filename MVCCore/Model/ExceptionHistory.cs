using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MVCCore.Model
{
    public partial class ExceptionHistory
    {
        public int LogId { get; set; }
        public string LogGuid { get; set; }
        public DateTime? RequestTime { get; set; }
        public string ControllerName { get; set; }
        public string ActionMethod { get; set; }
        public string ExceptionHandled { get; set; }
    }
}
