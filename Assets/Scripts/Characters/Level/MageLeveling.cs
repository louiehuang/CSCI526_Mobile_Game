using UnityEngine;

public class MageLeveling : LevelingController {
    Mage mage;

    public MageLeveling(Mage hero, int level) : base(level) {
        mage = hero;
    }

    protected override void LevelUp() {
        base.LevelUp();

        //int bonus = Mathf.FloorToInt(Mathf.Log(Level + 1));

        mage.MaxHPValue += IceMageConfig.MaxHPBonus;
        mage.ATKValue += IceMageConfig.ATKBonus;
        mage.MATKValue += IceMageConfig.MATKBonus;
        mage.PDEFValue += IceMageConfig.PDEFBonus;
        mage.MDEFValue += IceMageConfig.MDEFBonus;
    }
}