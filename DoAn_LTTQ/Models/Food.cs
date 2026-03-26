namespace DoAn_LTTQ.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}
