namespace Native.Direct3D9
{
    public partial struct DisplayMode
    {
        public float AspectRatio => (float)Width / Height;

        public override string ToString()
        {
            return $"Width: {Width}, Height: {Height}, RefreshRate: {RefreshRate}, Format: {Format}";
        }
    }
}
