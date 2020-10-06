using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DojoDachi.Controllers
{
    public class Homecontroller : Controller
    {
        static Random rnd = new Random();

        [HttpGet("")]
        public  IActionResult Index()
        {
            if (!HttpContext.Session.GetInt32("fullness").HasValue) {
                Reset();
            }
            ViewBag.fullness  = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.meals     = HttpContext.Session.GetInt32("meals");
            ViewBag.energy    = HttpContext.Session.GetInt32("energy");
            ViewBag.status    = HttpContext.Session.GetString("status");
            return View("Index");
        }

        [HttpGet("reset")]
        public IActionResult Reset()
        {    
            HttpContext.Session.SetInt32("fullness" , 20);
            HttpContext.Session.SetInt32("happiness" , 20);
            HttpContext.Session.SetInt32("meals" , 3);
            HttpContext.Session.SetInt32("energy" , 85);
            HttpContext.Session.SetString("status", "Welcome! Click to play!");
            return RedirectToAction("Index");
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            var energy    = (Int32)HttpContext.Session.GetInt32("energy");
            var happiness = (Int32)HttpContext.Session.GetInt32("happiness");
            var fullness  = (Int32)HttpContext.Session.GetInt32("fullness");

            energy += 15;
            happiness -= 5;
            fullness -= 5;

            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("fullness", fullness);

            string status = "";
            if (energy >= 100 && happiness >= 100 && fullness >= 100) {
                status = "Congratulations! You won!";
            } else if (happiness <= 0 || fullness <= 0) {
                status = "Your Dojodachi has passed away ...";
            } else {
                status = "Your Dojodachi slept! Energy +15, Happiness -5, Fullness -5";
            }

            ViewBag.fullness  = HttpContext.Session.GetInt32("fullness");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.energy    = HttpContext.Session.GetInt32("energy");
            ViewBag.status    = HttpContext.Session.GetString("status");

            return Json(new {
                energy = energy,
                happiness = happiness,
                fullness = fullness,
                status = status
            });
        }

        [HttpGet("work")]
        public IActionResult work()
        {
            var energy = (Int32)HttpContext.Session.GetInt32("energy");
            var meals  = (Int32)HttpContext.Session.GetInt32("meals");
            var happiness = (Int32)HttpContext.Session.GetInt32("happiness");
            var fullness  = (Int32)HttpContext.Session.GetInt32("fullness");
            energy -= 5;
            meals += rnd.Next(1,4);
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("meals", meals);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("fullness", fullness);

             string status = "";
            if (energy >= 100 && happiness >= 100 && fullness >= 100) {
                status = "Congratulations! You won!";
            } else if (happiness <= 0 || fullness <= 0) {
                status = "Your Dojodachi has passed away ...";
                
            } else {
                status = $"Your Dojodachi worked! Energy -5, meals {meals}";
            }

            ViewBag.energy   = HttpContext.Session.GetInt32("energy");
            ViewBag.meals    = HttpContext.Session.GetInt32("meals");
            ViewBag.status   = HttpContext.Session.GetString("status");

            return Json(new {
                energy = energy,
                meals = meals,
                happiness = happiness,
                fullness = fullness,
                status = status
            });                   
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            var energy = (Int32)HttpContext.Session.GetInt32("energy");
            var meals  = (Int32)HttpContext.Session.GetInt32("meals");
            var happiness = (Int32)HttpContext.Session.GetInt32("happiness");
            var fullness  = (Int32)HttpContext.Session.GetInt32("fullness");
            int rndFullness = 0;
            if(meals > 0) {
                var full = rnd.Next(0,4);
                if(full != 0) {
                    rndFullness = rnd.Next(5,11);
                    fullness += rndFullness;  
                }
                meals -= 1;
            }
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("meals", meals);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("fullness", fullness);

             string status = "";
            if (energy >= 100 && happiness >= 100 && fullness >= 100) {
                status = "Congratulations! You won!";
            } else if (happiness <= 0 || fullness <= 0) {
                status = "Your Dojodachi has passed away ...";
            } else {
                status = $"You feed your Dojodachi! Fullness + {rndFullness} , meals -1. ";
            }

            ViewBag.meals    = HttpContext.Session.GetInt32("meals");
            ViewBag.status   = HttpContext.Session.GetString("status");

            return Json(new {
                energy = energy,
                meals = meals,
                fullness = fullness,
                status = status
            });

        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            var energy = (Int32)HttpContext.Session.GetInt32("energy");
            var happiness = (Int32)HttpContext.Session.GetInt32("happiness");
            var fullness  = (Int32)HttpContext.Session.GetInt32("fullness");
            var meals = (Int32)HttpContext.Session.GetInt32("meals");
            var unhappy = rnd.Next(0,4);
            int rndHappiness = 0;
            if(unhappy != 0) 
            {   rndHappiness = rnd.Next(5,11);
                happiness += rndHappiness;
            }
            energy -= 5;
        
            HttpContext.Session.SetInt32("energy", energy);
            HttpContext.Session.SetInt32("happiness", happiness);
            HttpContext.Session.SetInt32("fullness", fullness);
            HttpContext.Session.SetInt32("meals", meals);

             string status = "";
            if (energy >= 100 && happiness >= 100 && fullness >= 100) {
                status = "Congratulations! You won!";
            } else if (happiness <= 0 || fullness <= 0) {
                status = "Your Dojodachi has passed away ...";
            } else {
                status = $"You played with your Dojodachi! Happiness + {rndHappiness} , Energy -5. ";
            }

            ViewBag.energy    = HttpContext.Session.GetInt32("energy");
            ViewBag.happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.status    = HttpContext.Session.GetString("status");
            ViewBag.meals    = HttpContext.Session.GetString("meals");

            return Json(new {
                energy = energy,
                happiness = happiness,
                fullness = fullness,
                status = status,
                meals = meals,
            });

        }
    }
}