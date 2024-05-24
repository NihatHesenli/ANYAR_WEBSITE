using ANYAR_WEBSITE.DAL;
using ANYAR_WEBSITE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ANYAR_WEBSITE.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public TeamController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Teams.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            string path = _environment.WebRootPath + @"\Upload\Team\";
            string filename = team.ImgFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {

                team.ImgFile.CopyTo(stream);
            }


            team.ImgUrl = filename;
            _context.Teams.Add(team);
            _context.SaveChanges();



            return RedirectToAction("Index");

        }
        public IActionResult Update(int Id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == Id);

            if (team == null)
            {

                return RedirectToAction("Index");
            }
            return View(team);

        }
        [HttpPost]
        public IActionResult Update(Team newteam)
        {
            Team oldTeam = _context.Teams.FirstOrDefault(x => x.Id == newteam.Id);
            if (oldTeam == null) return NotFound ();
            if(!ModelState.IsValid) return View();
            if (newteam.ImgFile != null)
            {
                string path = _environment.WebRootPath + @"\Upload\Team\";
                FileInfo info = new FileInfo(path+oldTeam.ImgUrl);
                if(info.Exists)
                {

                    info.Delete();
                }
                string filename = newteam.ImgFile.FileName;
                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {

                    newteam.ImgFile.CopyTo(stream);
                }

                oldTeam.ImgUrl= filename;


            }
            oldTeam.Name = newteam.Name;
            oldTeam.Position = newteam.Position;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
          

    }      
}      

