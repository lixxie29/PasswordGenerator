using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace backend;

 public class Password
{
    private string value;
    private bool isValid;

    public Password(string _value)
    {
        this.value = _value;
        isValid = true;
    }

    public string Value
    {
        get { return value; }
        set { this.value = value; 
        isValid = true;}
    }

    public bool IsValid
    {
        get { return isValid; }
    }

    public bool isPasswordValid(int timeLeft)
    {
        if (timeLeft < 0) { return false; }
        return true;
    }
 }

