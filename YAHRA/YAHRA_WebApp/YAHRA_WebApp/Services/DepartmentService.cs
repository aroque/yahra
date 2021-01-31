using AutoMapper;
using Newtonsoft.Json;
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
    public class DepartmentService : IDepartmentService
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        public DepartmentService(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<DepartmentViewModel>> GetDepartments()
        {
            List<DepartmentDto> departments = new List<DepartmentDto>();

            HttpResponseMessage Res = await _httpClient.GetAsync("api/Department");

            if (Res.IsSuccessStatusCode)
            {
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                departments = JsonConvert.DeserializeObject<List<DepartmentDto>>(EmpResponse);

            }

            return _mapper.Map<List<DepartmentDto>, List<DepartmentViewModel>>(departments);
        }
    }
}