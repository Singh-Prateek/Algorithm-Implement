// See https://aka.ms/new-console-template for more information
using System;
using LeetCodeProblems;
using static LeetCodeProblems.ValidParentheses;

Console.WriteLine("Hello, World!");

Console.WriteLine(LongestSubString.LengthOfLongestSubstring("abcabcbb"));

Console.ReadKey();

/*
"8io43a985bsnsyjoyvjwlfjcl1vtklq6k1wge4cvov1d2ruzlid8xkihejezcip2rband59"
"34985bsnsyjoyvjw1fjcl"
[["o","0"],["a","4"],["4","a"],["7","t"],["1","l"],["t","7"]]
"6twu7otvh677372m6r7u0aa9sr7xkchqmd44ij8wjeq82hsgaesckty82b6u3unz0uieko10a3"
"6twu7otvh677372m6r7u0a495r7xkchqmd44ij8wjeq82h5gaesckty82b6u3unz0ulekol0"
[["l","i"],["5","s"],["l","1"],["4","a"]]

"scvpa54xi1lvv95rxfg154zm06qo5oomqy3s5ie5uxy48hzd8j53orxyzhs3280g1jj1mvb76dtffde3ar"
"4xi1lvv95rxfg154zm06qo5oomqy3s5l35uxy4bhzdbj5eorxyzhs3280g1jjlmvb76d"
[["t","7"],["4","a"],["7","t"],["e","3"],["l","1"],["l","i"],["3","e"],["b","8"]]
 */

//Console.WriteLine(MatchReplacement(
//    "scvpa54xi1lvv95rxfg154zm06qo5oomqy3s5ie5uxy48hzd8j53orxyzhs3280g1jj1mvb76dtffde3ar",
//    "4xi1lvv95rxfg154zm06qo5oomqy3s5l35uxy4bhzdbj5eorxyzhs3280g1jjlmvb76d", new char[][]
//{
//new char[] {'t','7'},
//new char[] {'4','a'},
//new char[] {'7','t'},
//new char[] {'e','3'},
//new char[] {'l','1'},
//new char[] {'l','i'},
//new char[] {'3','e'},
//new char[] {'b','8'}
//}));

//Console.WriteLine(MatchReplacement("cp59vpft3ub", "cp59vpft3ub", new char[][]
//{
//    new char[] { 'e', '3' },
//    new char[] { '0', 'o' },
//    new char[] { '3', 'e' },
//}));

//Console.WriteLine(MatchReplacement("8io43a985bsnsyjoyvjwlfjcl1vtklq6k1wge4cvov1d2ruzlid8xkihejezcip2rband59", "34985bsnsyjoyvjw1fjcl", new char[][]
//{
//    new char[] { 'o', '0' },
//    new char[] { 'a', '4' },
//    new char[] { '4', 'a' },
//    new char[] { '7', 't' },
//    new char[] { '1', 'l' },
//    new char[] { 't', '7' },
//}));

//Console.WriteLine(MatchReplacement("Fool33tbaR", "leetd", new char[][]
//{
//    new char[] { 'e', '3' },
//    new char[] { 't', '7' },
//    new char[] { 't', '8' },
//    new char[] { 'd', 'b' },
//    new char[] { 'p', 'b' },


//}));

//Console.WriteLine(InitializeLps("AABAACAABAA"));


int Reverse(int x)
{

    int result = 0;

    int max = int.MaxValue / 10;
    int min = int.MinValue / 10;

    while (x != 0)
    {
        int num = x % 10;

        if (result > max || result < min) return 0;

        result = result * 10 + num;

        x /= 10;
    }

    return result;

}

bool MatchReplacement(string s, string sub, char[][] mappings)
{
    Dictionary<(int, int), int> map = new Dictionary<(int, int), int>();

    for (int k = 0; k < mappings.Length; k++)
    {
        map.Add((mappings[k][1], mappings[k][0]), 1);
    }

    int m = sub.Length;
    int n = s.Length;

    int i = 0;
    int j = 0;

    int[] lps = InitializeLps(sub);

    while ((n - i) >= (m - j))
    {
        //var key = (s[i], sub[j]);

        if (s[i] == sub[j]) //|| (map.ContainsKey(key) && map[key] == 1))
        {
            i++;
            j++;

            //if (map.ContainsKey(key) && map[key] == 1)
            //{
            //    map[key] = 0;
            //}
        }
        if (j == m)
        {
            Console.WriteLine("pattern at {0}", i - j);
            //j = lps[j - 1];
            return true;
        }
        else if (i < n && s[i] != sub[j])
        {
            if (j != 0)
            {
                j = lps[j - 1];

            }
            else
            {
                i++;
            }
        }
    }



    return false;
}

int[] InitializeLps(string pattern)
{
    int m = pattern.Length;
    int[] result = new int[m];

    int i = 1;
    int lngPrefix = 0;
    result[0] = 0;

    while (i < m)
    {
        if (pattern[i] == pattern[lngPrefix])
        {
            lngPrefix++;
            result[i] = lngPrefix;
            i++;
        }
        else
        {
            if (lngPrefix != 0)
            {
                lngPrefix = result[lngPrefix - 1];
            }
            else
            {
                result[i] = lngPrefix;
                i++;
            }
        }
    }

    return result;
}


