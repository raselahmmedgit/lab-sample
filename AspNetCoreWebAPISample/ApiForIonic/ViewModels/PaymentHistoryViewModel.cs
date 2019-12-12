using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForIonic.ViewModels
{
    public class PaymentHistoryViewModel
    {
        public Guid Id { get; set; }
        public long CreditUnionId { get; set; }
        public string PayeeName { set; get; }
        public decimal Amount { set; get; }
        public DateTime PaymentMadeOn { set; get; }
        
    }
}
