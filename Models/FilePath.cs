using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstadateRestApi.Models
{
    public class FilePath
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(10)]
        public string FileType { get; set; }

        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
