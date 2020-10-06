document.addEventListener("DOMContentLoaded", function(){
    let feed = document.getElementById("feed");
    let play = document.getElementById("play");
    let work = document.getElementById("work");
    let sleep = document.getElementById("sleep");

    let fullness = document.getElementById("fullness");
    let happiness = document.getElementById("happiness");
    let meals = document.getElementById("meals");
    let energy = document.getElementById("energy");

    let status = document.getElementById("status");
    let buttons = document.getElementById("buttons");

    feed.onclick = function() {
        console.log("Feed");
        fetch('feed')
            .then(data => data.json())
            .then(data =>{
                console.log(data);
                energy.textContent = data.energy;
                meals.textContent = data.meals;
                status.textContent = data.status;
                fullness.textContent = data.fullness;
                happiness.textContent = data.happiness;
                if(status.textContent == "Your Dojodachi has passed away ..." || 
                    status.textContent == "Congratulations! You won!") {
                        buttons.innerHTML = `<a href="reset"><button>Reset?</button></a>`
                }
        })
    }

    play.onclick = function() {
        console.log("Play");
        fetch('play')
            .then(data => data.json())
            .then(data =>{
                console.log(data);
                energy.textContent = data.energy;
                meals.textContent = data.meals;
                status.textContent = data.status;
                fullness.textContent = data.fullness;
                happiness.textContent = data.happiness;
                if(status.textContent == "Your Dojodachi has passed away ..." || 
                    status.textContent == "Congratulations! You won!") {
                        buttons.innerHTML = `<a href="reset"><button>Reset?</button></a>`
                }
            })
    }

    work.onclick = function() {
        console.log("Work");
        fetch('work')
            .then(data => data.json())
            .then(data =>{
                console.log(data);
                energy.textContent = data.energy;
                meals.textContent = data.meals;
                status.textContent = data.status;
                fullness.textContent = data.fullness;
                happiness.textContent = data.happiness;
                if(status.textContent == "Your Dojodachi has passed away ..." || 
                    status.textContent == "Congratulations! You won!") {
                        buttons.innerHTML = `<a href="reset"><button>Reset?</button></a>`
                }
            })
    }

    sleep.onclick = function() {
        console.log("Sleep");
        fetch('sleep')
            .then(data => data.json())
            .then(data => {
                console.log(data);
                fullness.textContent = data.fullness;
                happiness.textContent = data.happiness;
                energy.textContent = data.energy;
                status.textContent = data.status;
                if(status.textContent == "Your Dojodachi has passed away ..." || 
                    status.textContent == "Congratulations! You won!") {
                        buttons.innerHTML = `<a href="reset"><button>Reset?</button></a>`
                }
            })
    }
})