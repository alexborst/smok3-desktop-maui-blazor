using System;
namespace desktop_maui_blazor.Data.GraphQL
{
	public class UserGamesResponse
	{
        public IEnumerable<Game> UserGames { get; set; }
        public UserGamesResponse()
		{
			
		}
	}
}

