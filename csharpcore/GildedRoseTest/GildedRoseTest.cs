﻿
using System;
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
    }
}