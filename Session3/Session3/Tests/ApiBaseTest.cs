using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3.DataModels;

namespace Session3.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public PetModel PetDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
