using UnityEngine;

public class KnightLeveling : LevelingController {
    Knight knight;

    public KnightLeveling(Knight hero, int level) : base(level) {
        knight = hero;
    }

    protected override void LevelUp() {
        base.LevelUp();

        //int bonus = Mathf.FloorToInt(Mathf.Log(Level + 1));

        knight.MaxHPValue += KnightConfig.MaxHPBonus;
        knight.ATKValue += KnightConfig.ATKBonus;
        knight.MATKValue += KnightConfig.MATKBonus;
        knight.PDEFValue += KnightConfig.PDEFBonus;
        knight.MDEFValue += KnightConfig.MDEFBonus;
    }
}