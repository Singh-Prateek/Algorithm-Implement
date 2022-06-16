namespace Hackerrank.StringManipulation;

public class SpecialString
{

    public long RunAlgo()
    {
        return substrCount(5, "aabaa");
    }

    static bool IsSpecialString(int n, string s)
    {
        bool result = true;
        char start = s[0];
        int middle = (n / 2);
        bool isOdd = n % 2 == 1;
        for (int i = 1; i < n; i++)
        {
            if (!(start == s[i] || (isOdd && i == middle)))
            {
                result = false;
                break;
            }
        }

        return result;
    }
    // Complete the substrCount function below.
    private long substrCountBig(int n, string s)
    {

        long result = 0;

        for (int len = 1; len <= n; len++)
        {
            for (int i = 0; i <= n - len; i++)
            {
                Console.WriteLine(s.Substring(i, len));

                if (IsSpecialString(len, s.Substring(i, len)))
                {
                    result++;
                }
            }
        }

        return result;
    }

    private long substrCount(int n, string s)
    {
        long result = 0;
        List<KeyValuePair<char, int>> f = new List<KeyValuePair<char, int>>();

        char poleStar = s[0];
        int runningCount = 1;


        for (int i = 1; i < n; i++)
        {
            if (poleStar == s[i])
            {
                runningCount++;
            }
            else
            {
                f.Add(new KeyValuePair<char, int>(poleStar, runningCount));
                poleStar = s[i];
                runningCount = 1;
            }
        }

        f.Add(new KeyValuePair<char, int>(poleStar, runningCount));

        foreach (var (c, v) in f)
        {
            result += v * (v + 1) / 2;
        }

        for (int i = 1; i < f.Count; i++)
        {
            if (i + 1 >= f.Count) continue;

            var prev = f[i - 1];
            var next = f[i + 1];

            if (prev.Key == next.Key && f[i].Value == 1)
            {
                result += Math.Min(prev.Value, next.Value);
            }

        }


        return result;

    }
}