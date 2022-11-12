namespace LeetCodeProblems;

public class MaxProfitProblem
{
    public static void Run(int[] prices)
    {
        var pricesStr = string.Join(',',prices);
        Console.WriteLine("1-source:{0} \tmax: {1}",pricesStr, MaxProfit(prices));
        Console.WriteLine("2-source:{0} \tmax: {1}",pricesStr ,MaxProfitTwo(prices));
    }

    static int MaxProfit(int[] prices)
    {
        int mP = 0;
        int rP = 0;

        int mbIdx = 0;

        for (int i = 1; i < prices.Length; i++)
        {

            rP = prices[i] - prices[mbIdx];

            if (prices[i] < prices[mbIdx])
            {
                mbIdx = i;
            }

            mP = Math.Max(mP, rP);

        }

        return mP;

    }

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

