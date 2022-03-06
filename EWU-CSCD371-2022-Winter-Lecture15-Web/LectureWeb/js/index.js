var name = "Inigo Montoya";
var person = {
    name: "Inigo Montoya",
    age: function () {
        return new Date().getFullYear() - this.year;
    },
    year: 1987,
    weapon: "sword",
    getName: function () {
        return this.name;
    }
};

function showName() {
    console.log(this.name);
}
console.log("Hello World: " + person.getName() + " is " + person.age());

document.getElementById("mybutton").addEventListener("click", function () {
    console.log("Hello World: " + person.getName() + " is " + person.age());
});

axios({
    method: 'get',
    url: 'https://api.openweathermap.org/data/2.5/weather?units=imperial&lat=47.658&lon=-117.402&appid=e44ff6715c0c7c9bf43ce3bfe74fdb6f'
})
    .then(function (response) {
        console.log(response);
        console.log(response.data.main.temp);

        let weatherText = document.querySelector(".weather");
        weatherText.innerText = "Current Temp: " + response.data.main.temp;
    })
    .catch(function (error) {
        console.log(error);
    });

function writePerson() {

    console.log("Hello World: " + person.getName() + " is " + person.age());
    setTimeout(writePerson, 5000); 
}


setTimeout(writePerson, 5000); 

// setInterval(keepTime, 5000)
// var lastTime = new Date();
// var delayInMs = 5000;
// function keepTime(){
//     let now = Date();
//     if (now - lastTime > delayinMs){
//         // Run your code.

//         lasttime = now;
//     }    
// }
console.log(new Date().getTime());
setInterval(function() {console.log(new Date().getTime());}, 1000);