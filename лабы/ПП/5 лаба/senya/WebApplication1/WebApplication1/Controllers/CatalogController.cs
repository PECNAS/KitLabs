using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Represitories;

namespace WebApplication1.Controllers
{
    public class CatalogController : Controller
    {
        MobileContext db;

        public CatalogController(MobileContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var login = HttpContext.Session.GetString("login");
            if (login == null)
            {
                return Redirect("~/Login");
            }

            var seg_rep = new SegmentRepositoriesImpl(db);
            var us_rep = new UserRepositoriesImpl(db);

            ViewBag.user = us_rep.GetUserByLogin(login);
            ViewBag.segments = seg_rep.GetSegments();
            return View("~/Views/Catalog.cshtml");
        }

        [HttpGet]
        public IActionResult Segment(int seg_id)
        {
            var login = HttpContext.Session.GetString("login");

            var seg_rep = new SegmentRepositoriesImpl(db);
            var us_rep = new UserRepositoriesImpl(db);

            Segment seg = seg_rep.GetSegById(seg_id);
            User user = us_rep.GetUserByLogin(login);
            User leader = us_rep.GetUserById(seg.Leader);

            ViewBag.user = user;
            ViewBag.segment = seg;
            ViewBag.leader = leader;

            return View("~/Views/Segment.cshtml");
        }

        [HttpPost]
        public IActionResult ComeIn(int seg_id)
        {
            var login = HttpContext.Session.GetString("login");

            var seg_rep = new SegmentRepositoriesImpl(db);
            var us_rep = new UserRepositoriesImpl(db);

            Segment seg = seg_rep.GetSegById(seg_id);
            User user = us_rep.GetUserByLogin(login);

            db.Members.Add(new Member
            {
                UserId = user.Id,
                SegmenId = seg_id
            });
            db.SaveChanges();

            return Redirect("~/Profile");
        }
    }
}
