using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.ASPMVC.Handlers;
using ProjectManager.ASPMVC.Models.Post;
using ProjectManager.ASPMVC.Models.Project;
using ProjectManager.BLL.Entities;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController
        private readonly IRepo_Post<Post> _bllPostService;
        private readonly IRepo_Employee<Employee> _bllEmployeeService;
        private readonly IRepo_Project<Project> _bllProjectService;

        private readonly UserSessionManager _userSession;

        public PostController(IRepo_Post<Post> bllPostService, IRepo_Employee<Employee> bllEmployeeService, UserSessionManager userSession, IRepo_Project<Project> bllProjectService)
        {
            _bllPostService = bllPostService;
            _bllEmployeeService = bllEmployeeService;
            _userSession = userSession;
            _bllProjectService = bllProjectService;
        }

        // GET: PostController
        public ActionResult Index()
        {
            //Employee employee = _bllEmployeeService.Get(_userSession.EmployeeId.Value);

            //IEnumerable<ListPost_VM> model;

            

            return View();
        }
        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
