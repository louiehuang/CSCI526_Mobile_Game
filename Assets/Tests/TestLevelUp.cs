using NUnit.Framework;
using UnityEngine;

namespace Tests {
    public class TestLevelUp {
        GameObject gameObject = new GameObject();

        [Test]
        public void AddEXPWithoutLevelUp() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();
            iceMage.LoadAttr();
            iceMage.LevelManager = new MageLeveling(iceMage, 1);

            iceMage.LevelManager.AddEXP(699);
            Assert.AreEqual(1, iceMage.LevelManager.Level);
            Assert.AreEqual(699f, iceMage.LevelManager.CurrentEXP);
        }

        [Test]
        public void EXPToLevelUp() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();
            iceMage.LevelManager = new MageLeveling(iceMage, 1);

            Assert.AreEqual(700f, iceMage.LevelManager.TotalEXPToLevelUp(1));
            Assert.AreEqual(750f, iceMage.LevelManager.TotalEXPToLevelUp(2));
            Assert.AreEqual(850f, iceMage.LevelManager.TotalEXPToLevelUp(3));
            Assert.AreEqual(1100f, iceMage.LevelManager.TotalEXPToLevelUp(4));
            Assert.AreEqual(1650f, iceMage.LevelManager.TotalEXPToLevelUp(5));
        }


        [Test]
        public void MageGoLevel2() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();
            iceMage.LoadAttr();
            iceMage.LevelManager = new MageLeveling(iceMage, 1);

            iceMage.LevelManager.AddEXP(700);
            //Debug.Log("Level: " + iceMage.LevelManager.Level);
            Assert.AreEqual(2, iceMage.LevelManager.Level);

            Assert.AreEqual(110f, iceMage.MaxHPValue);
            Assert.AreEqual(11f, iceMage.ATKValue);
            Assert.AreEqual(35f, iceMage.MATKValue);
        }

        [Test]
        public void PriestGoLevel2() {
            Priest priest = gameObject.AddComponent<Priest>();
            priest.LoadAttr();
            priest.LevelManager = new PriestLeveling(priest, 1);

            priest.LevelManager.AddEXP(700);
            //Debug.Log("Level: " + iceMage.LevelManager.Level);
            Assert.AreEqual(2, priest.LevelManager.Level);

            Assert.AreEqual(165f, priest.MaxHPValue);
            Assert.AreEqual(11.5f, priest.ATKValue);
            Assert.AreEqual(22f, priest.MATKValue);
        }

    }
}
