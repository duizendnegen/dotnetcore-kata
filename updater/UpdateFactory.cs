namespace csharpcore.updater
{
    public class UpdateFactory
    {
        public Updater Build(Item item)
        {
            if (item.Name == GildedRose.AGED_BRIE)
            {
                return new AgedBrieUpdater();
            }
            else if (item.Name == GildedRose.BACKSTAGE_PASS)
            {
                return new BackstagePassUpdater();
            }
            else if(item.Name == GildedRose.CONJURED_CAKE)
            {
                return new ConjuredCakeUpdater();
            }
            else if(item.Name == GildedRose.SULFURAS)
            {
                return new SulfurasUpdater();
            }

            return new DefaultUpdater();
        }
    }
}
