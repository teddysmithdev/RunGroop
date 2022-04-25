using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using RunGroopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RunGroopWebApp.Scraper.Services
{
    public class MeepUpClient
    {
        private GraphQLHttpClient _client;
        public MeepUpClient()
        {
            _client = new GraphQLHttpClient("https://api.meetup.com/gql", new NewtonsoftJsonSerializer());
            _client.HttpClient.DefaultRequestHeaders.Add("Authorization", "JWT c0f591eb6de4ee3f36178ae7453fd4b8");
        }

        public async void SendRequest()
        {
            var personAndFilmsRequest = new GraphQLRequest
            {
                Query = @"
			    query {
			        event(id: '276754274') {
			            title
                        description
                        dateTime
			        }
			    }"
            };
            try
            {
                var graphQLResponse = await _client.SendQueryAsync<Club>(personAndFilmsRequest);
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
