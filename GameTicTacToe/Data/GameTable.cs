namespace GameTicTacToe.Data
{
	public class GameTable
	{
		public List<GameSquare> GameSquares = new List<GameSquare>();


		public GameTable()
		{
			for (int i = 1; i < 10; i++)
			{
				GameSquares.Add(new GameSquare(i));
			}
		}

	}
}
