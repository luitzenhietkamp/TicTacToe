using System;

namespace TicTacToe
{
    // GameStateX class that's responsible for dealing with input errors
    public class GameStateInputError : GameState
    {
        Game game;
        string input;
        readonly string Input;

        // For more specific feedback, callers must provide the incorrect input
        public GameStateInputError(ref Game game, string input)
        {
            this.game = game;
            this.Input = input;
        }

        public override void Draw()
        {
            Console.WriteLine($"{Input} is not a valid input, please try again");
            Console.WriteLine("Press enter to continue.");
        }

        public override void Update()
        {

        }

        // Close the error message after the user provides any input
        public override void HandleInput()
        {
            Console.ReadLine();
            game.PopState();
        }
    }
}
