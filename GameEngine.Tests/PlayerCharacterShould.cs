using System;
using Xunit;
using Xunit.Abstractions; 




namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output; 

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output; 
            _output.WriteLine("Creating New Character");
            _sut = new PlayerCharacter(); 
        }
        public void Dispose()
        {
            _output.WriteLine($"Disposing Player Character {_sut.FullName}");

        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
            
        }

        [Fact]  
        [Trait("Category","Enemy")]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }
        
        [Fact]
        public void DoesNotHaveAMiddleBow()
        {
            Assert.DoesNotContain("Middle Bow", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]

        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrEmpty(weapon)));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            

            var ExpectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            Assert.Equal(_sut.Weapons, ExpectedWeapons);
        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

            Assert.Throws<ArgumentNullException>("Jon", () => sut.Create(null));
        }
        [Fact]
        public void IsThathBossName()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName); 


        }

        [Fact] 
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep()); 
        }

        



        
    }
}
