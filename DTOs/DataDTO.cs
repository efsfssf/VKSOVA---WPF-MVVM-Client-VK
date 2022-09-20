using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPF.DTOs
{
    public class DataDTO
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public int user_id { get; set; }
    }
}
