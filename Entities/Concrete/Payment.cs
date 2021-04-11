using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string SecurityNumber { get; set; }

    }
}
