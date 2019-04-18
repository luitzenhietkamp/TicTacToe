namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.PushState(new GameStateMenu(ref game));
            game.GameLoop();
        }
    }
}