using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Domain
{
    public class Information
    {
        public Guid InformationID { get; set; }
        public string UserID { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }

        public virtual User User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
