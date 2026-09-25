using Microsoft.AspNetCore.Mvc;
using NctK65Lesson6Models.Models;

namespace NctK65Lesson6Models.Controllers
{
    public class NctMemberController : Controller
    {

        //mock data
        public static readonly List<NctMember> Members = new List<NctMember>()
        {
            //5 mock data
            new NctMember()
            {
                NctMemberId = Guid.NewGuid().ToString(),
                NctMemberName = "CongThanh",
                NctMemberPassword = "123456",
                NctMemberEmail = "nguyencongthanh@gmail.com",
                NctMemberFullName = "Nguyen Cong Thanh"
            },
            new NctMember() { NctMemberId = Guid.NewGuid().ToString(), NctMemberName = "MinhTuan", NctMemberPassword = "123456", NctMemberEmail = "tranminhtuan@gmail.com", NctMemberFullName = "Tran Minh Tuan" },
            new NctMember() { NctMemberId = Guid.NewGuid().ToString(), NctMemberName = "HoangNam", NctMemberPassword = "123456", NctMemberEmail = "lehoangnam@gmail.com", NctMemberFullName = "Le Hoang Nam" },
            new NctMember() { NctMemberId = Guid.NewGuid().ToString(), NctMemberName = "ThuHa", NctMemberPassword = "123456", NctMemberEmail = "phamthuha@gmail.com", NctMemberFullName = "Pham Thu Ha" },
            new NctMember() { NctMemberId = Guid.NewGuid().ToString(), NctMemberName = "BaoAn", NctMemberPassword = "123456", NctMemberEmail = "vobaoan@gmail.com", NctMemberFullName = "Vo Bao An" },
        };

        //GET
        public IActionResult Index()
        {
            return View(Members);
        }

        //CREATE
        public IActionResult NctCreate()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        public IActionResult NctCreate(NctMember NctMember)
        {
            NctMember.NctMemberId = Guid.NewGuid().ToString();
            Members.Add(NctMember);
            return RedirectToAction(nameof(Index));
        }

        //EDIT
        public IActionResult NctEdit()
        {
            return View();
        }

        //edit post
        [HttpPost]
        public IActionResult NctEdit(string id, NctMember NctMember)
        {
            var editedMember = Members.FirstOrDefault(m => m.NctMemberId == id);
            if (editedMember != null)
            {
                editedMember.NctMemberName = NctMember.NctMemberName;
                editedMember.NctMemberPassword = NctMember.NctMemberPassword;
                editedMember.NctMemberEmail = NctMember.NctMemberEmail;
                editedMember.NctMemberFullName = NctMember.NctMemberFullName;
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        public IActionResult NctGetDetails(string id)
        {
            var memberDetails = Members.FirstOrDefault(m => m.NctMemberId == id);
            if (memberDetails == null)
            {
                return NotFound();
            }
            else return View(memberDetails);
        }

        public IActionResult NctDelete(string id)
        {
            var memberToDelete = Members.FirstOrDefault(m => m.NctMemberId == id);
            if(memberToDelete != null)
            {
                Members.Remove(memberToDelete);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
