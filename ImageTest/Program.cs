using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace ResizeImageCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //original dimension of image 223 x 240
            Bitmap img = new Bitmap(@"C:\Users\M Hassan Aamir\Downloads\Sample-jpg-image-30mb.jpg");
            //we are resizing to 110 x 120
            var resizedImg = ResizeImage(img, 50, 50);

            
            var newImg = Image.FromStream(resizedImg);
            //save file
            newImg.Save(@"C:\Users\M Hassan Aamir\Downloads\resizedTestFinal.jpg");
        }
        //image resize method
        public static MemoryStream ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new(image, new Size(256, 256));
            using var stream = new MemoryStream();
            resizedImage.Save(stream, ImageFormat.Jpeg);
            byte[] bytes = stream.ToArray();
            var ms = new MemoryStream(bytes);
            return ms;
        }
    }
}