using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC04.Models
{
    [Table("tblProducts")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã mặt hàng")]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Tên mặt hàng không được để trống")]
        [StringLength(150, ErrorMessage = "Tên mặt hàng không vượt quá 150 ký tự")]
        [Display(Name = "Tên mặt hàng")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "URL ảnh không được để trống")]
        [RegularExpression(@"^.+\.(png|PNG)$", ErrorMessage = "Đường dẫn ảnh phải có định dạng .png")]
        [Display(Name = "URL ảnh đại diện (PNG)")]
        public string ImageURL { get; set; } = string.Empty;

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Đơn giá")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}
