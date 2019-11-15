using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly IEnumerable<SpecialItemRule> _specialItemRules;

        public GildedRose(IList<Item> items, IEnumerable<SpecialItemRule> specialItemRules = null)
        {
            _items = items;
            _specialItemRules = specialItemRules ?? new DefaultSpecialItemRulesCollection();
        }

        public void UpdateQuality()
        {
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

        private bool ItemHasSpecialRules(Item item) => _specialItemRules.Select(x => x.ItemName).Contains(item.Name);

        private void ApplySpecialItemRules(Item item)
        {
            var ruleSet = _specialItemRules.Single(x => x.ItemName == item.Name);

            ruleSet.ApplySpecialRules(item);
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

        private static void EnsureQualityIsBetween(Item item, int lowerBound, int upperBound)
        {
            item.Quality = Math.Clamp(item.Quality, lowerBound, upperBound);
        }
    }
}