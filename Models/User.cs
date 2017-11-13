using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstadateRestApi.Models
{
    public class User   
    {
        public int ID { get; set; }

        public int QbID { get; set; }

        public virtual ICollection<FilePath> FilePaths { get; set; }

        [StringLength(250)]
        public string AccessToken { get; set; }

        [StringLength(10)]
        public string Birthday { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string About { get; set; }

        [StringLength(250)]
        public string Location { get; set; }

        public DateTime CreateDate { get; set; }
    }
}