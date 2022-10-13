using RestSharp;
using System.Threading.Tasks;
using Session3.DataModels;
using Session3.Resources;
using Session3.Tests;

namespace Session3.Helpers
{
    class PetHelper
    {
        /// <summary>
        /// Send POST request to add new pet
        /// </summary>
        public static async Task<PetModel> AddNewPet(RestClient client)
        {
            var newPetData = PetData.demoPet();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new pet
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<PetModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
