using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CapstoneBackend.Models {
    public class Request {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Justification { get; set; }
        public string RejectionReason { get; set; }
        public string DeliveryMode { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual List<RequestLine> RequestLines { get; set; }
        public Request() {

        }
    }
}
