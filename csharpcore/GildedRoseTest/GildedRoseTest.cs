
using GildedRose;
using Shouldly;
using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void NormalItem_QualityLoweredByOne()
        {
            var item = new Item { Name = "Item", Quality = 3, SellIn = 4 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(2);
        }
        
        [Fact]
        public void NormalItem_SellInLoweredByOne()
        {
            var item = new Item { Name = "Item", Quality = 3, SellIn = 4 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.SellIn.ShouldBe(3);
        }
        
        [Fact]
        public void SellInPassed_QualityLoweredByTwo()
        {
            var item = new Item { Name = "Item", Quality = 3, SellIn = 0 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(1);
        }
        
        [Fact]
        public void ItemQuality_CannotSinkBelowZero()
        {
            var item = new Item { Name = "Item", Quality = 0, SellIn = 3 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(0);
        }
        
        // [Fact]
        // public void ItemQuality_CannotBeNegative()
        // {
        //     // If altering Item was allowed I would add this test
        //     Should.Throw<ArgumentException>(() => new Item { Quality = -1  });
        // }
        
        [Fact]
        public void AgedBrie_IncreasesQuality()
        {
            var item = new Item { Name = "Aged Brie", Quality = 4, SellIn = 3 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(5);
        }
        
        [Fact]
        public void AgedBrie_DoesNotIncreaseBeyond50()
        {
            var item = new Item { Name = "Aged Brie", Quality = 50, SellIn = 3 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(50);
        }
        
        [Fact]
        public void Sulfuras_NeverChanges()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = 4, SellIn = 3 };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(4);
            item.SellIn.ShouldBe(3);
        }
        
        [Theory]
        [InlineData(11, 4, 5)]
        [InlineData(11, 50, 50)]
        [InlineData(10, 4, 6)]
        [InlineData(10, 50, 50)]
        [InlineData(9, 4, 6)]
        [InlineData(5, 4, 7)]
        [InlineData(5, 50, 50)]
        [InlineData(4, 4, 7)]
        public void BackStagePasses_IncreasesQuality(int sellIn, int quality, int expectedQuality)
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality  };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(expectedQuality);
        }
        
        [Fact]
        public void BackStagePasses_QualityZeroAfterConcert()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5  };
            var gildedRose = new GildedRose.GildedRose(new[] {item});
            
            gildedRose.UpdateQuality();
            
            item.Quality.ShouldBe(0);
        }
    }
}