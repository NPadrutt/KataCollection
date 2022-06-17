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
    
    [Fact]
    public void TestOneSpare()
    {
        RollSpare();
        g.Roll(3);
    
        g.Score().Should().Be(16);
    }

    private void RollSpare()
    {
        g.Roll(5);
        g.Roll(5);
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
    private readonly int[] rolls = new int[21];
    private int currentRoll;

    public void Roll(int pins)
    {
        rolls[currentRoll++] += pins;
    }

    public int Score()
    {
        var score = 0;
        var frameIndex = 0;
        for (int frame = 0; frame < 10; frame++)
        {
            if (IsSpare(frameIndex))
            {
                score += 10 + rolls[frameIndex + 2];
                frameIndex += 2;
            }
            else
            {
                score += rolls[frameIndex] + rolls[frameIndex + 1];
                frameIndex += 2;
            }
        }
        
        return score;
    }

    private bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }
}