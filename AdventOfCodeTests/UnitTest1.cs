using AdventOfCode;

namespace AdventOfCodeTests;

public class UnitTest1
{
    [Fact]
    public void Day2()
    {
        Dictionary<int, string> battles = new Dictionary<int, string>();
        battles.Add(0, "AY");
        battles.Add(1, "BX");
        battles.Add(2, "CZ");
        Assert.Equal(15, AdventOfCode.Day2.CalcScore(battles));
    }
}