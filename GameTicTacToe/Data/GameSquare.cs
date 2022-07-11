namespace GameTicTacToe.Data
{
	public class GameSquare
	{
		public int Id { get; set; }
		public string Input { get; set; } = " ";
		public bool HasValue { get { return Input != " "; } }

		public GameSquare(int loc)
		{
			Id = loc;
		}
	}
}
