using System;

namespace TicTacToe
{
    // Base of polymorphic class.
    // All GameStateX classes will inherit from GameState.
    // This will allow all GameStateX classes to be pushed
    // to and popped from the stack.
    // This will also allow the GameLoop method in the Game class
    // to call the individual Update(), HandleInput() and Draw()
    // methods in the various derived classes.
    public class GameState
    {
        public Game game;

        // Derived classes must implement following methods
        public virtual void Update() { }
        public virtual void HandleInput() { }
        public virtual void Draw() { }

        // Header that can be used for each GameState
        public void DrawHeader()
        {
            Console.WriteLine("TicTacToe");
            Console.WriteLine("----------");
        }
    }
}
