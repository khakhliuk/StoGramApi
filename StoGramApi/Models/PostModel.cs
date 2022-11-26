using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoGramApi.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ImageBytes { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
    }
}