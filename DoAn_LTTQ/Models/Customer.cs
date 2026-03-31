namespace DoAn_LTTQ.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Phone}";
        }
    }
}
