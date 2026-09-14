using System.ComponentModel.DataAnnotations;

namespace MVC032.Models
{
    public class Member
    {
        [Display(Name = "Mã thành viên")]
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ và tên phải từ 2 đến 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Ảnh đại diện")]
        [Url(ErrorMessage = "Đường dẫn ảnh đại diện không hợp lệ")]
        public string AvatarURL { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ")]
        [Display(Name = "Địa chỉ Email")]
        public string Email { get; set; } = string.Empty;
    }

    public class MemberModel
    {
        public List<Member> GetMembers()
        {
            return new List<Member>
            {
                new Member
                {
                    MemberID = 1,
                    FullName = "Nguyễn Văn An",
                    AvatarURL = "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=300&auto=format&fit=crop&q=80",
                    Phone = "0912345678",
                    Email = "an.nguyen@example.com"
                },
                new Member
                {
                    MemberID = 2,
                    FullName = "Trần Thị Bình",
                    AvatarURL = "https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=300&auto=format&fit=crop&q=80",
                    Phone = "0987654321",
                    Email = "binh.tran@example.com"
                },
                new Member
                {
                    MemberID = 3,
                    FullName = "Lê Hoàng Cường",
                    AvatarURL = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=300&auto=format&fit=crop&q=80",
                    Phone = "0903123456",
                    Email = "cuong.le@example.com"
                },
                new Member
                {
                    MemberID = 4,
                    FullName = "Phạm Mai Dung",
                    AvatarURL = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=300&auto=format&fit=crop&q=80",
                    Phone = "0934567890",
                    Email = "dung.pham@example.com"
                },
                new Member
                {
                    MemberID = 5,
                    FullName = "Hoàng Tuấn Em",
                    AvatarURL = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=300&auto=format&fit=crop&q=80",
                    Phone = "0978123456",
                    Email = "em.hoang@example.com"
                },
                new Member
                {
                    MemberID = 6,
                    FullName = "Vũ Thu Giang",
                    AvatarURL = "https://images.unsplash.com/photo-1544005313-94ddf0286df2?w=300&auto=format&fit=crop&q=80",
                    Phone = "0965432198",
                    Email = "giang.vu@example.com"
                },
                new Member
                {
                    MemberID = 7,
                    FullName = "Đặng Hải Huy",
                    AvatarURL = "https://images.unsplash.com/photo-1522075469751-3a6694fb2f61?w=300&auto=format&fit=crop&q=80",
                    Phone = "0945678123",
                    Email = "huy.dang@example.com"
                },
                new Member
                {
                    MemberID = 8,
                    FullName = "Bùi Lan Hương",
                    AvatarURL = "https://images.unsplash.com/photo-1517841905240-472988babdf9?w=300&auto=format&fit=crop&q=80",
                    Phone = "0923456789",
                    Email = "huong.bui@example.com"
                }
            };
        }
    }
}
