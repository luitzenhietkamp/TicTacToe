namespace TicTacToe
{
    public class CharacterPicture
    {
        // Horizontally concatenates character pictures (string arrays)
        // Both string arrays must be same length
        // will not deal with incorrect usage
        // TODO add support for character pictures of different heights
        public static string[] HCat(string[] left, string[] right)
        {
            for (int i = 0; i < left.Length; i++)
            {
                left[i] += right[i];
            }

            return left;
        }

        // Adds a border on the right side of a string array
        public static string[] RBorder(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] += "|";
            }
            return input;
        }
    }
}
