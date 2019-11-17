namespace GildedRose
{
    /// <summary>
    /// Provides useful extension methods for <see cref="int"/>.
    /// </summary>
    internal static class IntExtensions
    {
        public static bool IsWithin(this int value, int lowerBound, int upperBound)
        {
            return value >= lowerBound && value <= upperBound;
        }
    }
}