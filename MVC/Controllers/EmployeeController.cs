﻿using System.Collections.Generic;
using Core;
using Facade;
using Microsoft.AspNetCore.Mvc;
using Infra;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers {

    public class EmployeeController : Controller {

        private readonly SalesDbContext db;

        public EmployeeController(SalesDbContext db) {
            this.db = db;
        }

        [Authorize]
        public ActionResult Index() {
            var model = new EmployeeListViewModel();
            model.UserName = User.Identity.Name;
            var employees = Employees.Get(db);
            var list = new List<EmployeeViewModel>();
            foreach (var e in employees) {
                var employee = new EmployeeViewModel(e);
                list.Add(employee);
            }

            model.Employees = list;

            return View("Index", model);
        }

        [Authorize]
        public ActionResult AddNew() {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit) {
            if (BtnSubmit != "Save Employee") return RedirectToAction("Index");
            if (!ModelState.IsValid) return View("CreateEmployee");

            return save(e);
        }

        private ActionResult save(Employee e) {
            Employees emp = new Employees();
            emp.Save(e, db);
            return RedirectToAction("Index");
        }
    }
}
