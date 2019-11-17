using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly IDictionary<string, Action<Item>> _specialItemRuleSets;

        public GildedRose(IList<Item> items, IDictionary<string, Action<Item>> specialItemRuleSets = null)
        {
            _items = items;
            _specialItemRuleSets = specialItemRuleSets ?? new DefaultSpecialItemRuleSetDictionary();
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (ItemHasSpecialRuleSet(item))
                {
                    ApplySpecialItemRuleSet(item);
                }
                else
                {
                    ApplyDefaultRuleSet(item);
                }

                EnsureQualityIsBetween(item, 0, 50);
            }
        }

        private bool ItemHasSpecialRuleSet(Item item) => _specialItemRuleSets.ContainsKey(item.Name);

        private void ApplySpecialItemRuleSet(Item item)
        {
            var ruleSet = _specialItemRuleSets[item.Name];

            ruleSet.Invoke(item);
        }

        private static void ApplyDefaultRuleSet(Item item)
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