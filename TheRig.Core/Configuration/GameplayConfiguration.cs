namespace TheRig.Core.Configuration
{
    public class GameplayConfiguration
    {
        public Difficulty Difficulty { get; set; }
    }

    public enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 3
    }
}
