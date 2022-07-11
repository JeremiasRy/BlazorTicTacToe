namespace GameTicTacToe.Data
{
	public class GameState
	{
		public string Player1Name { get; set; } = "";
		public string P2 { get; set; } = "";
		public bool AgainstComputer { get; set; } = true;
		public InputOptions Inputs { get; set; }

		public enum InputOptions
		{
			X = 0,
			O = 1,
		}
	}
}
