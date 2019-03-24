using System;

[Serializable]
public static class ArcherConfig {
    //special attrs
    public static float SkillCooldownTime = 5f;

    //skill effects
    public static float ATKSpeedPercent = 1.0f;  //atk speed increase 100%

    //level up related bonus
    public static float MaxHPBonus = 15f;
    public static float ATKBonus = 3f;
    public static float MATKBonus = 1f;
    public static float PDEFBonus = 2f;
    public static float MDEFBonus = 2f;

    //common base value
    public static int Level = 1;
    public static float Range = 35f;

    public static string CharacterName = "Loman";
    public static string CharacterDescription = "A descendant of Loman’s family, who has been gatekeeping the Orvelia for generations.";

    public static float MaxHPValue = 120f;

    public static float ATKValue = 28f;
    public static float MATKValue = 12f;

    public static float PDEFValue = 10f;
    public static float MDEFValue = 10f;

    public static float CritValue = 0.1f;
    public static float CritDMGValue = 0.2f;

    public static float PernetrationValue = 0f;
    public static float ACCValue = 1f;
    public static float DodgeValue = 0f;
    public static float BlockValue = 0f;
    public static float CritResistanceValue = 0.1f;

    public static float ATKSpeedValue = 3f;  // 3 attack per second

}