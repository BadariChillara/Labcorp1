using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using System;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SpecFlow;

namespace SeleniumLabCorp.StepDefinitions
{
    [Binding]
    public class APITestSteps
    {
        private RestClient client;
        private RestResponse response;
        private List<User> users;

        public class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string phone { get; set; }
            public int userStatus { get; set; }
        }

        [Given(@"I have the following user information")]
        public void GivenIHaveTheFollowingUserInformation(Table table)
        {
            users = new List<User>();
            foreach (var row in table.Rows)
            {
                users.Add(new User
                {
                    id = int.Parse(row["id"]),
                    username = row["username"],
                    firstName = row["firstName"],
                    lastName = row["lastName"],
                    email = row["email"],
                    password = row["password"],
                    phone = row["phone"],
                    userStatus = int.Parse(row["userStatus"])
                });
            }
        }
        [When(@"I send a POST request to https://petstore.swagger.io/v2/user/createWithArray with the user information")]
        public void WhenISendAPOSTRequestToWithTheUserInformation(string endpoint)
        {
            client = new RestClient(endpoint);
            RestRequest request = new RestRequest(Method.Post.ToString());
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(users);

            response = client.Execute(request);
        }

        [Then(@"the response status code should be 200")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }

        [When(@"I send a GET request to https://petstore.swagger.io/v2/user/323243431qw")]
        public void WhenISendAGETRequestTo(string endpoint)
        {
            client = new RestClient(endpoint);
            RestRequest request = new RestRequest("GET");

            response = client.Execute(request);
        }

        [Then(@"the response should contain the following details")]
        public void ThenTheResponseShouldContainTheFollowingDetails(Table table)
        {
            var responseData = JsonConvert.DeserializeObject<User>(response.Content);

            foreach (var row in table.Rows)
            {
                var propertyName = row[0];
                var expectedValue = row[1];

                var actualValue = responseData.GetType().GetProperty(propertyName)?.GetValue(responseData)?.ToString();

                Assert.AreEqual(expectedValue, actualValue);
            }
        }
    }
}
