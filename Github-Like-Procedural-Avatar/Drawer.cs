using System;
using System.Drawing;
using System.Reflection;

namespace Github_Like_Procedural_Avatar
{
    // This class will convert our AvatarMatrix into an image at the given width & height
    public class Drawer
    {
        Color[] colors = new Color[] { Color.Red, Color.Aqua, Color.Azure, Color.Chocolate, Color.Violet, Color.Yellow, Color.Green, Color.DarkGreen, Color.Orange };

        int width;
        int height;

        Bitmap img;

        Random random;

        public Drawer(int width, int height)
        {
            random = new Random();
            this.width = width;
            this.height = height;
            SetResolution(width, height);
        }

        public void SetResolution(int width, int height)
        {
            img = new Bitmap(width, height);
        }

        public void Write(int[,] matrix)
        {
            // Setting the ratios
            int widthRatio = (int)width / matrix.GetLength(0);
            int heightRatio = (int)height / matrix.GetLength(1);
            // We will use those ratios in order to determine the scale of a position from the matrix to the bitmap

            // Choosing a random color
            Color color = colors[random.Next(colors.Length)];

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
        }

        public void Save(string filename)
        {
            img.Save(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + filename + ".png");
        }
    }
}
