using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace ServiceB.Pages
{
    public class IndexModel : PageModel
    {
        public string Data;
        private IHttpClientFactory _factory;

        public IndexModel(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task OnGet()
        {
            var client = _factory.CreateClient("service");
            Data = await client.GetStringAsync("api/values");
        }
    }
}
