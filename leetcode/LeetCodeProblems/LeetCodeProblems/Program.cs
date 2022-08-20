// See https://aka.ms/new-console-template for more information
using LeetCodeProblems;

Console.WriteLine("Hello, World!");

//var result = TwoSums.TwoSumMakingNumber(new int[] { -3, 2, 3, 4, 6, 8, 9 }, 0);

//var result = ThreeSumProblem.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
//var result = ThreeSumProblem.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 });
var result = ThreeSumProblem.ThreeSum2(new int[] { -5, 0, -2, 3, -2, 1, 1, 3, 0, -5, 3, 3, 0, -1 });
var result2 = ThreeSumProblem.ThreeSum(new int[] { -5, 0, -2, 3, -2, 1, 1, 3, 0, -5, 3, 3, 0, -1 });


Console.WriteLine(String.Join(" | ", result.Select(s => "[" + string.Join(",", s) + "]")));
Console.WriteLine(String.Join(" | ", result2.Select(s => "[" + string.Join(",", s) + "]")));