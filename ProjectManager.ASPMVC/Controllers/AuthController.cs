using Microsoft.AspNetCore.Mvc;
using ProjectManager.ASPMVC.Handlers;
using ProjectManager.ASPMVC.Models.Auth;
using ProjectManager.BLL.Entities;
using ProjectManager.COMMON.Repositories;

namespace ProjectManager.ASPMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly  IRepo_User<User> _bllService;
        private readonly UserSessionManager _userSession;


        public AuthController(IRepo_User<User> bllService, UserSessionManager userSession)
        {
            _bllService = bllService;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException("Le formulaire n'est pas valide");
                Guid userId = _bllService.CheckPassword(form.Email, form.Password);
                _userSession.UserId = userId;
                return RedirectToAction("Index", "Project");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout(IFormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid) throw new InvalidOperationException();
                _userSession.UserId = null;
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
