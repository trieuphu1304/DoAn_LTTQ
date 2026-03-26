using System;

namespace DoAn_LTTQ.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int TableID { get; set; }
        public int Status { get; set; }
        public int Discount { get; set; }
        public int? CustomerID { get; set; }
    }
}
