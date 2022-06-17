using FluentAssertions;
using Xunit;

namespace Katas.BowlingKataUncleBob;

public sealed class BowlingGameTest
{
    [Fact]
    public void TestGutterGame()
    {
        var g = new Game();
        for (int i = 0; i < 20; i++)
        {
            g.Roll(0);
        }

        g.Score().Should().Be(0);
    }
    
    
}

public class Game
{
    public void Roll(int pins)
    {
        
    }

    public int Score()
    {
        return 0;
    }
}