﻿using CoreDemo.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminRoleControllerController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;


        public AdminRoleControllerController(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {

            if (ModelState.IsValid)
            {
                AppRole role = new AppRole()
                {
                    Name = roleViewModel.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            
            return View(roleViewModel);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name,
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();

            values.Name = model.Name;
            
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public  async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
            var result = await _roleManager.DeleteAsync(values);
            if (true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult UserRoleList()
        {

            var values = _userManager.Users.ToList(); 
            return View(values);
        }
        [HttpGet]

        public async Task<IActionResult> AssignRole(int id)
        {
            //var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            //var roles = _roleManager.Roles.ToList();

            //ViewBag.Userid= user.Id;

            //var userRoles = await _userManager.GetRolesAsync(user);

            //List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            //foreach (var item in roles)
            //{
            //    RoleAssignViewModel role = new RoleAssignViewModel();
            //    role.RoleID = item.Id;
            //    role.Name = item.Name;
            //    role.Exists = userRoles.Contains(item.Name);
            //    model.Add(role);
            //}

            return View(/*model*/);
        }

    }
}
