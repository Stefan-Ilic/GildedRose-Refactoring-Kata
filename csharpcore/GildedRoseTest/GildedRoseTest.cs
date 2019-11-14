
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
    }
}