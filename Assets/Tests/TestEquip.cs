using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TestEquip {
        GameObject gameObject = new GameObject();

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
    }
}