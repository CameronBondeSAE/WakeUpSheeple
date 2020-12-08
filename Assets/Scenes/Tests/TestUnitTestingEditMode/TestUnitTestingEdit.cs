using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestUnitTestingEdit
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestUnitTestingEditSimplePasses()
        {
            // Use the Assert class to test conditions
			// Damage(1000000);
			// Assert.GreaterOrEqual(health.amount, 0);
		}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestUnitTestingEditWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
