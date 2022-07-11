namespace GameTicTacToe.Data
{
	public class Input
	{
		public InputOptions Inputs { get; set; }

		public enum InputOptions
		{
			X = 0,
			O = 1,
		}
	}
}
