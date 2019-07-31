using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private void TestItemChange(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(expectedSellIn, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }

        [Fact]
        public void DefaultItem_DecreasesInSellInAndQuality()
        {
            TestItemChange(GildedRose.DEFAULT_ITEM, 5, 10, 4, 9);
        }

        [Fact]
        public void DefaultItem_QualityIsNeverNegative()
        {
            TestItemChange(GildedRose.DEFAULT_ITEM, 5, 0, 4, 0);
        }

        [Fact]
        public void DefaultItem_DegradesAtDoubleSpeedAfterSellInExpired()
        {
            TestItemChange(GildedRose.DEFAULT_ITEM, -2, 10, -3, 8);
        }

        [Fact]
        public void AgedBrie_IncreasesInQuality()
        {
            TestItemChange(GildedRose.AGED_BRIE, 5, 10, 4, 11);
        }

        [Fact]
        public void AgedBrie_DoesntPass50AsQuality()
        {
            TestItemChange(GildedRose.AGED_BRIE, 5, 50, 4, 50);
        }

        [Fact]
        public void Sulfuras_DoesntChangeInQualityOrSellIn()
        {
            TestItemChange(GildedRose.SULFURAS, 5, 20, 5, 20);
        }

        [Fact]
        public void BackstagePass_IncreasesByOne()
        {
            TestItemChange(GildedRose.BACKSTAGE_PASS, 20, 20, 19, 21);
        }

        [Fact]
        public void BackstagePass_IncreasesByTwoTenDaysBeforeSellIn()
        {
            TestItemChange(GildedRose.BACKSTAGE_PASS, 10, 20, 9, 22);
        }

        [Fact]
        public void BackstagePass_IncreasesByThreeFiveDaysBeforeSellIn()
        {
            TestItemChange(GildedRose.BACKSTAGE_PASS, 5, 20, 4, 23);
        }

        [Fact]
        public void BackstagePass_DropsToZeroAfterSellIn()
        {
            TestItemChange(GildedRose.BACKSTAGE_PASS, 0, 20, -1, 0);
        }
    }
}