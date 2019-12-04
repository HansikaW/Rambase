using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;

namespace WebAPIIntegrationTestProject
{
   public class EDIntegrationTesting
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/EmployeeDetail");

                //response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Get_All1()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/EmployeeDetail");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
