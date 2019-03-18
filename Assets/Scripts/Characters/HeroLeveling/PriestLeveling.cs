using UnityEngine;

public class PriestLeveling : LevelingController {
    Priest priest;

    public PriestLeveling(Priest hero, int level) : base(level) {
        priest = hero;
    }

    protected override void LevelUp() {
        base.LevelUp();

        //int bonus = Mathf.FloorToInt(Mathf.Log(Level + 1));

        priest.MaxHPValue += PriestConfig.MaxHPBonus;
        priest.ATKValue += PriestConfig.ATKBonus;
        priest.MATKValue += PriestConfig.MATKBonus;
        priest.PDEFValue += PriestConfig.PDEFBonus;
        priest.MDEFValue += PriestConfig.MDEFBonus;
    }
}