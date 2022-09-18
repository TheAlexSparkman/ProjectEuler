namespace Problems.PrimeSpirals
{
    public struct SpiralCorners
    {
        public SpiralCorners(long i)
        {
            BottomRight = (2 * i - 1) * (2 * i - 1);
            BottomLeft = BottomRight - 2 * (i - 1);
            TopLeft = BottomRight - 4 * (i - 1);
            TopRight = BottomRight - 6 * (i - 1);
        }

        public long BottomRight { get; set; }
        public long BottomLeft { get; set; }
        public long TopLeft { get; set; }
        public long TopRight { get; set; }
    }
}
