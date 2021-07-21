using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var baseAddress = new Uri("https://djblogsfuncappwithswagger.azurewebsites.net/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Add("x-functions-key", "Yq9KOCBQ4StFRPVL8Q2lW6OVVM36aL2Euo5D5OkSLaCQC3WTwdwSDg==");
                using (var response = await httpClient.GetAsync("api/Function1?name=DJ Blogs"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
