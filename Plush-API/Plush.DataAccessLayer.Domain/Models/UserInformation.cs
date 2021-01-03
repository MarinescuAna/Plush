﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class UserInformation
    {
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string Delivery { get; set; }
        public string Payment { get; set; }
        public string Phone { get; set; }

    }
}