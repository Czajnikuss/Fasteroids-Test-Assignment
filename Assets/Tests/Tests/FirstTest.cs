using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    /*
    OK, I’ve read a lot about tests but still unable to put together Assembly Reference, 
    there is always problem witch namespaces that are not included and
    I'm stuck.... hopefully You will be able to lighten up this cloud in my mind..
    With only proves that I'm not extremly inteligent :)

    But If I would to write test for one of functionalitys that I've addet
    I would check for shipName an assert it is equal to "Destroyer"
    */
    public class FirstTest
    {
   
        // A Test behaves as an ordinary method
        [Test]
        public void FirstTestSimplePasses()
        {
            // Use the Assert class to test conditions

        bool isActive = false;

        Assert.AreEqual(false, isActive);


        }
        


        [Test]
    public void CatchingErrors()
    {

    GameObject gameObject = new GameObject("test");

    Assert.Throws<MissingComponentException>(
        () => gameObject.GetComponent<Rigidbody>().velocity = Vector3.one
    );

}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator FirstTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
