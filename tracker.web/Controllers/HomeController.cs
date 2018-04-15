using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using tracker.application.Contracts;
using tracker.web.ViewModels;
using AppModel = tracker.application.Models;
using DomainModel = tracker.domain.Models;

namespace tracker.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            if (userService == null) throw new ArgumentNullException(nameof(userService));
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var domainUsers = await this._userService.GetAllAsync();
            var viewModels = this.Map(domainUsers);
            return View(viewModels);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ICollection<AppModel.User> users)
        {
            await this._userService.UpdateAsync(users);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AppModel.User user)
        {
            await this._userService.AddAsync(user);
            return RedirectToAction("Index");
        }

        private UserViewModel[] Map(ICollection<DomainModel.User> users)
        {
            users = users ?? new Collection<DomainModel.User>();
            return users.Select(this.Map).OrderBy(x => x.Name).ToArray();
        }

        private UserViewModel Map(DomainModel.User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = $"{user.FirstName} {user.LastName}",
                Status = user.Status
            };
        }
    }
}