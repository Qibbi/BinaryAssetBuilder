internal static class Misc
{
    public static bool IsPowerOfTwo(int value)
    {
        if (value != 0)
        {
            return (value & (~value + 1)) == value;
        }
        return false;
    }

    public static unsafe bool HasConstantAlphaChannel(NVImage<RGBA_t>* image)
    {
        uint size = (uint)(image->Width * image->Height);
        RGBA_t* data = image->Pixels;
        for (uint idx = 0; idx < size; ++idx)
        {
            if (image->Pixels[idx].A != data->A)
            {
                return false;
            }
        }
        return true;
    }

    public static unsafe bool Has1BitAlphaChannel(NVImage<RGBA_t>* image)
    {
        uint size = (uint)(image->Width * image->Height);
        for (uint idx = 0; idx < size; ++idx)
        {
            RGBA_t pixel = image->Pixels[idx];
            if (pixel.A != 0 && pixel.A != byte.MaxValue)
            {
                return false;
            }
        }
        return true;
    }
}
