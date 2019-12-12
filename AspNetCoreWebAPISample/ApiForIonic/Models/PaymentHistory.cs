using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForIonic.Models
{
    public class PaymentHistory
    {
        public Guid Id { get; set; }
        public long CreditUnionId { get; set; }
        public decimal Amount { set; get; }
        public DateTime PaymentMadeOn { set; get; }
        public virtual CreditUnion CreditUnion { set; get; }
    }
}
