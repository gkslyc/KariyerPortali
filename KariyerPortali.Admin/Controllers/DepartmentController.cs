﻿using AutoMapper;
using KariyerPortali.Admin.Models;
using KariyerPortali.Admin.ViewModels;
using KariyerPortali.Data;
using KariyerPortali.Model;
using KariyerPortali.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KariyerPortali.Admin.Controllers
{
    public class DepartmentController : BaseController
    {
       
        // GET: Department
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentFormViewModel department)
        {
            if (department != null )
            {
                var dep = Mapper.Map<DepartmentFormViewModel, Department>(department);
                departmentService.CreateDepartment(dep);
                departmentService.SaveDepartment();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var department = departmentService.GetDepartment(id.Value);
                if (department != null)
                {
                    departmentService.DeleteDepartment(department);
                    departmentService.SaveDepartment();
                    return RedirectToAction("Index");
                }
            }
            return HttpNotFound();
        }
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var department = departmentService.GetDepartment(id.Value);
                if (department != null)
                {
                    var dapartmentViewModel = Mapper.Map<Department, DepartmentViewModel>(department);
                    return View(dapartmentViewModel);
                }
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentFormViewModel departmentForm)
        {
            if (ModelState.IsValid)
            {
                var department = Mapper.Map<DepartmentFormViewModel, Department>(departmentForm);
                departmentService.UpdateDepartment(department);
                departmentService.SaveDepartment();
                return RedirectToAction("Index");
            }
            return View(departmentForm);
        }
        
        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {
            string sSearch = "";
            if (param.sSearch != null) sSearch = param.sSearch;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var sortDirection = Request["sSortDir_0"]; // asc or desc
            int iTotalRecords;
            int iTotalDisplayRecords;
            var displayedDepartments = departmentService.Search(sSearch, sortColumnIndex, sortDirection, param.iDisplayStart, param.iDisplayLength, out iTotalRecords, out iTotalDisplayRecords);

            var result = from c in displayedDepartments
                         select new[] { c.DepartmentId.ToString(), c.DepartmentId.ToString(), c.DepartmentName, string.Empty};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = iTotalRecords,
                iTotalDisplayRecords = iTotalDisplayRecords,
                aaData = result
            },
                JsonRequestBehavior.AllowGet);
        }

    }
}