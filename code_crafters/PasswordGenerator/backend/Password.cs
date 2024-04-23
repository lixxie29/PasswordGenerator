using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace backend;

public class Password
{
    public string value;
    public bool isValid;

    public Password(string value)
    {
        this.value = value;
        isValid = true;
    }

    public bool IsValid
    {
        get { return isValid; }
    }

    public bool isPasswordValid(int secLeft)
    {
        if (secLeft > 0) return true;
        return false;
    }

    public string toString()
    {
        return this.value;
    }
}

