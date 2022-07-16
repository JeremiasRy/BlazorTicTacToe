using System.Linq;

namespace GameTicTacToe.Data
{
    public static class Computer
    {
        public static Random random = new Random();

        public static int BestPosition(List<GameSquare> gameState, List<List<int>> winningLines, string computerInput)
		{
            var opponentInput = (computerInput == "X") ? "O" : "X";
            var openGameState = gameState.Where(x => !x.HasValue).ToList();

            List<List<int>> dangerLines = CheckLines(opponentInput);
            List<List<int>> winLines = CheckLines(computerInput);

            int bestPositionId = 0;

            bool gameEndingSituation = dangerLines.First().Last() == 2  || winLines.First().Last() == 2;    


            if (gameEndingSituation)
            {

                var LinesToEnd = winLines.First().Last() == 2 ? winLines : dangerLines;
                TakeAction(LinesToEnd.First(), false);

            }
            else if (openGameState.Count() == 9)
            {
                TakeAction(new List<int>(), true);
            } 
            else
            {
                TakeAction(winLines.First(), false);
            }

   
            List<List<int>> CheckLines(string playerInput)
            {
                int count = 0;
                List<List<int>> Lines = new List<List<int>>();
                
                foreach (var copyThisLine in winningLines)
                {
                    Lines.Add(new List<int>(copyThisLine));
                }

                foreach (var line in Lines)
                {
                    foreach (var id in line)
                    {
                        if (gameState.Where(x => x.Id == id).Where(x => x.Input == playerInput).Any())
                        {
                            count++;
                        }
                    }
                    
                    if (LineCheckForImpossibleMove(line))
                    {
                        line.Add(-1);
                    } else
                    {
                        line.Add(count);
                    }
                    count = 0;
                }
                return Lines.OrderByDescending(x => x.Last()).ToList();
            }

            bool LineCheckForImpossibleMove(List<int> line)
            {
                var copy = new List<int>(line);
                if(copy.Count == 4)
                {
                    copy.RemoveAt(copy.Count - 1);
                }
                var LineInGame = gameState.Where(x => copy.Contains(x.Id));
                return LineInGame.Where(x => x.HasValue).Count() == 3;
            }

            void TakeAction(List<int> lineToTakeActionFrom, bool startingTurn)
            {
                if (startingTurn)
                {
                    bestPositionId = random.Next(1, 9);
                }
                else
                {
                    bestPositionId = openGameState.FirstOrDefault(x => lineToTakeActionFrom.Any(line => line == x.Id)).Id;
                    
                }
            }
            return bestPositionId;
		}
    }
}
