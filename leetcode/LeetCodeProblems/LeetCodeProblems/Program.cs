// See https://aka.ms/new-console-template for more information
using LeetCodeProblems;

Console.WriteLine("Hello, World!");

//var result = TwoSums.TwoSumMakingNumber(new int[] { -3, 2, 3, 4, 6, 8, 9 }, 0);

//var result = ThreeSumProblem.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
//var result = ThreeSumProblem.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4, -2, -3, 3, 0, 4 });
var result = MergedSortedArray.FindMedianSortedArrays(
    new int[] { 1, 1, 1 },
    new int[] { 1, 1, 1 }
    );


Console.WriteLine(result);
//Console.WriteLine(String.Join(" | ", result.Select(s => "[" + string.Join(",", s) + "]")));
