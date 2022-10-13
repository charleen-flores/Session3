using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Session3.DataModels;
using Session3.Resources;
using Session3.Helpers;
using Session3.Tests;

namespace Session3
{
    [TestClass]
    public class RestApiTest : ApiBaseTest
    {
        private static List<PetModel> petCleanUpList = new List<PetModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }

        [TestMethod]
        public async Task DemoGetPet()
        {
            //Arrange
            var getPetRequest = new RestRequest(Endpoints.GetPetById(PetDetails.Id));
            petCleanUpList.Add(PetDetails);

            //Act
            var getPetResponse = await RestClient.ExecuteGetAsync<PetModel>(getPetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, getPetResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(PetDetails.Name, getPetResponse.Data.Name, "Name did not match.");
            Assert.AreEqual(PetDetails.Category.Id, getPetResponse.Data.Category.Id, "Category ID did not match.");
            Assert.AreEqual(PetDetails.Category.Name, getPetResponse.Data.Category.Name, "Category Name did not match.");
            Assert.AreEqual(PetDetails.PhotoUrls[0], getPetResponse.Data.PhotoUrls[0], "PhotoUrls did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Id, getPetResponse.Data.Tags[0].Id, "Tags ID did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Name, getPetResponse.Data.Tags[0].Name, "Tags Name did not match.");
            Assert.AreEqual(PetDetails.Status, getPetResponse.Data.Status, "Status did not match.");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in petCleanUpList)
            {
                var deletePetRequest = new RestRequest(Endpoints.GetPetById(data.Id));
                var deletePetResponse = await RestClient.DeleteAsync(deletePetRequest);
            }
        }
    }
}
