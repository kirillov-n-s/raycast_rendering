using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace laba2
{
    class BitmapProcessor
    {
        readonly Bitmap _bitmap;

        BitmapData data;
        IntPtr ptr;
        int length;
        byte[] bytes;

        int Width => _bitmap.Width;
        int Height => _bitmap.Height;

        void Lock()
        {
            var rect = new Rectangle(0, 0, Width, Height);
            data = _bitmap.LockBits(rect, ImageLockMode.ReadWrite, _bitmap.PixelFormat);
            ptr = data.Scan0;
            length = Math.Abs(data.Stride) * Height;
            bytes = new byte[length];
            Marshal.Copy(ptr, bytes, 0, length);
        }

        void Unlock()
        {
            Marshal.Copy(bytes, 0, ptr, length);
            _bitmap.UnlockBits(data);
        }

        void Set(int x, int y, Color color)
        {
            int i = y * Math.Abs(data.Stride) + x * 4;
            bytes[i + 3] = color.A;
            bytes[i + 2] = color.R;
            bytes[i + 1] = color.G;
            bytes[i]     = color.B;
        }

        public BitmapProcessor(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public void Process(Func<int, int, Color> pixel)
        {
            Lock();
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Set(x, y, pixel(x, y));
            Unlock();
        }
    }
}
