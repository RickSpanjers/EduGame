using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class BossBattle
    {
		private CombatController controller;
		private PersistenceManager manager;

		[OneTimeSetUp]
		public void setup()
		{
			controller = new CombatController();
		}

	
		[Test]
		public void BossBattleInitializeTest()
		{
			Assert.IsNotNull(controller.characterName);
		}

		[Test]
        public void BossBattleSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use

    }
}
