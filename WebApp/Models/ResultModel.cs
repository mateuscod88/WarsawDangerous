using System.Collections.Generic;

namespace WarsawDangerous.Models
{
    public class ResultModel
    {
        public List<NotificationModel> notifications { get; set; }
        public string responseDesc { get; set; }
        public string responseCode { get; set; }
    }
}