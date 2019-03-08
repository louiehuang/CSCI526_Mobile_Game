using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TestEXP {
        GameObject gameObject = new GameObject();

        // A Test behaves as an ordinary method
        [Test]
        public void TestEXPSimplePasses() {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestEXPWithEnumeratorPasses() {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }


        [Test]
        public void EquipmentATK() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();
            iceMage.ATK = new CharacterAttribute();
            Assert.AreEqual(0f, iceMage.ATKValue);

            iceMage.ATK.AddModifier(new StatModifier(10f, StatModType.Flat));
            Assert.AreEqual(10f, iceMage.ATKValue);

            iceMage.ATK.AddModifier(new StatModifier(0.5f, StatModType.PercentAdd, this));
            Assert.AreEqual(15f, iceMage.ATKValue);

            iceMage.ATK.RemoveAllModifiersFromSource(this);
            Assert.AreEqual(10f, iceMage.ATKValue);
        }


        [Test]
        public void AddEXP() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();
            iceMage.LevelManager = new MageLeveling(iceMage, 1);

            iceMage.ATK = new CharacterAttribute();

            iceMage.LevelManager.AddEXP(700);
            //Debug.Log("EXP: " + iceMage.LevelManager.CurrentEXP);
            //Assert.AreEqual(700, iceMage.LevelManager.CurrentEXP);
        }


        [Test]
        public void GoLevel2() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();

            //TODO: MageLeveling will modify ATK, so iceMage needs to initilize ATK object first
            iceMage.ATK = new CharacterAttribute();

            iceMage.LevelManager = new MageLeveling(iceMage, 1);

            iceMage.LevelManager.AddEXP(800);
            Debug.Log("Level: " + iceMage.LevelManager.Level);

            Assert.AreEqual(2, iceMage.LevelManager.Level);
        }
    }
}
