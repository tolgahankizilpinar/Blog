using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string Picture { get; set; }
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }
        public bool IsApproval { get; set; }
        public bool Homepage { get; set; }


        public int CategoryId { get; set; } 
        public Category Category { get; set; } 
    }
}