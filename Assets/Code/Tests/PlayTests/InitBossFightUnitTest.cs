using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InitBossFightUnitTest
    {

        InitBossFight init = new InitBossFight();

        [Test]
        public void test()
        {

        }

        [UnityTest]
        public IEnumerator unityTest()
        {
            init.dynamic = true;
            init.boss = new GameObject();
            init.playerObject = new GameObject();
            init.returnPoint = new GameObject();

            //string expected = "test";
            //string actual = "test";

            yield return new WaitForFixedUpdate();

            //Assert.AreNotEqual();
        }
    }
}
