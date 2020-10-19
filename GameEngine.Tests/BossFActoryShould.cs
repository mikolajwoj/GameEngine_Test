using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions; 




namespace GameEngine.Tests
{
    public class BossEnemyShould 
    {
        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output; 

        }
        [Fact]
        //[Fact(Skip = "Don't need to run this")]
        [Trait("Category","Boss")]
        public void BossShouldHitCriticaly()
        {
            _output.WriteLine("Creating Boss Enemy");
            BossEnemy sut = new BossEnemy();
            var SpecialAttackRound = sut.TotalSpecialAttackPower;
            Assert.Equal(166.7, Math.Round(SpecialAttackRound,1));

        }




    }
}
