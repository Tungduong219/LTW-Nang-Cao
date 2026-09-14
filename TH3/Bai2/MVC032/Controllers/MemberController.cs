using Microsoft.AspNetCore.Mvc;
using MVC032.Models;

namespace MVC032.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberModel _memberModel = new MemberModel();

        // 1. Action hiển thị danh sách toàn bộ thành viên
        [HttpGet]
        public IActionResult MemberList()
        {
            List<Member> members = _memberModel.GetMembers();
            return View(members);
        }

        // 2. Action hiển thị chi tiết thành viên theo id qua routing
        [HttpGet]
        public IActionResult MemberDetail(int id)
        {
            Member? member = _memberModel.GetMembers().FirstOrDefault(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound("Không tìm thấy thành viên có mã này.");
            }
            return View(member);
        }
    }
}
