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
    
    public partial class CdrData
    {
        public int Id { get; set; }
        public Nullable<int> cdrRecordType { get; set; }
        public Nullable<int> globalCallID_callId { get; set; }
        public Nullable<int> origLegCallIdentifier { get; set; }
        public Nullable<int> dateTimeOrigination { get; set; }
        public Nullable<int> origNodeId { get; set; }
        public string callingPartyNumber { get; set; }
        public string callingPartyUnicodeLoginUserID { get; set; }
        public Nullable<int> origCause_value { get; set; }
        public Nullable<int> origMediaTransportAddress_IP { get; set; }
        public string finalCalledPartyNumber { get; set; }
        public string finalCalledPartyUnicodeLoginUserID { get; set; }
        public Nullable<int> destCause_value { get; set; }
        public Nullable<int> destMediaTransportAddress_IP { get; set; }
        public Nullable<int> dateTimeConnect { get; set; }
        public Nullable<int> dateTimeDisconnect { get; set; }
        public string lastRedirectDn { get; set; }
        public string lastRedirectDnPartition { get; set; }
        public Nullable<int> duration { get; set; }
        public string origDeviceName { get; set; }
        public string destDeviceName { get; set; }
        public Nullable<int> origCallTerminationOnBehalfOf { get; set; }
        public Nullable<int> destCallTerminationOnBehalfOf { get; set; }
        public string authCodeDescription { get; set; }
        public string authorizationCodeValue { get; set; }
        public string origIpv4v6Addr { get; set; }
        public string destIpv4v6Addr { get; set; }
        public string lastRedirectingPartyPattern { get; set; }
    }
}