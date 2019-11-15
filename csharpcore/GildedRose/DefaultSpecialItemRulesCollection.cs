using System.Collections;
using System.Collections.Generic;

namespace GildedRose
{
    public class DefaultSpecialItemRulesCollection : IEnumerable<SpecialItemRule>
    {
        private readonly IEnumerable<SpecialItemRule> _rules = new[]
        {
            new SpecialItemRule(
                "Sulfuras, Hand of Ragnaros",
                item => { }
            ),
            new SpecialItemRule(
                "Aged Brie",
                item =>
                {
                    if (item.SellIn >= 0)
                    {
                        item.Quality++;
                    }
                    else
                    {
                        item.Quality += 2;
                    }

                    item.SellIn--;
                }
            ),
            new SpecialItemRule(
                "Backstage passes to a TAFKAL80ETC concert",
                item =>
                {
                    if (item.SellIn <= 0)
                    {
                        item.Quality = 0;
                    }
                    else if (item.SellIn.IsWithin(1, 5))
                    {
                        item.Quality += 3;
                    }
                    else if (item.SellIn.IsWithin(6, 10))
                    {
                        item.Quality += 2;
                    }
                    else
                    {
                        item.Quality++;
                    }

                    item.SellIn--;
                }
            )
        };

        public IEnumerator<SpecialItemRule> GetEnumerator()
        {
            return _rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}