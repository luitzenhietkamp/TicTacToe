namespace TicTacToe
{
    public static class Shapes
    {
        public static string[,] tileSet = new string[11, 6]
        {
            { "             ",
              "     /|      ",
              "      |      ",
              "      |      ",
              "     _|_     ",
              "             "},
            { "     __      ",
              "    /  \\     ",
              "       /     ",
              "      /      ",
              "     /___    ",
              "             "},
            { "     __      ",
              "    /  \\     ",
              "       /     ",
              "       \\     ",
              "    \\__/     ",
              "             "},
            { "      _      ",
              "     / |     ",
              "    /  |     ",
              "   /___|_    ",
              "       |     ",
              "             "},
            { "     ___     ",
              "    |        ",
              "    |__      ",
              "       \\     ",
              "    \\__/     ",
              "             "},
            { "     ___     ",
              "    /        ",
              "    |__      ",
              "    |  \\     ",
              "    \\__/     ",
              "             "},
            { "     ____    ",
              "        /    ",
              "       /     ",
              "      /      ",
              "     /       ",
              "             "},
            { "     __      ",
              "    /  \\     ",
              "    \\__/     ",
              "    /  \\     ",
              "    \\__/     ",
              "             "},
            { "     __      ",
              "    /  \\     ",
              "    \\__/     ",
              "       \\     ",
              "     __/     ",
              "             "},
            { "    ____     ",
              "   /    \\    ",
              "  |      |   ",
              "  |      |   ",
              "   \\____/    ",
              "             "},
            { "             ",
              "    \\  /     ",
              "     \\/      ",
              "     /\\      ",
              "    /  \\     ",
              "             "}
        };

        // Method that allows the user to fetch the shape
        // by index.
        public static string[] ShapeByIndex(int n)
        {
            string[] ret = new string[6];

            for (int i = 0; i < 6; i++)
            {
                ret[i] += tileSet[n, i];
            }

            return ret;
        }
    }
}
