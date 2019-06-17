using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Code;
using UnityEngine.SceneManagement;
using System;

namespace Tests
{
    public class NavigationUnitTest
    {

        [Test]
        public void OpenScene()
        {
            Scene scene = SceneManager.GetActiveScene();

            Scene expected = new Scene();
            Scene actual = SceneManager.GetActiveScene();

            Console.WriteLine(actual);

            Assert.AreEqual(expected, actual);
        }

    }
}
