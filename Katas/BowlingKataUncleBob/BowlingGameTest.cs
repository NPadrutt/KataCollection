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

    [Fact]
    public void testOneStrike()
    {
        RollStrike();
        g.Roll(3);
        g.Roll(4);
        RollMany(16, 0);

        g.Score().Should().Be(24);
    }

    private void RollStrike()
    {
        g.Roll(10);
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
            if (IsStrike(frameIndex))
            {
                score += 10 + StrikeBonus(frameIndex);
                frameIndex++;
            }
            else if (IsSpare(frameIndex))
            {
                score += 10 + SpareBonus(frameIndex);
                frameIndex += 2;
            }
            else
            {
                score += SumOfBallsInFrame(frameIndex);
                frameIndex += 2;
            }
        }
        
        return score;
    }


    private bool IsStrike(int frameIndex)
    {
        return rolls[frameIndex] == 10;
    }

    private int StrikeBonus(int frameIndex)
    {
        return rolls[frameIndex + 1] + rolls[frameIndex + 2];
    }
    
    private bool IsSpare(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
    }

    private int SpareBonus(int frameIndex)
    {
        return rolls[frameIndex + 2];
    }

    private int SumOfBallsInFrame(int frameIndex)
    {
        return rolls[frameIndex] + rolls[frameIndex + 1];
    }
}