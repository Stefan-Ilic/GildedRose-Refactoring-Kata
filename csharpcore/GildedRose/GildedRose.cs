using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private SpecialItemRule[] _specialRules;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            var brieRule = new SpecialItemRule();
            brieRule.ItemName = AgedBrie;
            brieRule.Rules.Add((item => item.SellIn >= 0, -1, 1));
            brieRule.Rules.Add((item => item.SellIn < 0, -2, 1));
            
            var sulfurasRule = new SpecialItemRule();
            sulfurasRule.ItemName = Sulfuras;
            sulfurasRule.Rules.Add((item => true,  0, 0));
            
            var backStagePassesRule = new SpecialItemRule();
            backStagePassesRule.ItemName = BackstagePasses;
            backStagePassesRule.Rules.Add((item => item.SellIn <= 0, int.MinValue, 1));
            backStagePassesRule.Rules.Add((item => item.SellIn > 0 && item.SellIn <= 5, -3, 1));
            backStagePassesRule.Rules.Add((item => item.SellIn > 5 && item.SellIn <= 10, -2, 1));
            backStagePassesRule.Rules.Add((item => item.SellIn > 10, -1, 1));
            
            _specialRules = new[] {brieRule, sulfurasRule, backStagePassesRule};
            
            foreach (var item in _items)
            {
                if (ItemHasSpecialRules(item))
                {
                    ApplySpecialItemRules(item);
                }
                else
                {
                    ApplyDefaultRules(item);
                }

                EnsureQualityIsBetween(item, 0, 50);
            }
        }

        private static void EnsureQualityIsBetween(Item item, int lowerBound, int upperBound)
        {
            item.Quality = Math.Clamp(item.Quality, lowerBound, upperBound);
        }

        private static void ApplyDefaultRules(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality--;
            }
            else
            {
                item.Quality -= 2;
            }
            
            item.SellIn--;
        }

        private void ApplySpecialItemRules(Item item)
        {
            var rule = _specialRules.Single(x => x.ItemName == item.Name);
            var (_, qualityDecrease, sellInDecrease) = rule.Rules.Single(x => x.RuleShouldBeApplied(item));

            item.Quality -= qualityDecrease;
            item.SellIn -= sellInDecrease;
        }

        private bool ItemHasSpecialRules(Item item) => _specialRules.Select(x => x.ItemName).Contains(item.Name);
    }

    public class SpecialItemRule
    {
        public string ItemName { get; set; }
        public List<(Predicate<Item> RuleShouldBeApplied, int QualityDecrease, int SellInDecrease)> Rules { get; set; } = new List<(Predicate<Item> Predicate, int QualityDecrease, int SellInDecrease)>();
    }
}