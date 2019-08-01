namespace csharpcore.updater
{
    public class BackstagePassUpdater : Updater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            // Quality drops to 0 after the concert
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches
            // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
            else if (item.SellIn < 5)
            {
                item.Quality += 3;
            }
            else if(item.SellIn < 10)
            {
                item.Quality += 2;
            } else
            {
                item.Quality++;
            }

            // The Quality of an item is never more than 50
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}