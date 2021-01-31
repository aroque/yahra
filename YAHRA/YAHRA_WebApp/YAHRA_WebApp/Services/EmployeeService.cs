using AutoMapper;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using YAHRA_WebApp.Models.Dto;
using YAHRA_WebApp.Services.Interfaces;
using YAHRA_WebApp.ViewModels;

namespace YAHRA_WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private HttpClient _httpClient;
        private readonly string API_PATH = "api/Employee/";
        private IMapper _mapper;
        private IDepartmentService _departmentService;
        private IEmployeeStatusService _employeeStatusService;
        public EmployeeService(IMapper mapper, IDepartmentService departmentService, IEmployeeStatusService employeeStatusService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
            _employeeStatusService = employeeStatusService;

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region GET

        private string GenerateQueryParams(string sortingOrder = null, int? pageSize = null,
            int? page = null, string department = null,
            string employeeStatus = null)
        {
            return $"?sortingOrder={sortingOrder}&pageSize={pageSize}&page={page}" +
                $"&filters={{department:\"{department ?? ""}\", employeeStatus:\"{employeeStatus ?? ""}\"}}";
        }

        public async Task<EmployeeListViewModel> GetEmployees(string sortingOrder = null, int? pageSize = null,
            int? page = null, string department = null,
            string employeeStatus = null)
        {

            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            HttpResponseMessage Res = await _httpClient.GetAsync(API_PATH + GenerateQueryParams(sortingOrder, pageSize, page, department, employeeStatus));

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                employees = _mapper.Map<List<EmployeeDto>, List<EmployeeViewModel>>(
                    JsonConvert.DeserializeObject<List<EmployeeDto>>(EmpResponse));

                List<DepartmentViewModel> departments = await _departmentService.GetDepartments();

                List<EmployeeStatusViewModel> employeeStatuses = await _employeeStatusService.GetEmployeeStatuses();

                EmployeeListViewModel listViewModel = new EmployeeListViewModel
                {
                    Employees = employees,
                    Departments = departments,
                    EmployeeStatuses = employeeStatuses
                };

                return listViewModel;
            }

            return null;
        }
        public async Task<EmployeeFormViewModel> GetEmployeeDefaultInfo()
        {
            EmployeeDto employee = new EmployeeDto();

            List<DepartmentViewModel> departments = await _departmentService.GetDepartments();

            List<EmployeeStatusViewModel> employeeStatuses = await _employeeStatusService.GetEmployeeStatuses();

            EmployeeFormViewModel editVieModel = new EmployeeFormViewModel
            {
                Departments = departments,
                EmployeeStatuses = employeeStatuses
            };

            return editVieModel;
        }

        public async Task<EmployeeFormViewModel> GetEmployee(int id)
        {
            EmployeeDto employee = new EmployeeDto();

            HttpResponseMessage employeeRes = await _httpClient.GetAsync(API_PATH + id);

            if (employeeRes.IsSuccessStatusCode)
            {
                var EmpResponse = employeeRes.Content.ReadAsStringAsync().Result;

                employee = JsonConvert.DeserializeObject<EmployeeDto>(EmpResponse);
            }

            List<DepartmentViewModel> departments = await _departmentService.GetDepartments();

            List<EmployeeStatusViewModel> employeeStatuses = await _employeeStatusService.GetEmployeeStatuses();

            EmployeeFormViewModel editVieModel = new EmployeeFormViewModel
            {
                Employee = _mapper.Map<EmployeeDto, EmployeeViewModel>(employee),
                Departments = departments,
                EmployeeStatuses = employeeStatuses
            };

            return editVieModel;
        }
        #endregion

        #region Update
        public async Task<bool> UpdateEmployee(int id, EmployeeFormViewModel employeeNew)
        {
            var put = await _httpClient.PutAsJsonAsync(API_PATH + id, employeeNew.Employee);


            return put.StatusCode == System.Net.HttpStatusCode.OK;
        }

        #endregion

        #region Create
        public async Task<bool> CreateEmployee(EmployeeFormViewModel employeeNew)
        {

            var post = await _httpClient.PostAsJsonAsync(API_PATH, employeeNew.Employee);


            return post.StatusCode == System.Net.HttpStatusCode.OK;
        }

        #endregion

        #region Delete
        public async Task<bool> DeleteEmployee(int id)
        {
            var post = await _httpClient.DeleteAsync(API_PATH + id);

            return post.StatusCode == System.Net.HttpStatusCode.OK;
        }

        #endregion

    }
}