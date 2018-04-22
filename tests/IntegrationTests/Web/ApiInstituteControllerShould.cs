using Academia.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Net;
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
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

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

        [Fact]
        public async Task ShouldBeAbleToUpdateInstitutue()
        {
            var institute = new Institute
            {
                Name = "The Best Institute",
                Address = "Dhaka"
            };

            var createInstitute = await ShouldCreateNewInstitute(institute);

            createInstitute.Name = "New Name";
            var instituteJsonSerialized = JsonConvert.SerializeObject(createInstitute);
            var content = new StringContent(instituteJsonSerialized, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/institute/"+ createInstitute.Id, content);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            // now check if the institute is updated
            var getResponse = await _client.GetAsync("/api/institute/" + createInstitute.Id);
            getResponse.EnsureSuccessStatusCode();
            var responseString = await getResponse.Content.ReadAsStringAsync();
            var instituteGetById = JsonConvert.DeserializeObject<Institute>(responseString);

            Assert.Equal(createInstitute.Name, instituteGetById.Name);
                        
        }

        [Fact]
        public async Task ShouldNotUpdateInstituteIfIdMissmatch()
        {
            var institute = new Institute
            {
                Name = "The Best Institute",
                Address = "Dhaka"
            };

            var createInstitute = await ShouldCreateNewInstitute(institute);

            institute.Name = "New Name";
            var instituteJsonSerialized = JsonConvert.SerializeObject(createInstitute);
            var content = new StringContent(instituteJsonSerialized, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/institute/22222", content);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ShouldNotUpdateInstituteIdNotFound()
        {
            var institute = new Institute
            {
                Name = "The Best Institute",
                Address = "Dhaka"
            };

            var createInstitute = await ShouldCreateNewInstitute(institute);

            institute.Name = "New Name";
            var notInDatabaseId = Guid.NewGuid();
            createInstitute.Id = notInDatabaseId;
            var instituteJsonSerialized = JsonConvert.SerializeObject(createInstitute);
            var content = new StringContent(instituteJsonSerialized, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("/api/institute/"+ notInDatabaseId, content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
