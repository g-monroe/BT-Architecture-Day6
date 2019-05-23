using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperheroBattle.Core.Entities;
using SuperheroBattle.DataAccessHandlers;
using System;
using System.Collections.Generic;

namespace SuperheroBattle.BusinessLogic.Engines.Tests
{
    [TestClass]
    public class BattleManagerTests
    {
        private BattleManager _battleManager;
        private ISuperheroHandler _superheroHandler;
        [TestInitialize]
        public void TestInit()
        {
           _superheroHandler = A.Fake<ISuperheroHandler>();
            IBattleEngine battleEngine = A.Fake<IBattleEngine>();
            _battleManager = new BattleManager(_superheroHandler, battleEngine);
        }
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ExampleUseCase_ThrowsNotImplementedException()
        {
            _battleManager.ExampleUseCase();
        }

        [TestMethod]
        public void Fight_Draw()
        {
            var battle = new Battle()
            {
                AttackerID = 10,
                DefenderID = 10
            };
            var superheroes = new List<Superhero> {
                new Superhero()
                {
                    SuperheroID = 10,
                    SuperheroAbilities = new List<SuperheroAbility>(){
                        new SuperheroAbility
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    },
                    AbilityModifier= 100,
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(battle)).Returns(superheroes);

            Battle result = _battleManager.Fight(battle);
           
            Assert.IsNull(result.WinnerID);
        }
        [TestMethod]
        public void Fight_AttackerWins()
        {
            var battle = new Battle()
            {
                AttackerID = 10,
                DefenderID = 20
            };
            var superheroes = new List<Superhero> {
                new Superhero()
                {
                    SuperheroID = 10,
                    SuperheroAbilities = new List<SuperheroAbility>(){
                        new SuperheroAbility
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    },
                    AbilityModifier= 100,
                },
                  new Superhero()
                {
                    SuperheroID = 20,
                    SuperheroAbilities = new List<SuperheroAbility>(){
                        new SuperheroAbility
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    },
                    AbilityModifier= 0,
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(battle)).Returns(superheroes);

            Battle result = _battleManager.Fight(battle);
            int? expected = 10;
            int? actual = result.WinnerID;
            Assert.AreEqual(expected, actual);
        }
    }
}
