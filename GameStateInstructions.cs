using System;

namespace TicTacToe
{
    // GameStateX class responsible for the implementation of
    // the instructions screen
    public class GameStateInstructions : GameState
    {
        public GameStateInstructions(ref Game game)
        {
            this.game = game;
        }

        // The contents for the Instructions screen
        public override void Draw()
        {
            Console.WriteLine("Welcome to TicTacToe. In this game of noughts");
            Console.WriteLine("and crosses (American English: Tic-tac-toe) you");
            Console.WriteLine("play against the computer.");
            Console.WriteLine();
            Console.WriteLine("In settings (s) you can change the difficulty,");
            Console.WriteLine("choose your shape, and decide who goes first.");
            Console.WriteLine();
            Console.WriteLine("Each turn you get to place your shape and the");
            Console.WriteLine("first player to claim an entire column, row, or");
            Console.WriteLine("diagonal wins the game. Good luck!");
            Console.WriteLine();
            Console.WriteLine("To play the game press \"p\" in the menu.");
            Console.WriteLine();
            Console.WriteLine("Press enter to continue.");
        }

        public override void Update()
        {

        }

        // Close the Instructions screen after any input
        public override void HandleInput()
        {
            Console.ReadLine();
            game.PopState();
        }
    }
}
