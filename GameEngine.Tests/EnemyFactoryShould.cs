using System;
using System.Collections.Generic;
using System.Text;
using Xunit; 


namespace GameEngine.Tests
{
    public class EnemyFactoryShould
    { 
        [Fact] 
        public void CreateNormalnEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Krwiopijca");

            Assert.IsType<NormalEnemy>(enemy); 


        }
        [Fact]
        public void CreateNormalnEnemyByDefaultver2()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Krwiopijca");

            Assert.IsNotType<DateTime>(enemy);
        }
        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy intrygator = sut.Create("Kingorator", true);

            Assert.IsType<NormalEnemy>(intrygator);   
           
        }
        [Fact] 
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Bombie");

            Assert.NotSame(enemy1, enemy2); 

        } 

        [Fact] 
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10)); 
        } 


        
        

    }
}
