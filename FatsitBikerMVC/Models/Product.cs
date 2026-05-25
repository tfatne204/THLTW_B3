namespace FatsitBikerMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d+$", ErrorMessage = "Giá tiền chỉ được phép nhập số.")]
        public string Price { get; set; } = string.Empty;
        public List<string> Images { get; set; } = new List<string>();
        public string Desc { get; set; } = string.Empty;
        public string Engine { get; set; } = string.Empty;
        public string Power { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
    }
}
