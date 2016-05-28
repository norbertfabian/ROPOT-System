using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class TestViewModel
    {
        public List<TestDTO> Tests { get; set; }

        public TestViewModel()
        {
            Tests = new List<TestDTO>();
        }
    }
}