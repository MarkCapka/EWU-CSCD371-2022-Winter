var jokeOutput;



    Console.log(jokeOutput.getJoke());
    

    console.log("This is the joke i'll be calling from the API: " + jokeOutput.getJoke());

  //  setTimeout(jokeOutput.tellJoke(), 4000); // TODO TEST will wait 4 seconds between telling jokes : NOTE UNTESTED , make sure it isn't in an infinite loop. 
    //NOTE: TODO: you can call getJoke instead for immediate output I think or jokeOutput
    //above could also potentially be more like the other example from class: 
    /*
            from class Lecture15-web
            console.log(new Joke().getJoke());
            setInterval(function() {console.log(new Joke().getJoke();)}, 4000); //may also wait 4 seconds, however, one of these will cause an issue iirc 

    */

function apiLink(){
    window.location='https://v2.jokeapi.dev/joke/Programming';
}

function getJoke() {

    return this.jokeOutput;
}

console.log("Joke print from javascript: " + jokeOutput.getJoke());

document.getElementById("joke").addEventListener("click", function () {
    console.log(jokeOutput);
});

jokeOutput = axios({
    joke: 'get',
    url: 'https://v2.jokeapi.dev/joke/Programming'
})
    .then(function (response) {
        console.log(response);   //TODO come back and make this more intent revealing'
        console.log(response.data.main.joke); //TODO haven't tested yet 


    })
    .catch(function (error) {
        console.log("status code: " + error + " Try again in a few seconds..."); //TODO make more specific
        console.log(error.response.data);
        console.log(error.response.status);
        console.log(error.response.header);

    });
//Call the API to get the first joke as soon as the page loads
//Joke API syntax: {error, category, type (number of parts), (if more than one part i.e. setup, delivery it will put them down ), joke, flags (default-false) {nsfw, religious, political, racist, sexist, explicit}}, id, safe, lang
//jokes from https://v2.jokeapi.dev/joke/Programming
function tellJoke() {
    //Put the joke directly in the joke array variable
   // if (document.querySelector(".joke")) {
        let jokeOutput = document.querySelector("joke");
        Console.log("Joke: " + jokeOutput);
  //  }
 //   else    //type: twopart 
 //   {
        let setup = document.querySelector('#jokeOutput-setup');
        jokeElement.innerText = 'Setup: ${setup}';
        jokeDiv.append(this.jokeElement);

        let delivery = document.querySelector('#jokeOutput-delivery');
        jokeElement.innerText = 'Delivery: ${delivery}';
        jokeDiv.append(thiis.jokeElement);
        // jokeSetup = jokeDiv[0];
        // jokeDelivery = jokeDiv[1];
        // jokeOutput = ("Setup: " + jokeSetup + "\n"
        // + "Delivery: " + jokeDelivery);]
        this.jokeOutput = jokeDiv;

        Console.log("Setup: " + jokeDiv[0] + "\n\n" +"Delivery: " + jokeDiv[1]);

 }