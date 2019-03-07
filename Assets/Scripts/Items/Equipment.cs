using UnityEngine;

public enum EquipmentType {
    //weapon, shiled, armor...
}

[CreateAssetMenu]
public class Equipment : Item {
    public int ATKUP;
    public float ATKPercentUp;
    public float CritPercentDown;

    public EquipmentType EquipmentType;

    public void Equip(BaseHero hero) {
        hero.ATK.AddModifier(new StatModifier(ATKUP, StatModType.Flat));
        hero.ATK.AddModifier(new StatModifier(ATKPercentUp, StatModType.PercentAdd));

        hero.Crit.AddModifier(new StatModifier(CritPercentDown, StatModType.PercentAdd));
    }

    public void Unequip(BaseHero hero) {
        hero.ATK.RemoveAllModifiersFromSource(this);
        hero.Crit.RemoveAllModifiersFromSource(this);
    }
}