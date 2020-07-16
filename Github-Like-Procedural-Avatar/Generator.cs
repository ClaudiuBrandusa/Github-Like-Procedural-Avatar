using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Github_Like_Procedural_Avatar
{
    // This class will generate and hold a reference to our avatar matrix
    public class Generator
    {
        AvatarMatrix matrix; // stored matrix
        Random random; // we will use this for random values generation
        Drawer drawer; // AvatarMatrix to png converter
        Regex hexadecimalValidator;

        // m - number of lines
        // n - number of columns
        public Generator(int m, int n)
        {
            matrix = new AvatarMatrix(m, n);
            random = new Random();
            drawer = new Drawer(Program.width, Program.height);

            hexadecimalValidator = new Regex("^([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
        }

        public void SetDimensions(int width, int height)
        {
            drawer.SetResolution(width, height);
        }

        public void SetColor(string hexColor) // this one will work for one generation only, then you will have to set the preferred color again
        {
            // let's see if it's an empty string
            if(string.IsNullOrEmpty(hexColor))
            { // then we have nothing to do here
                return;
            }else if(hexColor.Length < 3)
            { // then definitely it's not a hexadecimal color
                return;
            }
            // we will validate the given string to be sure if it's a real hexadecimal color
            // if the first character is # then we will slice the first pos to the last in order to ignore the first character
            if(hexColor[0] == '#')
            {
                hexColor = hexColor.Substring(1);
            }
            if(!hexadecimalValidator.IsMatch(hexColor))
            { // Then it's not a hex color
                return;
            }
            hexColor = '#' + hexColor;
            drawer.UseColor(hexColor);
        }

        // Usage: This method will generate the shape of the avatar
        void Generate(int chance)
        {
            // We can slice the matrix vertically in two halves (left and right parts)

            int half = matrix.GetLinesNumber() / 2; // number of a half of the columns

            // We will generate the left part
            for (int columnIndex = 0; columnIndex < half; columnIndex++)
            {
                SetColumn(columnIndex, chance);
            }
            // if we have an odd number of columns
            if ((matrix.GetColumnsNumber() % 2) != 0)
            {
                // then we will generate over the middle column 
                SetColumn(matrix.GetColumnsNumber() / 2, chance);
            }
            // Then we will mirror the left part on the right part
            // Starting from the first column of the right part
            for (int columnIndex = 0; columnIndex < half; columnIndex++)
            {
                MirrorColumn(columnIndex, half + 1);
            }
        }

        public void Generate()
        {
            matrix.Reset(); // Clearing the matrix
            Generate(2); // 2 gives a 50% chance of generation for every position
        }

        // Usage: This method will be used in order to save the current matrix to a png
        public void Save(string filename)
        {
            drawer.Write(matrix.GetArray());
            drawer.Save(filename);
        }

        public void Export(Stream stream)
        {
            drawer.Write(matrix.GetArray());
            drawer.Export(stream);
        }

        // Usage: This method set random values for the entire column
        // column - column index; should be greater than -1
        // chance - the greater is the bigger the chance to add a color to that position
        // Note: the chance should be greater than 1
        void SetColumn(int column, int chance)
        {
            // validating the chance
            if (chance < 2)
            {
                chance = 2;
            }
            for (int i = 0; i < matrix.GetColumnsNumber(); i++)
            {
                if (random.Next(chance) == 0)
                {
                    SetColumn(column, i, false);
                }
                else
                {
                    SetColumn(column, i, true);
                }
            }
        }

        // Usage: This method will set the state of a position in the Matrix: 0 - not used | 1 - used
        // Components:
        // column - column index
        // line - line index
        // status - the status of the position: true - used | false - not used
        void SetColumn(int column, int line, bool status)
        {
            matrix.Set(column, line, (status ? 1 : 0));
        }

        // Usage: will mirror the 
        // column - column index; should be greater than -1
        void MirrorColumn(int column, int half)
        {
            for (int i = 0; i < matrix.GetColumnsNumber(); i++)
            {
                if (matrix.Get(column, i) != 0)
                {
                    SetColumn(matrix.GetLinesNumber() - column - 1, i, true);
                    // We want to reverse the position in a mirror like way
                    // The formula: subtract the curent position from the last position
                    // above we also subtracted 1 from the total because matrix.GetLinesNumber() returns the count of lines not the last position
                }
            }
        }

        public override string ToString()
        {
            // We want to return informations about the stored matrix
            return matrix.ToString();
        }
    }
}
