using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FatsitBikerMVC.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên xe")]
        [Display(Name = "Tên xe")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Giá tiền chỉ được phép nhập số.")]
        [Display(Name = "Giá")]
        public string Price { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        public string Desc { get; set; } = string.Empty;

        [Display(Name = "Động cơ")]
        public string Engine { get; set; } = string.Empty;

        [Display(Name = "Công suất")]
        public string Power { get; set; } = string.Empty;

        [Display(Name = "Trọng lượng")]
        public string Weight { get; set; } = string.Empty;

        // Dùng để chứa ảnh hiện tại khi Edit
        public List<ProductImage> ExistingImages { get; set; } = new List<ProductImage>();

        // Danh sách ID các ảnh cũ được chọn để xóa
        public List<int> ImagesToDelete { get; set; } = new List<int>();

        // Dùng để nhận file upload từ người dùng
        [Display(Name = "Hình ảnh")]
        public List<IFormFile>? ImageUploads { get; set; }
    }
}
