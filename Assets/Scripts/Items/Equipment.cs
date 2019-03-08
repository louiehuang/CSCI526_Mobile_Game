using UnityEngine;

public enum EquipmentType {
    //weapon, shiled, armor...
}

[CreateAssetMenu]
public class Equipment : Item {
    public int ATK = 10;
    public float ATKPercent = 0.1f;
    public float CritPercent = -0.05f;

    public EquipmentType EquipmentType;

    public void Equip(BaseHero hero) {
        hero.ATK.AddModifier(new StatModifier(ATK, StatModType.Flat));
        hero.ATK.AddModifier(new StatModifier(ATKPercent, StatModType.PercentAdd, this));
        hero.Crit.AddModifier(new StatModifier(CritPercent, StatModType.PercentAdd, this));
    }

    public void Unequip(BaseHero hero) {
        hero.ATK.RemoveAllModifiersFromSource(this);
        hero.Crit.RemoveAllModifiersFromSource(this);
    }
}