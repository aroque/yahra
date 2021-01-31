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
    public class EmployeeStatusService : IEmployeeStatusService
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        public EmployeeStatusService(IMapper mapper)
        {
            _mapper = mapper;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["baseUrl"]);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<EmployeeStatusViewModel>> GetEmployeeStatuses()
        {
            List<EmployeeStatusDto> employeeStatuses = new List<EmployeeStatusDto>();

            HttpResponseMessage Res = await _httpClient.GetAsync("api/EmployeeStatus");

            if (Res.IsSuccessStatusCode)
            {
                var empStResponse = Res.Content.ReadAsStringAsync().Result;

                employeeStatuses = JsonConvert.DeserializeObject<List<EmployeeStatusDto>>(empStResponse);

            }

            return _mapper.Map<List<EmployeeStatusDto>, List<EmployeeStatusViewModel>>( employeeStatuses);
        }
    }
}