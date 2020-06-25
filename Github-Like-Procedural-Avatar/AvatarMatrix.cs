namespace Github_Like_Procedural_Avatar
{
    // This class holds a reference to the avatar's integer matrix
    class AvatarMatrix
    {
        // The following constants will be used for the matrix size validation
        const int MaxLines = 10;
        const int MaxColumns = 10;

        int[,] matrix; // The integer matrix

        // m - number of lines
        // n - number of columns
        public AvatarMatrix(int m, int n)
        {
            // validating the inputs
            // m and n should be greater than 0
            if (m < 1)
            {
                m = 1;
            }
            if (n < 1)
            {
                n = 1;
            }
            // m and n should be lesser or equal to the max values
            if (m > MaxLines)
            {
                m = MaxLines;
            }
            if (n > MaxColumns)
            {
                n = MaxColumns;
            }
            // Initialising the Avatar Matrix
            InitMatrix(m, n);
        }

        void InitMatrix(int m, int n)
        {
            matrix = new int[m, n];
        }

        // This method will reset the matrix
        public void Reset()
        {
            if(matrix != null)
            {
                InitMatrix(matrix.GetLength(0), matrix.GetLength(1));
                return;
            }
            InitMatrix(MaxLines, MaxColumns);
        }

        // x - column index
        // y - line index
        // val - color id
        public void Set(int x, int y, int val)
        {
            // validating the input values
            // and assigning the default values to variables
            //if()

            matrix[y, x] = val;
        }

        // The main method of getting the color at a given position
        public int Get(int x, int y)
        {
            return matrix[y, x];
        }

        // Returns the number of columns from matrix
        public int GetColumnsNumber()
        {
            return matrix.GetLength(1);
        }

        // Returns the number of lines from matrix
        public int GetLinesNumber()
        {
            return matrix.GetLength(0);
        }

        // Returns the integer matrix
        public int[,] GetArray()
        {
            return matrix;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    s += (matrix[i, j] != 0 ? matrix[i, j].ToString() : ".") + " ";
                }
                s += "\n";
            }
            return s;
        }
    }
}
