namespace NctLesson03.Models
{
    public class NctProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public string ImageUrl { get; set; }
        private string? _description;
        public string Description
        {
            get
            {
                return string.IsNullOrEmpty(_description) ? Name : Description;
            }
            set
            {
                _description = value;
            }
        }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
    }
}
