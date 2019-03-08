using UnityEngine;
using System.Collections;

public class MageLeveling : LevelingController {
    Mage mage;

    public MageLeveling(Mage hero, int level) : base(level) {
        mage = hero;
    }

    protected override void LevelUp() {
        base.LevelUp();

        int adder = Mathf.FloorToInt(Mathf.Log(Level + 1));

        mage.ATKValue = adder * 2;
        //mage.MaxHPValue += adder * 5;
    }
}