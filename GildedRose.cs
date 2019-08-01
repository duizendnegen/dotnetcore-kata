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

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                // At the end of each day our system lowers the Quality value which denotes how valuable the item is
                if (item.Name != AGED_BRIE && item.Name != BACKSTAGE_PASS)
                {
                    if (item.Quality > 0)
                    {
                        // "Conjured" items degrade in Quality twice as fast as normal items
                        if (item.Name == CONJURED_CAKE)
                        {
                            item.Quality = item.Quality - 2;
                        }
                        // "Sulfuras", being a legendary item, never decreases in Quality
                        // all other items do
                        else if (item.Name != SULFURAS)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                // "Aged Brie" actually increases in Quality the older it gets
                // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less
                        if (item.Name == BACKSTAGE_PASS)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                // "Sulfuras", being a legendary item, never has to be sold
                if (item.Name != SULFURAS)
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != AGED_BRIE)
                    {
                        if (item.Name != BACKSTAGE_PASS)
                        {
                            if (item.Quality > 0)
                            {
                                // "Conjured" items degrade in Quality twice as fast as normal items
                                if (item.Name == CONJURED_CAKE)
                                {
                                    item.Quality = item.Quality - 2;
                                }
                                // Once the sell by date has passed, Quality degrades twice as fast
                                else if (item.Name != SULFURAS)
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            // Quality drops to 0 after the concert
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        // The Quality of an item is never more than 50
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }

                // The Quality of an item is never negative
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }
}
