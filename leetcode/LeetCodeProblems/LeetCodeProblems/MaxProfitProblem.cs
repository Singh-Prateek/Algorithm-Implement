namespace LeetCodeProblems;

public class MaxProfitProblem
{
    public static void Run()
    {
        Runner("7,1,9");
        Runner("7,1,4,2,3");
        Runner("7,1,4,2,3,9");
        Runner("7,4,3,2");

    }
    static void Runner(string prices)
    {

        var pricesArray = prices.Split(',').Select(int.Parse).ToArray();
        var idxs = MaxProfit(pricesArray);
        Console.WriteLine("source:{0}\tbuy: {1}\t sell: {2}\tmaxValue: {3}",
            prices,
            idxs.b, idxs.s, idxs.max);
    }

    /// <summary>
    /// two pointer: left looks for buy and right for sell
    /// if there is a minimum value, reset buy pointer.
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    static (int b, int s, int max) MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int currentProfit = 0;

        int buyPtr = 0;
        int sellPtr = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < prices[buyPtr])
            {
                buyPtr = i;
            }

            currentProfit = prices[i] - prices[buyPtr];

            if (maxProfit < currentProfit)
            {
                sellPtr = i;
                maxProfit = currentProfit;
            }

        }

        return (buyPtr, maxProfit == 0 ? -1 : sellPtr, maxProfit);

    }


    /// <summary>
    /// could lead to multiple buy and sell.
    /// It maximize profit but did not convined myself it is a good solution.
    /// as question specify only one transaction.
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    static int MaxProfitTwo(int[] prices)
    {
        int mP = 0;
        int rP = 0;

        for (int i = 1; i < prices.Length; i++)
        {

            rP += prices[i] - prices[i - 1];


            mP = Math.Max(rP, mP);
            //Console.WriteLine("running: {0} \t max: {1};\t i:{2}", rP, mP, i);

            if (rP < 0)
            {
                rP = 0;
            }
        }

        return mP;
    }
}

