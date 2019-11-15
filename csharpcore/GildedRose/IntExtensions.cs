namespace GildedRose
{
    public static class IntExtensions
    {
        public static bool IsWithin(this int value, int lowerBound, int upperBound)
        {
            return value >= lowerBound && value <= upperBound;
        }
    }
}