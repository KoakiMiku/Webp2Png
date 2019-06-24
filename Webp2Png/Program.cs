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
                    foreach (var arg in args)
                    {
                        var path = Path.GetFullPath(arg);
                        var name = Path.GetFileNameWithoutExtension(arg);
                        var folder = Path.Combine(AppContext.BaseDirectory, "output");
                        var newpath = Path.Combine(folder, $"{name}.png");

                        Directory.CreateDirectory(folder);

                        var image = File.ReadAllBytes(path);
                        var decoder = new Imazen.WebP.SimpleDecoder();
                        var bitmap = decoder.DecodeFromBytes(image, image.Length);
                        bitmap.Save(newpath, ImageFormat.Png);
                        bitmap.Dispose();

                        Console.WriteLine(name);
                    }

                    Console.WriteLine("Done.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Arguments error!");
                    Console.WriteLine("Webp2Png [path1] [path2] ...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
