﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core;
using Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers {

    public class AuthenticationController : Controller {

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoLogin(UserDetails u) {
            if (Employees.IsValidUser(u)) {
                await setIdentity(u);
                return RedirectToAction("Index", "Employee");
            }

            ModelState.AddModelError("CredentialError", "Invalid username or password!");
            return View("Login");
        }

        private async Task setIdentity(UserDetails u) {
            List<Claim> claims = new List<Claim> {new Claim(ClaimTypes.Name, u.UserName)};
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(scheme: "AuthScheme", principal: principal);
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(scheme: "AuthScheme");
            return RedirectToAction("Login");
        }
    }
}
