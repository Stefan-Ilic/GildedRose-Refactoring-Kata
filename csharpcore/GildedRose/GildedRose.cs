using System;
using System.Collections.Generic;

namespace GildedRose
{
    /// <summary>
    /// Services used to update a collection of <see cref="Item"/> every night.
    /// </summary>
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly IDictionary<string, Action<Item>> _specialItemRuleSets;

        public GildedRose(IList<Item> items, IDictionary<string, Action<Item>> specialItemRuleSets = null)
        {
            _items = items;
            _specialItemRuleSets = specialItemRuleSets ?? new DefaultSpecialItemRuleSetDictionary();
        }

        /// <summary>
        /// Updates <see cref="_items"/> according to the default ruleset
        /// and the special rule sets supplied through <see cref="_specialItemRuleSets"/>.
        /// </summary>
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