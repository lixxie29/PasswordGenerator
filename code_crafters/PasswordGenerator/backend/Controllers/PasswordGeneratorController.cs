using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/generate")]

public class PasswordGeneratorController : ControllerBase
{
    private Password password;

    [HttpPost]
    public IActionResult GeneratePassword(){
        password = GenPassValue();
        string value = new string(password.value);
        return Ok(new {value});
    }

    [HttpPost("valid")]
        public IActionResult UpdatePasswValidity([FromBody] int timeLeft)
        {
            if (password != null)
            {
                bool status = password.isPasswordValid(timeLeft);
                password.isValid = status;
                Console.WriteLine(password.isValid);
                return Ok();
            }
            return NotFound("password not found, please generate one");
        }
    
    
    
    
    private static readonly Random random = new Random();

    public Password GenPassValue()
    {
        // --> generate 6 random letters
        char[] randomLetters = GenerateRandomLetters(6);

        // --> get current time
        DateTime currentTime = DateTime.Now;
        int second = currentTime.Second;
        int millisec = (currentTime.Millisecond)%100;

        // --> get current month
        int month = currentTime.Month;

        // --> association of the zodiac signs to months
        string zodiacSign = GetZodiacSign(month);

        // --> conversion of zodiac signs to numbers
        int zodiacNumber = GetZodiacNumber(zodiacSign);

        //string generatedPassword = $"{randomLetters[0]}{second}{randomLetters[1]}{randomLetters[2]}{zodiacNumber}{randomLetters[3]}{randomLetters[4]}{millisec}{randomLetters[5]}";
        //password = new Password($"{randomLetters[0]}{second}{randomLetters[1]}{randomLetters[2]}{zodiacNumber}{randomLetters[3]}{randomLetters[4]}{millisec}{randomLetters[5]}");

        password.value = ($"{randomLetters[0]}{second}{randomLetters[1]}{randomLetters[2]}{zodiacNumber}{randomLetters[3]}{randomLetters[4]}{millisec}{randomLetters[5]}");
        return password;
    }



    private string GetZodiacSign(int month)
    {
        // determine the zodiac sign based on the month
        switch (month)
        {
            case 1:
                return "capricorn";
            case 2:
                return "aquarius";
            case 3:
                return "pisces";
            case 4:
                return "aries";
            case 5:
                return "taurus";
            case 6:
                return "gemini";
            case 7:
                return "cancer";
            case 8:
                return "leo";
            case 9:
                return "virgo";
            case 10:
                return "libra";
            case 11:
                return "scorpio";
            case 12:
                return "sagittarius";
            default:
                throw new ArgumentOutOfRangeException(nameof(month), "invalid month");
        }
    }



    private int GetZodiacNumber(string zodiacSign)
    {
        // assign numeric values to zodiac signs
        switch (zodiacSign)
        {
            case "capricorn":
                return 64918;
            case "aquarius":
                return 49081;
            case "pisces":
                return 91563;
            case "aries":
                return 48135;
            case "taurus":
                return 74805;
            case "gemini":
                return 63810;
            case "cancer":
                return 64038;
            case "leo":
                return 13027;
            case "virgo":
                return 01860;
            case "libra":
                return 11684;
            case "scorpio":
                return 56890;
            case "sagittarius":
                return 54678;
            default:
                throw new ArgumentException("invalid zodiac sign", nameof(zodiacSign));
        }
    }



    private char[] GenerateRandomLetters(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        char[] randomLetters = new char[length];
        for (int i = 0; i < length; i++)
        {
            randomLetters[i] = chars[random.Next(chars.Length)];
        }
        return randomLetters;
    }
}

