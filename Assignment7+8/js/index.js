var joke ="Haha - i'm telling a joke"; //Make array holding setup then punchline

var jokeTeller = {
    name: "the Riddler",
    joke: function() {
        return new joke.getJoke();
    }
}


function getJoke(){
    return  this.joke;        
}



document.getElementById("mybutton").addEventListener("click", function(){
    //Send the joke data to page elements, generate a new joke
    console.log("button has been clicked: here is your joke:    TODO setup & delivery to build joke");
})




axios({
    jokeTeller: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);   //TODO come back and make this more intent revealing'
        console.log(response.data.main.joke); //TODO haven't tested yet 

        //Put the joke directly in the joke array variable
        let jokeOutput = document.querySelector("joke");
        jokeOutput.setup = response.data.main.joke.setup + "\n" 
        + response.data.main.joke.delivery;

    })
    .catch(function (error){
            console.log("status code: " + error + " Try again in a few seconds..."); //TODO make more specific
    });



//Joke API syntax: {error, category, type (number of parts), (if more than one part i.e. setup, delivery it will put them down ), joke, flags (default-false) {nsfw, religious, political, racist, sexist, explicit}}, id, safe, lang
//jokes from https://v2.jokeapi.dev/joke/Programming
function tellJoke(){
    console.log("This is the joke i'll be calling from the API: " + joke.getJoke());
    setTimeout(tellJoke, 4000); // TODO TEST will wait 4 seconds between telling jokes : NOTE UNTESTED , make sure it isn't in an infinite loop. 

    //above could also potentially be more like the other example from class: 
        /*
                from class Lecture15-web
                console.log(new Joke().getJoke());
                setInterval(function() {console.log(new Joke().getJoke();)}, 4000); //may also wait 4 seconds, however, one of these will cause an issue iirc 

        */ 

}

//Call the API to get the first joke as soon as the page loads
