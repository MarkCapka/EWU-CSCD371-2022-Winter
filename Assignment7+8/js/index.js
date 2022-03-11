//Variable to cache the next joke to avoid delay when pressing the button
var jokeOutput;

//Retrieve and store a joke from the API
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
            console.log("status code: " + error + " Try again in a few seconds..."); 
        });
}

//Print the joke to the page
function tellJoke() {
    
    let jokeSetup = jokeOutput.setup;
    let jokeDelivery = jokeOutput.delivery;
    let jokeJoke = jokeOutput.joke
    console.log("Setup: " + jokeOutput.setup + "\n\n" + "Delivery: " + jokeOutput.delivery + "\n\n" + "Joke: " + jokeOutput.joke);

    
    let setup = document.getElementById('setup');
    let delivery = document.getElementById('delivery');

    if(jokeOutput.type == "twopart"){
        setup.innerText = jokeSetup;    
        setTimeout(getJoke, 4000);
        delivery.innerText = jokeDelivery; 
    }
    else
    {
        setup.innerText = jokeJoke;    
        delivery.innerText = ""; 
        setTimeout(getJoke, 500);
    }
    
}

//Event listener for the button with button functions
function toggleMenu() {
    document.getElementById("drop-down-menu").hidden = !document.getElementById("drop-down-menu").hidden;
}

function apiLink() {
    window.location.href = 'https://v2.jokeapi.dev/';
}

function rollNo1(){
    toggleMenu()
    document.getElementById("body").style = "transform:rotate(360deg);transition: 4s;";
    setTimeout(function(){
        document.getElementById("body").style = "";
    }, 4100);
}

function rollNo2(){
    toggleMenu()
    window.location.href = 'https://www.youtube.com/watch?v=ub82Xb1C8os';
}

function rollNo3(){
    document.getElementById("body").insertAdjacentHTML('afterbegin',
    '<iframe width="100%" height="719" style="pointer-events:none;" src="http://www.youtube.com/embed/dQw4w9WgXcQ?autoplay=1&showinfo=0&controls=0" title="YouTube video player" frameborder="0" allow="autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen autoplay></iframe></div>');
    //move down 719px
    document.getElementById("drop-down-menu").style="transform:translateY(740px);transition: 4s;";
}

function rollNo4(){
    toggleMenu()
    document.getElementById("body").style = "transform:rotate(-360deg);transition: 4s;";
    setTimeout(function(){
        document.getElementById("body").style = "";
    }, 4100);
}
document.getElementById("menu-button").addEventListener("click", toggleMenu);
document.getElementById("get-joke").addEventListener("click", tellJoke);
document.getElementById("joke-api").addEventListener("click", apiLink);
document.getElementById("roll1").addEventListener("click", rollNo1);
document.getElementById("roll2").addEventListener("click", rollNo2);
document.getElementById("roll3").addEventListener("click", rollNo3);
document.getElementById("roll4").addEventListener("click", rollNo4);


//Prep a joke and begin displaying it on the page
setTimeout(getJoke, 400 );
tellJoke();
