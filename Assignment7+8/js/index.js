var jokeOutput;
//  setTimeout(jokeOutput.tellJoke(), 4000); // TODO TEST will wait 4 seconds between telling jokes : NOTE UNTESTED , make sure it isn't in an infinite loop. 
//NOTE: TODO: you can call getJoke instead for immediate output I think or jokeOutput
//above could also potentially be more like the other example from class: 
/*
        from class Lecture15-web
        console.log(new Joke().getJoke());
        setInterval(function() {console.log(new Joke().getJoke();)}, 4000); //may also wait 4 seconds, however, one of these will cause an issue iirc 

*/

function apiLink() {
    window.location.href = 'https://v2.jokeapi.dev/joke/Programming';
}

function getJoke() {
    axios({
        joke: 'get',
        url: 'https://v2.jokeapi.dev/joke/Programming'
    })
        .then(function (response) {
            console.log(response);
            //console.log(response.data.setup);
            //console.log(response.data.delivery);
            //console.log(response.data.joke)
            if (response.data.type == "twopart") {
                jokeOutput = {
                    "type": response.data.type,
                    "setup": response.data.setup,
                    "delivery": response.data.delivery
                };
            } else {
                jokeOutput = {
                    "type": response.data.type,
                    "joke": response.data.joke
                };
            }
            //console.log(jokeOutput);
            return jokeOutput;
        })
        .catch(function (error) {
            console.log("status code: " + error + " Try again in a few seconds..."); //TODO make more specifi
        });
}

document.getElementById("joke").addEventListener("click", function () {
    console.log(jokeOutput);
});

setTimeout(getJoke, 400 );
//Call the API to get the first joke as soon as the page loads
//Joke API syntax: {error, category, type (number of parts), (if more than one part i.e. setup, delivery it will put them down ), joke, flags (default-false) {nsfw, religious, political, racist, sexist, explicit}}, id, safe, lang
//jokes from https://v2.jokeapi.dev/joke/Programming

function tellJoke() {
    
    let jokeSetup = jokeOutput.setup;
    let jokeDelivery = jokeOutput.delivery;
    let jokeJoke = jokeOutput.joke
    console.log("Setup: " + jokeOutput.setup + "\n\n" + "Delivery: " + jokeOutput.delivery + "\n\n" + "Joke: " + jokeOutput.joke);

    
    let setup = document.getElementById('setup');
    let delivery = document.getElementById('delivery');

    if(jokeOutput.type == "twopart"){
        setup.innerText = jokeSetup;    
        delivery.innerText = jokeDelivery; 
    }
    else
    {
        setup.innerText = jokeJoke;    
        delivery.innerText = ""; 
    }
    setTimeout(getJoke, 400);
}

function toggleMenu() {
    document.getElementById("drop-down-menu").hidden = !document.getElementById("drop-down-menu").hidden;
}

document.getElementById("menu-button").addEventListener("click", toggleMenu);
document.getElementById("get-joke").addEventListener("click", tellJoke);
document.getElementById("joke-api").addEventListener("click", apiLink);

