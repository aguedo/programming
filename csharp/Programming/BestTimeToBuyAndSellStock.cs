namespace Programming;

public class BestTimeToBuyAndSellStock
{
    public int MaxProfit(int[] prices)
    {
        if (prices == null || prices.Length == 0)
        {
            return 0;
        }

        int bestProfit = 0;
        int left = 0;

        for (int right = 1; right < prices.Length; right++)
        {
            int leftPrice = prices[left];
            int rightPrice = prices[right];

            if (leftPrice < rightPrice)
            {
                int profit = rightPrice - leftPrice;
                if (profit > bestProfit)
                {
                    bestProfit = profit;
                }
            }
            else if (leftPrice > rightPrice)
            {
                left = right;
            }
        }

        return bestProfit;
    }
}
