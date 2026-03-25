namespace DoAn_LTTQ.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public System.DateTime DateCheckIn { get; set; }
        public System.DateTime? DateCheckOut { get; set; }
        public int TableID { get; set; }
        public int Status { get; set; }  // 0=Mở, 1=Đã thanh toán
        public int? Discount { get; set; }
        public int? CustomerID { get; set; }
    }
}
