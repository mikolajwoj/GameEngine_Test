using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();
        }

        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        } 

        [Fact]
        public void DoesNotHaveAMiddleBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Middle Bow", sut.Weapons);
        } 

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {

            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));

        }

        [Fact] 

        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrEmpty(weapon)));
        } 

        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var ExpectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            Assert.Equal(sut.Weapons, ExpectedWeapons); 
        }
    }
}
