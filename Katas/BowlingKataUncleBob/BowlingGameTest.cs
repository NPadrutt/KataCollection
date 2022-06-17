using FluentAssertions;
using Xunit;

namespace Katas.BowlingKataUncleBob;

public sealed class BowlingGameTest
{
    private readonly Game g;

    public BowlingGameTest()
    {
        g = new Game();
    }

    [Fact]
    public void TestGutterGame()
    {
        RollMany(20, 0);

        g.Score().Should().Be(0);
    }

    [Fact]
    public void TestAllOnes()
    {
        RollMany(20, 1);

        g.Score().Should().Be(20);
    }

    private void RollMany(int n, int pins)
    {
        for (int i = 0; i < n; i++)
        {
            g.Roll(pins);
        }
    }
}

public class Game
{
    private int score;
    
    public void Roll(int pins)
    {
        score += pins;
    }

    public int Score()
    {
        return score;
    }
}