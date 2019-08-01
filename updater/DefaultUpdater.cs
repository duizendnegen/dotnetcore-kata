namespace csharpcore.updater
{
    public class DefaultUpdater : Updater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            if (item.SellIn >= 0)
            {
                item.Quality -= 1;
            }
            // Once the sell by date has passed, Quality degrades twice as fast
            else
            {
                item.Quality -= 2;
            }

            // The Quality of an item is never negative
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
