using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace testIntegration
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/values");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
