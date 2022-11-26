using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoGramApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}