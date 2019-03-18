using UnityEngine;

public abstract class LevelingController {

    public float CurrentEXP { get; set; }

    public int Level { get; set; }

    protected LevelingController(int level) {
        Level = level;
        CurrentEXP = 0;
    }

    //Add exp recursively if level up
    public void AddEXP(float amount) {
        int maxEXP = TotalEXPToLevelUp(Level);

        if (CurrentEXP + amount >= maxEXP) {
            float left = amount - maxEXP;
            LevelUp();

            if (left > 0)
                AddEXP(left);
        } else {
            CurrentEXP += amount;
        }
    }

    protected virtual void LevelUp() {
        Level++;
        CurrentEXP = 0;
    }

    /// <summary>
    /// EXP formula ref https://wenku.baidu.com/view/d455517cf46527d3240ce0c6.html
    /// </summary>
    public int TotalEXPToLevelUp(int level) {
        float first = (Mathf.Pow((level - 1), 3) + 60) / 5;
        float second = (level - 1) * 2 + 60;
        return Mathf.FloorToInt(first * second / 50) * 50;
    }
}