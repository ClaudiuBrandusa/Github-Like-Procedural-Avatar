using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace Github_Like_Procedural_Avatar
{
    // This class will convert our AvatarMatrix into an image at the given width & height
    class Drawer
    {
        // those colors will be used if the colors list is empty
        Color[] colors = new Color[] { Color.Red, Color.Aqua, Color.Azure, Color.Chocolate, Color.Violet, Color.Yellow, Color.Green, Color.DarkGreen, Color.Orange };

        Color color; // preferred color

        int width;
        int height;

        Bitmap img;

        Random random;

        public Drawer(int width, int height)
        {
            random = new Random();
            color = default(Color);
            SetResolution(width, height);
        }

        public void SetResolution(int width, int height)
        {
            if (width < 10 || width > 10000 || height < 10 || height > 10000)
            {
                this.width = 100;
                this.height = 100;// default value
            }
            else
            {
                this.width = width;
                this.height = height;
            }
            
            img = new Bitmap(width, height);
        }

        public void Write(int[,] matrix)
        {
            // Setting the ratios
            int widthRatio = (int)width / matrix.GetLength(0);
            int heightRatio = (int)height / matrix.GetLength(1);
            // We will use those ratios in order to determine the scale of a position from the matrix to the bitmap

            // Choosing a color
            if(this.color == default(Color))
            { // then it means that we have not selected a preferred color
                // so we will choose a random color
                color = colors[random.Next(colors.Length)];
            }
            // Choosing a random color

            // Writing the matrix on the bitmap
            using (Graphics graphics = Graphics.FromImage(img)) // opening the bitmap
            {
                graphics.Clear(Color.Transparent);
                using (SolidBrush brush = new SolidBrush(color)) // initialising the brush
                {
                    for (int line = 0; line < matrix.GetLength(0); line++)
                    {
                        for (int column = 0; column < matrix.GetLength(1); column++)
                        {
                            if (matrix[line, column] != 0) // If it's not transparent
                            {
                                // Then we draw
                                graphics.FillRectangle(brush, new Rectangle(column * widthRatio, line * heightRatio, widthRatio, heightRatio));
                            }
                        }
                    }
                }
            }
            // in the end we will assing the color with the default value in order to mark the fact that we already used the preferred color
            color = default(Color);
        }

        public void UseColor(string hexColor)
        {
            color = ColorTranslator.FromHtml(hexColor);//Color.FromName(hexColor);
        }

        public void Save(string filename)
        {
            img.Save(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + filename + ".png");
        }

        public void Export(Stream stream) // exports the image in png format to a stream
        {
            img.Save(stream, ImageFormat.Png);
        }
    }
}
