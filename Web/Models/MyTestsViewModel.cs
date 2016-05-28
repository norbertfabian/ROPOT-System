using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class MyTestsViewModel
    {
        public List<TestSchemeDTO> Tests { get; set; }

        public MyTestsViewModel()
        {
            Tests = new List<TestSchemeDTO>();
        }
    }
}