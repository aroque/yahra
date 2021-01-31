using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YAHRA_WebApp.Models;
using YAHRA_WebApp.Services.Interfaces;
using YAHRA_WebApp.ViewModels;
using PagedList;

namespace YAHRA_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Employee
        public async Task<ActionResult> Index(string sortingOrder = null, int? pageSize = null, 
            int? page = null, string department = null,
            string employeeStatus = null)
        {
            ViewBag.CurrentSort = sortingOrder;
            ViewBag.CurrentDepartment = department;
            ViewBag.CurrentStatus = employeeStatus;
            ViewBag.PageCount = 2;
            ViewBag.PageSize = 5;
            ViewBag.PageNumber = (page ?? 1);
            return View(await _employeeService.GetEmployees(sortingOrder, pageSize, page, department, employeeStatus));
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _employeeService.GetEmployee(id));
        }

        // GET: Employee/Create
        public async Task<ActionResult> Create()
        {
            return View(await _employeeService.GetEmployeeDefaultInfo());
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeFormViewModel viewModel)
        {
            try
            {
                bool result = await _employeeService.CreateEmployee(viewModel);

                if (result)
                    return RedirectToAction("Index");
                else
                    return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            return View(await _employeeService.GetEmployee(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EmployeeFormViewModel viewModel)
        {
            try
            {
                bool result = await _employeeService.UpdateEmployee(id, viewModel);

                if (result)
                    return RedirectToAction("Index");
                else
                    return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                bool result = await _employeeService.DeleteEmployee(id);

                if (result)
                    return Content("Deleted");
                else
                    return Content("Not Deleted");
            }
            catch
            {
                return Content("Error");
            }
        }
    }
}
