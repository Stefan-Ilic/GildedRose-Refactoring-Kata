using System;

namespace GildedRose
{
    public class SpecialItemRule
    {
        public SpecialItemRule(string itemName, Action<Item> applySpecialRules)
        {
            ItemName = itemName;
            ApplySpecialRules = applySpecialRules;
        }

        public string ItemName { get; }
        public Action<Item> ApplySpecialRules { get; }
    }
}