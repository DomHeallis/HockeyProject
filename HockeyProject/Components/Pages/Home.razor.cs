namespace HockeyProject.Components.Pages
{
    public partial class Home
    {
        private int? expandedGameId = null; // or null if you want all collapsed at start

        private readonly List<GameRow> games =
        [
            new GameRow(
    Id: 1,
    Result: GameResult.Win,
    Date: new DateOnly(2025, 1, 13),
    YourScore: 3,
    OppScore: 1,
    Goals: new()
    {
        new GoalLine(1, "You", "scored"),
        new GoalLine(2, "You", "scored"),
        new GoalLine(3, "Friend", "scored"),
        new GoalLine(4, "You", "scored"),
    }),


        new GameRow(2, GameResult.Loss, new DateOnly(2025, 1, 11), 1, 4),
        new GameRow(3, GameResult.Win,  new DateOnly(2025, 1,  9), 4, 2),
        new GameRow(4, GameResult.Loss, new DateOnly(2025, 1,  7), 0, 3),
        new GameRow(5, GameResult.Win,  new DateOnly(2025, 1,  4), 4, 2),
    ];

        private void ToggleGame(int gameId)
            => expandedGameId = expandedGameId == gameId ? null : gameId;

        private static string PillClass(GameResult r) => r == GameResult.Win ? "win" : "loss";
        private static string PillText(GameResult r) => r == GameResult.Win ? "WIN" : "LOSS";

        private sealed record GameRow(
            int Id,
            GameResult Result,
            DateOnly Date,
            int YourScore,
            int OppScore,
            List<GoalLine>? Goals = null);

        private sealed record GoalLine(int Number, string Who, string Action);

        private enum GameResult { Win, Loss }
    }
}