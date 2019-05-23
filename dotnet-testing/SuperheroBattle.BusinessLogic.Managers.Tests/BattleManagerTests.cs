using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SuperheroBattle.BusinessLogic.Managers.Tests
{
    [TestClass]
    public class BattleManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void ExampleUseCase_ThrowsNotImplementedException()
        {
            var battleManager = new BattleManager();
            battleManager.ExampleUseCase();
        }
    }
}
