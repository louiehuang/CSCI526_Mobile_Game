using System;

[Serializable]
public static class TripodonteBullet
{
    //common base value
    public static float Range = 20f;

    public static string CharacterName = "Enermy";

    public static float MaxHPValue = 250f;

    public static float ATKValue = 25;
    public static float MATKValue = 0f;

    public static float PDEFValue = 5f;
    public static float MDEFValue = 2f;

    public static float CritValue = 0.15f;
    public static float CritDMGValue = 0.25f;

    public static float PernetrationValue = 0f;
    public static float ACCValue = 1f;
    public static float DodgeValue = 0.02f;
    public static float BlockValue = 0.02f;
    public static float CritResistanceValue = 0.02f;

    public static float ATKSpeedValue = 0.5f;  // 0.8 attack per second
}
