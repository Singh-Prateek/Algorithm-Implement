using System;

namespace LeetCodeProblems;

public class DecimalNumsToRomanNums
{
    public static string IntToRoman(int num)
    {
        string result = "";

        Dictionary<int, string> romanDict = new Dictionary<int, string>(){
        {1000,"M"},
        {900,"CM"},
        { 500, "D"},
        { 400,"CD"},
        { 100,"C"},
        { 90,"XC"},
        { 50, "L"},
        { 40,"XL"},
        { 10,"X"},
        { 9,"IX"},
        { 5,"V"},
        { 4,"IV"},
        { 1,"I"},
    };

        foreach (int k in romanDict.Keys)
        {

            int tempVal = num / k;

            for (int j = tempVal; j > 0; j--)
            {
                result += romanDict[k];
            }

            num -= tempVal * k;

        }

        return result;

    }
}

