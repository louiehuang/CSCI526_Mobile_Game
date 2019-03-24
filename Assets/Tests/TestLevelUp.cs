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
        public void IceMageGoLevel2() {
            IceMage iceMage = gameObject.AddComponent<IceMage>();
            iceMage.LoadAttr();
            iceMage.LevelManager = new MageLeveling(iceMage, 1);

            iceMage.LevelManager.AddEXP(700);
            Assert.AreEqual(2, iceMage.LevelManager.Level);

            Assert.AreEqual(110f, iceMage.MaxHPValue);
            Assert.AreEqual(11f, iceMage.ATKValue);
            Assert.AreEqual(35f, iceMage.MATKValue);
        }

        [Test]
        public void FireMageGoLevel2() {
            FireMage fireMage = gameObject.AddComponent<FireMage>();
            fireMage.LoadAttr();
            fireMage.LevelManager = new MageLeveling(fireMage, 1);

            fireMage.LevelManager.AddEXP(700);
            Assert.AreEqual(2, fireMage.LevelManager.Level);

            Assert.AreEqual(110f, fireMage.MaxHPValue);
            Assert.AreEqual(3f, fireMage.ATKValue);
            Assert.AreEqual(28f, fireMage.MATKValue);
        }

        [Test]
        public void PriestGoLevel2() {
            Priest priest = gameObject.AddComponent<Priest>();
            priest.LoadAttr();
            priest.LevelManager = new PriestLeveling(priest, 1);

            priest.LevelManager.AddEXP(700);
            Assert.AreEqual(2, priest.LevelManager.Level);

            Assert.AreEqual(165f, priest.MaxHPValue);
            Assert.AreEqual(11.5f, priest.ATKValue);
            Assert.AreEqual(22f, priest.MATKValue);
        }

        [Test]
        public void KnightGoLevel2() {
            Knight knight = gameObject.AddComponent<Knight>();
            knight.LoadAttr();
            knight.LevelManager = new KnightLeveling(knight, 1);

            knight.LevelManager.AddEXP(700);
            Assert.AreEqual(2, knight.LevelManager.Level);

            Assert.AreEqual(230f, knight.MaxHPValue);
            Assert.AreEqual(12f, knight.ATKValue);
            Assert.AreEqual(11f, knight.MATKValue);
        }


        [Test]
        public void ArcherGoLevel2() {
            Archer archer = gameObject.AddComponent<Archer>();
            archer.LoadAttr();
            archer.LevelManager = new ArcherLeveling(archer, 1);

            archer.LevelManager.AddEXP(700);
            Assert.AreEqual(2, archer.LevelManager.Level);

            Assert.AreEqual(135f, archer.MaxHPValue);
            Assert.AreEqual(31f, archer.ATKValue);
            Assert.AreEqual(13f, archer.MATKValue);
        }
    }
}
