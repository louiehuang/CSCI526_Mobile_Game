using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EquipmentType
{
    Helmet,
    Gloves,
    Armor,
    Pants,
    Shoes,
    Sword,
    Shield,
    Staff,
    Bow
}

[CreateAssetMenu]
public class Equipment : Item {
    public int PATK = 0;
    public int MATK = 0;
    public float PDEF = 0.0f;
    public float MDEF = 0.0f;
    public float Crit = 0.0f;
    public float CritDMG = 0.0f;
    public float Block = 0.0f;
    public float Dodge = 0.0f;
    public float ACC = 0.0f;
    public float Pernetration = 0.0f;
    public float CritResistance = 0.0f;
    public float HP = 0.0f;
    public float ATKSpeed = 0.0f;
    public string path = "Assets/Icons/Equipments/Blank.jpg";

    public bool isUsed = false;
    public BaseHero hero = null;
    public EquipmentType EquipmentType = EquipmentType.Armor;
    public int value = 100;
    public string ename = "armor";


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
        if(EquipmentType == EquipmentType.Helmet)
        {
            hero.PDEF.AddModifier(new StatModifier(PDEF, StatModType.Flat));
            hero.MDEF.AddModifier(new StatModifier(MDEF, StatModType.Flat));
            hero.ACC.AddModifier(new StatModifier(ACC, StatModType.PercentAdd,this));
            hero.Block.AddModifier(new StatModifier(Block, StatModType.PercentAdd,this));
        }
        else if (EquipmentType == EquipmentType.Armor)
        {
            hero.PDEF.AddModifier(new StatModifier(PDEF, StatModType.Flat));
            hero.MDEF.AddModifier(new StatModifier(MDEF, StatModType.Flat));
            hero.Block.AddModifier(new StatModifier(Block, StatModType.PercentAdd, this));
            hero.CritResistance.AddModifier(new StatModifier(Block, StatModType.PercentAdd,this));
        }
        else if (EquipmentType == EquipmentType.Gloves)
        {
            hero.PDEF.AddModifier(new StatModifier(PDEF, StatModType.Flat));
            hero.MDEF.AddModifier(new StatModifier(MDEF, StatModType.Flat));
            hero.Pernetration.AddModifier(new StatModifier(Pernetration, StatModType.PercentAdd, this));
            hero.Crit.AddModifier(new StatModifier(Crit, StatModType.PercentAdd, this));
        }
        else if (EquipmentType == EquipmentType.Pants)
        {
            hero.PDEF.AddModifier(new StatModifier(PDEF, StatModType.Flat));
            hero.MDEF.AddModifier(new StatModifier(MDEF, StatModType.Flat));
            hero.MaxHP.AddModifier(new StatModifier(HP, StatModType.Flat));
            hero.CritResistance.AddModifier(new StatModifier(CritResistance, StatModType.PercentAdd, this));
        }
        else if (EquipmentType == EquipmentType.Shoes)
        {
            hero.PDEF.AddModifier(new StatModifier(PDEF, StatModType.Flat));
            hero.MDEF.AddModifier(new StatModifier(MDEF, StatModType.Flat));
            hero.Dodge.AddModifier(new StatModifier(Dodge, StatModType.PercentAdd, this));
            hero.ACC.AddModifier(new StatModifier(ACC, StatModType.PercentAdd, this));
        }
        else
        {   
            if(EquipmentType == EquipmentType.Shield)
            {
                hero.PDEF.AddModifier(new StatModifier(PDEF, StatModType.Flat));
                hero.MDEF.AddModifier(new StatModifier(MDEF, StatModType.Flat));
                hero.Dodge.AddModifier(new StatModifier(Dodge, StatModType.PercentAdd, this));
                hero.CritResistance.AddModifier(new StatModifier(Block, StatModType.PercentAdd, this));
            }
            else
            {
                hero.ATK.AddModifier(new StatModifier(PATK, StatModType.Flat));
                hero.MATK.AddModifier(new StatModifier(MATK, StatModType.Flat));
                hero.Crit.AddModifier(new StatModifier(Crit, StatModType.PercentAdd, this));
                hero.CritDMG.AddModifier(new StatModifier(CritDMG, StatModType.PercentAdd, this));
            }
        }
        List<Equipment> list = EquipmentManager.instance.getHeroEquipment(hero);
        this.hero = hero;
        Debug.Log(hero);
        list.Add(this);
        list = EquipmentManager.instance.getUnequippedEquipment(this.EquipmentType);
        list.Remove(this);
        isUsed = true;
    }

    public void Unequip(BaseHero hero)
    {
        hero.ATK.RemoveAllModifiersFromSource(this);
        hero.Crit.RemoveAllModifiersFromSource(this);
        hero.CritDMG.RemoveAllModifiersFromSource(this);
        hero.MATK.RemoveAllModifiersFromSource(this);
        hero.ACC.RemoveAllModifiersFromSource(this);
        hero.Dodge.RemoveAllModifiersFromSource(this);
        hero.Pernetration.RemoveAllModifiersFromSource(this);
        hero.CritResistance.RemoveAllModifiersFromSource(this);
        hero.MaxHP.RemoveAllModifiersFromSource(this);
        hero.PDEF.RemoveAllModifiersFromSource(this);
        hero.MDEF.RemoveAllModifiersFromSource(this);
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