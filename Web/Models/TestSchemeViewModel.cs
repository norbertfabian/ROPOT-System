using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL.DTO;

namespace Web.Models
{
    public class TestSchemeViewModel
    {
        public List<TestSchemeDTO> TestSchemes { get; set; }

        public TestSchemeViewModel()
        {
            TestSchemes = new List<TestSchemeDTO>();
        }

    }
}