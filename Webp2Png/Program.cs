using System;
using System.Drawing.Imaging;
using System.IO;

namespace Webp2Png
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    var path = Path.GetFullPath(args[0]);
                    var name = Path.GetFileNameWithoutExtension(args[0]);
                    var folder = Path.Combine(AppContext.BaseDirectory, "output");
                    var newpath = Path.Combine(folder, $"{name}.png");

                    Directory.CreateDirectory(folder);

                    var image = File.ReadAllBytes(path);
                    var decoder = new Imazen.WebP.SimpleDecoder();
                    var bitmap = decoder.DecodeFromBytes(image, image.Length);
                    bitmap.Save(newpath, ImageFormat.Png);

                    Console.WriteLine("Done.");
                }
                else
                {
                    Console.WriteLine("Arguments error!");
                    Console.WriteLine("Webp2Png [path]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
