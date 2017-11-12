using System;

namespace InstadateRestApi.Models
{
    public class User   
    {
        public int ID { get; set; }
        public int QbId { get; set; }
        public string AccessToken { get; set; }
        public string Portrait { get; set; }
        public string Birthday { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public DateTime CreateDate { get; set; }
    }
}