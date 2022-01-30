using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string? GetJoke()    //TODO confirm if nullable should be addressed.
        {
            string joke = "Links to Joke Service: Generates Joke, commented out until final result to avoid API calls..."; //TODO add  line below back and comment out this one. For sake of not making incessant calls to the API. 
                                                                                                                           //   string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;

            return joke;
        }


    }
}
