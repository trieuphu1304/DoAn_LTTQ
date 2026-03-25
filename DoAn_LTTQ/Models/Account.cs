namespace DoAn_LTTQ.Models
{
    public class Account
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }  // 0=Admin, 1=Nhân viên, 2=Quản lý
        public int? EmployeeID { get; set; }
    }
}
