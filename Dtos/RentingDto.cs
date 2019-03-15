using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Dtos
{
    public class RentingDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesId { get; set; }

    }


}