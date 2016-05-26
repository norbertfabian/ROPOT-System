﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Entities
{
    public class Role : IdentityRole<int, UserRole>
    {
        public string Description { get; set; }
        public Role()
        {

        }
    }
}
