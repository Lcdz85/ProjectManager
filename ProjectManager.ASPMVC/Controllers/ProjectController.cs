using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.ASPMVC.Handlers;
using ProjectManager.ASPMVC.Mappers;
using ProjectManager.ASPMVC.Models.Project;
using ProjectManager.BLL.Entities;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC.Controllers
{
    [TypeFilter<RequiredAuthenticationFilter>]

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
            Employee employee = _bllEmployeeService.Get(_userSession.EmployeeId.Value);
            IEnumerable<ListProject_VM> model;

            if (employee.IsProjectManager)
            {
                model = _bllProjectService
                    .Get_ByProjectManagerId(employee.EmployeeId)
                    .Select(p => p.ToListItem());
            }
            else
            {
                model = _bllProjectService
                    .Get_ByEmployeeId(employee.EmployeeId)
                    .Select(p => p.ToListItem());
            }

            return View(model);
        }

// GET: ProjectController/Details/5
public ActionResult Details(Guid id)
        {
            DetailsProject_VM model = _bllProjectService.Get(id).ToDetails();

            return View(model);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProject_Form form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide.");
                Project newProject = form.ToBLL();
                newProject.ProjectManagerId = _userSession.EmployeeId.Value;
                Guid projectId = _bllProjectService.Create(newProject);
                return RedirectToAction(nameof(Index), "Project", new { id = projectId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(Guid id)
        {
            EditProject_Form model = _bllProjectService.Get(id).ToEdit();
            return View();
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, EditProject_Form form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide");
                _bllProjectService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Details), "Project", new { id });
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
