//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class LinesMonitoringCause
    {
        public int Id { get; set; }
        public short DisconnectionCause { get; set; }
        public string Category { get; set; }
        public string CategoryDescription { get; set; }
        public string CauseDescription { get; set; }
    }
}
