using Academia.Core.Entities;
using Newtonsoft.Json;
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
        }

        [Fact]
        public async Task ShouldAddListGetInstitute()
        {

            var institute = new Institute
            {
                Name = "The Best Institute",
                Address = "Dhaka"
            };

            Institute createdInstitute = await ShouldCreateNewInstitute(institute);

            await ShouldReturnOneInstituteOnGetAll();

            await ShouldGetInstituteById(institute, createdInstitute);

        }

        private async Task<Institute> ShouldCreateNewInstitute(Institute institute)
        {
            var jsonSerializedInstitute = JsonConvert.SerializeObject(institute);

            var content = new StringContent(jsonSerializedInstitute, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/Institute", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var responseInstitute = JsonConvert.DeserializeObject<Institute>(responseString);

            Assert.Equal(institute.Name, responseInstitute.Name);
            return responseInstitute;
        }

        private async Task ShouldReturnOneInstituteOnGetAll()
        {
            var response = await _client.GetAsync("/api/Institute");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var responseInstituteList = JsonConvert.DeserializeObject<Institute[]>(responseString);

            var length = responseInstituteList.Length;
            Assert.Equal(1, length);
        }

        private async Task ShouldGetInstituteById(Institute institute, Institute createdInstitute)
        {
            var response = await _client.GetAsync("/api/Institute/" + createdInstitute.Id);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            var responseInstitute = JsonConvert.DeserializeObject<Institute>(responseString);
            Assert.Equal(institute.Name, responseInstitute.Name);
        }
    }
}
