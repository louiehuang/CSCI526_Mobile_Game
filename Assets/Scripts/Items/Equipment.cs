using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType
{   
    Sword,
    Shield,
    Staff,
    Bow,
    Helmet,
    Gloves,
    Armor,
    Pants,
    Shoes
}

[CreateAssetMenu]
public class Equipment : Item {
    public int ATK = 10;
    public float ATKPercent = 0.1f;
    public float CritPercent = -0.05f;
    public float PDEF = 3.0f;
    public float MDEF = 30.0f;
    public float Crit = 0.05f;
    public float Block = 0.0f;

    public bool isUsed = false;
    public BaseHero hero = null;
    public EquipmentType EquipmentType = EquipmentType.Armor;
    public int value = 100;
    public string ename = "armor";
    public Image image = null;

    public void Equip(BaseHero hero)
    {
        bool hasEquipped = false;
        Equipment temp = null;
        foreach (Equipment e in EquipmentManager.instance.getHeroEquipment(hero))
        {
            if (e.EquipmentType == this.EquipmentType)
            {
                hasEquipped = true;
                temp = e;
                break;
            }
        }
        if (hasEquipped)
        {
            temp.Unequip(hero);
        }
        hero.ATK.AddModifier(new StatModifier(ATK, StatModType.Flat));
        hero.ATK.AddModifier(new StatModifier(ATKPercent, StatModType.PercentAdd, this));
        hero.Crit.AddModifier(new StatModifier(CritPercent, StatModType.PercentAdd, this));
        List<Equipment> list = EquipmentManager.instance.getHeroEquipment(hero);
        this.hero = hero;
        list.Add(this);
        list = EquipmentManager.instance.getUnequippedEquipment(this.EquipmentType);
        list.Remove(this);
        isUsed = true;
    }

    public void Unequip(BaseHero hero)
    {
        hero.ATK.RemoveAllModifiersFromSource(this);
        hero.Crit.RemoveAllModifiersFromSource(this);
        List<Equipment> temp = EquipmentManager.instance.getHeroEquipment(hero);
        temp.Remove(this);
        this.hero = null;
        isUsed = false;
        temp = EquipmentManager.instance.getUnequippedEquipment(this.EquipmentType);
        temp.Add(this);
    }

    public void Destroy()
    {
        List<Equipment> temp = EquipmentManager.instance.getUnequippedEquipment(
        this.EquipmentType);
        temp.Remove(this);
        Destroy(this);
    }

}