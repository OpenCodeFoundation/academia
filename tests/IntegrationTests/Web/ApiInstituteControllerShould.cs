using Academia.Core.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.Web
{
    public class ApiInstituteControllerShould : BaseWebTest
    {

        [Fact]
        public async Task ReturnWithCurrectMessage()
        {
            var response = await _client.GetAsync("/api/Institute");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // We do not seed any institutes so the default list should be empty
            Assert.Equal("[]", stringResponse);
        }

        [Fact]
        public async Task AddInstitute()
        {

            var institute = new Institute
            {
                Name = "The Best Institute",
                Address = "Dhaka"
            };

            var serializedInstitute = JsonConvert.SerializeObject(institute);

            var content = new StringContent(serializedInstitute, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Institute", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseInstitute = JsonConvert.DeserializeObject<Institute>(responseString);

            Assert.Equal(institute.Name, responseInstitute.Name);

            var getResponse = await _client.GetAsync("/api/Institute");
            getResponse.EnsureSuccessStatusCode();
            var responseAllInstitute = await getResponse.Content.ReadAsStringAsync();
            var responseFromGetInstitute = JsonConvert.DeserializeObject<Institute[]>(responseAllInstitute);

            var length = responseFromGetInstitute.Length;
            Assert.Equal(1, length);

            var singleResponse = await _client.GetAsync("/api/Institute/" + responseInstitute.Id);
            singleResponse.EnsureSuccessStatusCode();
            var responseSingleInstituteString = await singleResponse.Content.ReadAsStringAsync();

            var instituteSingleGet = JsonConvert.DeserializeObject<Institute>(responseSingleInstituteString);
            Assert.Equal(institute.Name, instituteSingleGet.Name);
            
        }

    }
}
