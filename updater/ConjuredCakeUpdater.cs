namespace csharpcore.updater
{
    public class ConjuredCakeUpdater : Updater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            // "Conjured" items degrade in Quality twice as fast as normal items
            if (item.SellIn >= 0)
            {
                item.Quality -= 2;
            }
            // Once the sell by date has passed, Quality degrades twice as fast
            else
            {
                item.Quality -= 4;
            }

            // The Quality of an item is never negative
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}