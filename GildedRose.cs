using csharpcore.updater;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        public static readonly string AGED_BRIE = "Aged Brie";
        public static readonly string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public static readonly string BACKSTAGE_PASS = "Backstage passes to a TAFKAL80ETC concert";
        public static readonly string DEFAULT_ITEM = "A piece of thread";
        public static readonly string CONJURED_CAKE = "Conjured Mana Cake";

        private readonly IList<Item> Items;
        private readonly UpdateFactory UpdateFactory;

        public GildedRose(IList<Item> Items,
            UpdateFactory UpdateFactory)
        {
            this.Items = Items;
            this.UpdateFactory = UpdateFactory;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                var updater = UpdateFactory.Build(item);
                updater.UpdateQuality(item);
            }
        }
    }
}
