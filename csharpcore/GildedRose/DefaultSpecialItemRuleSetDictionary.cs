using System;
using System.Collections;
using System.Collections.Generic;

namespace GildedRose
{
    public class DefaultSpecialItemRuleSetDictionary : IDictionary<string, Action<Item>>
    {
        private readonly IDictionary<string, Action<Item>> _dictionary = new Dictionary<string, Action<Item>>
        {
            {
                "Sulfuras, Hand of Ragnaros",
                item => { }
            },
            {
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
            },
            {
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
            }
        };

        #region RequiredDictionaryMembers

        public IEnumerator<KeyValuePair<string, Action<Item>>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<string, Action<Item>> item)
        {
            _dictionary.Add(item);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, Action<Item>> item)
        {
            return _dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, Action<Item>>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, Action<Item>> item)
        {
            return _dictionary.Remove(item);
        }

        public int Count => _dictionary.Count;
        public bool IsReadOnly => _dictionary.IsReadOnly;

        public void Add(string key, Action<Item> value)
        {
            _dictionary.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _dictionary.Remove(key);
        }

        public bool TryGetValue(string key, out Action<Item> value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public Action<Item> this[string key]
        {
            get => _dictionary[key];
            set => _dictionary[key] = value;
        }

        public ICollection<string> Keys => _dictionary.Keys;
        public ICollection<Action<Item>> Values => _dictionary.Values;

        #endregion
    }
}