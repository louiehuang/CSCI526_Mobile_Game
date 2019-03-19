using UnityEngine;

public class ArcherLeveling : LevelingController {
    Archer archer;

    public ArcherLeveling(Archer hero, int level) : base(level) {
        archer = hero;
    }

    protected override void LevelUp() {
        base.LevelUp();

        //int bonus = Mathf.FloorToInt(Mathf.Log(Level + 1));

        archer.MaxHPValue += ArcherConfig.MaxHPBonus;
        archer.ATKValue += ArcherConfig.ATKBonus;
        archer.MATKValue += ArcherConfig.MATKBonus;
        archer.PDEFValue += ArcherConfig.PDEFBonus;
        archer.MDEFValue += ArcherConfig.MDEFBonus;
    }
}