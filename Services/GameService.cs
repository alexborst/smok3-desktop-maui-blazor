using System;
using System.Collections;
using desktop_maui_blazor.Data;
using desktop_maui_blazor.Data.GraphQL;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;


namespace desktop_maui_blazor.Services
{
    public class GameService
    {
        private IGraphQLClient _client;
        private const String userId = "7598b330-35bf-4c0f-b5a8-c83dd2c37c37";
        private const string _gamesByUser = @"
             {
                gameUser: game_user(where: {userid: {_eq: ""___""}}) {
                  game {
                    id
                    title
                    release_date
                  }
                }
              }
		";

        private const String allGamesQuery = @"
            query MyQuery {
              games : game {
                id
                title
                release_date
              }
            }
        ";

        public GameService()
        {
        }

        public async Task<List<GraphQLData.Game>> GetUserGames(String userId)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("x-hasura-admin-secret", "Y0ivgy2qclFLGuqENS360R2KMGkq51h13TJ7wnxHgg1h198NnFKYmrCASwCxLZSg");
                var client = new GraphQLHttpClient(new GraphQLHttpClientOptions
                {
                    EndPoint = new Uri("https://suited-fawn-90.hasura.app/v1/graphql")
                }, new NewtonsoftJsonSerializer(), httpClient);

                var request = new GraphQLRequest
                {
                    Query = allGamesQuery //_gamesByUser.Replace("___", userId)
                };
                Console.WriteLine($"Request: {request.Query.ToString()}");

                var response = await client.SendQueryAsync<GraphQLData.Data>(request);
                var something = response.AsGraphQLHttpResponse();
                var code = something.StatusCode;
                var data = something.Data;
                Console.WriteLine($" Response: {response.Data.ToString()}");

                return response.Data.Games.ToList();
            }
            catch (Exception e)
            {
                Console.Write($"Exception: {e.Message}");
            }
            return null;
        }
    }
}

