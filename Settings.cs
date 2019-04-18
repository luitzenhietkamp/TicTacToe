namespace TicTacToe
{
    // Simple class that stores various settings that can be changed
    // from the settings screen
    public class Settings
    {
        public int difficulty = 1;
        public char playerShape = 'X';
        public int playerTurn = 1;

        public Settings() { }

        public string GetDifficulty()
        {
            if (difficulty == 0)
                return "Easy";
            if (difficulty == 1)
                return "Medium";
            else
                return "Hard";
        }

        // Changes the player shape
        public void ChangeShape()
        {
            if (playerShape == 'X')
                playerShape = 'O';
            else
                playerShape = 'X';
        }

        // Returns the name of the (player) shape
        public string ShapeAsString()
        {
            if (playerShape == 'X')
                return "cross";
            else
                return "nought";
        }

        // Changes whether the player or the computer goes first
        public void ChangeOrder()
        {
            if (playerTurn == 1)
                playerTurn = 2;
            else
                playerTurn = 1;
        }

        // Returns whether the player goes first or second as a string
        public string TurnAsString()
        {
            if (playerTurn == 1)
                return "first";
            else
                return "second";
        }
    }
}
