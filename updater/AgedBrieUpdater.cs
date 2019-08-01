namespace csharpcore.updater
{
    public class AgedBrieUpdater : Updater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            
            // "Aged Brie" actually increases in Quality the older it gets
            if (item.SellIn >= 0)
            {
                item.Quality++;
            }
            else
            {
                item.Quality += 2;
            }

            // The Quality of an item is never negative
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
            // The Quality of an item is never more than 50
            else if(item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}