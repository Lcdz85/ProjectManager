using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.ASPMVC.Handlers;
using ProjectManager.ASPMVC.Models.Project;
using ProjectManager.BLL.Entities;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IRepo_Project<Project> _bllProjectService;
        private readonly IRepo_Employee<Employee> _bllEmployeeService;
        private readonly UserSessionManager _userSession;

        public ProjectController(IRepo_Project<Project> bllProjectService, IRepo_Employee<Employee> bllEmployeeService, UserSessionManager userSession)
        {
            _bllProjectService = bllProjectService;
            _bllEmployeeService = bllEmployeeService;
            _userSession = userSession;
        }

        // GET: ProjectController
        public ActionResult Index()
        {
            Guid employeeId = _bllEmployeeService.Get_ByUserId(_userSession.UserId);
            IEnumerable<ListProject_VM> model;
            model = _bllProjectService.Get_ByEmployeeId(employeeId).ToListItem();
            return View();
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
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

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
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

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
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
