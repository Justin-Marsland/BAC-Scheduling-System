using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BACSchedulingSystem.Models;
using BACSchedulingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BACSchedulingSystem.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCards()
        {
            
            return View();//CardData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCards([Bind("firstname","lastname","cardnumber","cvv", "expDate", "address", "city", "state", "zipcode")]CardData card)
        {
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));

            return View(card);//CardData);
        }

        public IActionResult ConfirmCard(CardData data)
        {
            return View(data);
        }


        //acion method to validate credit card
        // is  onyl called to verify credit card
        [AcceptVerbs("GET", "POST")]
        public IActionResult ValidateCardNumber(string cardnumber)
        {
            bool checkcard;
            checkcard = CheckValidCardNumber(cardnumber);

            if (!checkcard)
                return Json($"Credit card info invalid");
            else
                return Json(true);
        }

        private static bool CheckValidCardNumber(string cardnumber)
        {
            try
            {
                // Create an array to contain cardnumber value
                ArrayList cardvalue = new ArrayList();
                // get the number of digit of the card
                int cardlength = cardnumber.ToString().Length;
                int sum_of_all_digits = 0;

                // First stage, double each alternating digits in cardnumber provided
                // starting with the second digit form the right then go backwards
                // loop from the end to the start
                for(int i = cardlength-2; i >= 0; i = i - 2)
                {
                    // add in the array each alternates digits after being doubled 
                    cardvalue.Add(Int32.Parse(cardnumber[i].ToString()) * 2);
                }

                // Second stage, separate digits into single ones and get the sum 
                for (int iCount = 0; iCount <= cardvalue.Count-1; iCount++)
                {
                    int sumofdigit = 0; // hold the sum of all digits

                    // check if current number has more than one digits
                    if((int)cardvalue[iCount] > 9)
                    {
                        // get the number of digits of the current value
                        int lengthofnumber = ((int)cardvalue[iCount]).ToString().Length;
                        // add all digits
                        for(int x = 0; x < lengthofnumber;x++)
                        {
                            sumofdigit = sumofdigit + Int32.Parse(
                                ((int)cardvalue[iCount]).ToString()[x].ToString());
                        }
                        
                    }
                    else
                    {
                        // single value are just stored till added to sum of all digits 
                        sumofdigit = (int)cardvalue[iCount];
                    }
                    // add sum to the total sum
                    sum_of_all_digits = sum_of_all_digits + sumofdigit; 
                }

                // Stage 3, add unaffected digits
                // starting from the first digit on the rightmost alternating digits
                int unaffected_digits = 0;
                for(int y = cardlength-1; y >= 0; y = y - 2)
                {
                    unaffected_digits = unaffected_digits + Int32.Parse(cardnumber[y].ToString());
                }

                // final stage
                // add both sum adn divide by 10
                // if the rest is 0 then the Card is valid
                // else its not valid 
                return (((unaffected_digits + sum_of_all_digits) % 10) == 0);
            }
            catch
            {
                return false;
            }

        }
    }
}