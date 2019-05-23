using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using SuperheroBattle.DataAccessHandlers.Handlers;
using SuperheroBattle.Core.Entities;
using System.Threading.Tasks;

namespace SuperheroBattle.BusinessLogic.Managers.Tests
{
    [TestClass]
    public class BattleManagerTests
    {
        private BattleManager _battleManager;
        private ISuperheroHandler _superheroHandler;

        [TestInitialize]
        public void TestInitiallize()
        {
            _superheroHandler = A.Fake<ISuperheroHandler>();

            _battleManager = new BattleManager(_superheroHandler);
        }

        [TestMethod]
        public async Task Fight_SameSuperheroLeadsToADraw()
        {
            Battle battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 20
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);
            Battle result = await _battleManager.Fight(battle);
            Assert.IsNull(result.WinnerID);
        }

        [TestMethod]
        public async Task Fight_AttackerWins()
        {
            Battle battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 20
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 10
                            }
                        }
                    }
                },
                new Superhero()
                {
                    SuperheroID = 20,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);
            Battle result = await _battleManager.Fight(battle);
            int? expected = 10;
            int? actual = result.WinnerID;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Fight_DefenderWins()
        {
            Battle battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 20
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    }
                },
                new Superhero()
                {
                    SuperheroID = 20,
                    AbilityModifier = 100,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 10
                            }
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);
            Battle result = await _battleManager.Fight(battle);
            int? expected = 20;
            int? actual = result.WinnerID;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Fight_AttackerWinsBecauseOfAbilties()
        {
            Battle battle = new Battle
            {
                AttackerID = 10,
                DefenderID = 20
            };

            var superheroes = new List<Superhero>
            {
                new Superhero()
                {
                    SuperheroID = 10,
                    AbilityModifier = 0,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 10
                            }
                        },
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 10
                            }
                        }
                    }
                },
                new Superhero()
                {
                    SuperheroID = 20,
                    AbilityModifier = 0,
                    SuperheroAbilities = new List<SuperheroAbility>()
                    {
                        new SuperheroAbility()
                        {
                            Ability = new Ability()
                            {
                                StrengthLevel = 0
                            }
                        }
                    }
                }
            };

            A.CallTo(() => _superheroHandler.GetSuperheroes(A<List<int>>._)).Returns(superheroes);
            Battle result = await _battleManager.Fight(battle);
            int? expected = 10;
            int? actual = battle.WinnerID;
            Assert.AreEqual(expected, actual);
        }
    }
}
