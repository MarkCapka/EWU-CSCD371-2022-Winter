using System.Net.Http;
using System;
namespace CanHazFunny
{
    public class JokeService : IJokeService
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string joke = "Coroners refer to dead people as \"ABC's\". Already Been Chucked."; //Favorite joke   (one that always fails ;)
            
            //Make like your favorite action hero and do some roundhouse kicks on the jokes
            while (joke.ToLower().Contains("chuck") || joke.ToLower().Contains("norris"))
            {
                joke = HttpClient.GetStringAsync(new Uri("https://geek-jokes.sameerkumar.website/api")).Result;
            }
            return joke;
        }
    }
}

