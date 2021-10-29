using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFTutorial.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }


        // entity framework relationship
        // Navigation properties
        public List<Post> Posts {get; set; }
    }
}