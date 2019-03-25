using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    private Dictionary<EquipmentType, List<Equipment>> unEquipped;
    private Dictionary<BaseHero, List<Equipment>> Equipped;
    public UnEquipmentNode nodeUI;
    public HasEquipmentNode nodeUI1;
    public EquipmentUI equipmentUI;
    public NonEquipmentUI nonequipmentUI;
    public BaseHero hero;
    public int ElimatedEnermy;
    private int levelCount;
    private double factor;
    public Knight knight;
    public IceMage iceMage;
    public FireMage fireMage;
    public Priest priest;
    public Archer archer;

    void Awake()
    {   
        if (instance != null)
        {   
            if (nodeUI != null)
            {
                nodeUI.ui.SetActive(false);
                nonequipmentUI.ui.SetActive(true);
            }
            else if(nodeUI1 != null)
            {
                nodeUI1.ui.SetActive(false);
                nodeUI1.hero = knight;
                equipmentUI.ui.SetActive(true);
            }
            return;
        }
        instance = this;
        unEquipped = new Dictionary<EquipmentType, List<Equipment>>();
        Equipped = new Dictionary<BaseHero, List<Equipment>>();
        List<Equipment> tem1 = new List<Equipment>();
        List<Equipment> tem2 = new List<Equipment>();
        List<Equipment> tem3 = new List<Equipment>();
        List<Equipment> tem4 = new List<Equipment>();
        List<Equipment> tem5 = new List<Equipment>();
        Equipment e1 = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e1.ename = "iron helmet";
        e1.ATK = 1;
        e1.ATKPercent = 2.0f;
        e1.isUsed = true;
        e1.hero = knight;
        e1.EquipmentType = EquipmentType.Helmet;
        e1.value = 97;
        e1.CritPercent = 0.5f;

        Equipment e2 = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e2.ename = "iron sowrd";
        e2.ATK = 5;
        e2.ATKPercent = 1.0f;
        e2.isUsed = true;
        e2.hero = knight;
        e2.EquipmentType = EquipmentType.Sword;
        e2.value = 103;
        e2.CritPercent = 1.4f;

        Equipment e3 = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e3.ename = "Wooden Staff";
        e3.ATK = 3;
        e3.ATKPercent = 2.0f;
        e3.isUsed = true;
        e3.hero = iceMage;
        e3.EquipmentType = EquipmentType.Staff;
        e3.value = 93;
        e3.CritPercent = 1.2f;
        /*Equipment e1 = new Equipment
        {   
            ename = "iron helmet",
            ATK = 20,
            ATKPercent = 1.0f,
            isUsed = true,
            hero = knight,
            EquipmentType = EquipmentType.Helmet,
            value = 97,
            CritPercent = 1.2f,
        };
        Equipment e2 = new Equipment
        {
            ename = "iron sword",
            ATK = 40,
            ATKPercent = 1.0f,
            isUsed = true,
            hero = knight,
            EquipmentType = EquipmentType.Sword,
            value = 97,
            CritPercent = 1.2f,
        };
        Equipment e3 = new Equipment
        {
            ename = "magic hat",
            ATK = 40,
            ATKPercent = 1.0f,
            isUsed = false,
            hero = knight,
            EquipmentType = EquipmentType.Helmet,
            value = 97,
            CritPercent = 1.2f,
        };*/
        tem1.Add(e1);
        tem1.Add(e2);
        tem2.Add(e3);
        Equipped[knight] = tem1;
        Equipped[iceMage] = tem2;
        Equipped[fireMage] = tem3;
        Equipped[priest] = tem4;
        Equipped[archer] = tem5;

        unEquipped[EquipmentType.Sword] = new List<Equipment>();
        unEquipped[EquipmentType.Shield] = new List<Equipment>();
        unEquipped[EquipmentType.Staff] = new List<Equipment>();
        unEquipped[EquipmentType.Bow] = new List<Equipment>();
        unEquipped[EquipmentType.Helmet] = new List<Equipment>();
        //unEquipped[EquipmentType.Helmet].Add(e3);
        unEquipped[EquipmentType.Armor] = new List<Equipment>();
        unEquipped[EquipmentType.Gloves] = new List<Equipment>();
        unEquipped[EquipmentType.Pants] = new List<Equipment>();
        unEquipped[EquipmentType.Shoes] = new List<Equipment>();
        if (nodeUI != null)
        {
            nodeUI.ui.SetActive(false);
            nonequipmentUI.ui.SetActive(true);
        }
        else if (nodeUI1 != null)
        {
            nodeUI1.ui.SetActive(false);
            nodeUI1.hero = knight;
            equipmentUI.ui.SetActive(true);
        }
        levelCount = 0;
        factor = 0.5;
        this.hero = null;
        for(int i = 0; i < 2; i++)
        {
            Equipment e = (Equipment) ScriptableObject.CreateInstance("Equipment");
            //Equipment e = new Equipment();
            e.EquipmentType = EquipmentType.Armor;
            unEquipped[e.EquipmentType].Add(e);
        }
    }

    public void ShowEquipped(BaseHero hero)
    {
        equipmentUI.GetHeroEquiments(hero);
    }


    public List<Equipment> getHeroEquipment(BaseHero hero)
    {
        return Equipped[hero];
    }

    public List<Equipment> getUnequippedEquipment(EquipmentType type)
    {
        return unEquipped[type];
    }

    public void selectEquippedEuipment(Equipment p, EquipmentType type)
    {
        nodeUI1.ui.SetActive(true);
        nodeUI1.set(p,type);
    }

    public void selectEquippedEuipment(EquipmentType type)
    {
        nodeUI1.ui.SetActive(true);
        nodeUI1.set(null, type);
    }

    public void selectUnEquippedEuipment(Equipment p)
    {
        nodeUI.ui.SetActive(true);
        nodeUI.Set(p);
    }

    private void addEquipment(List<Equipment> equipments)
    {
        for (int i = 0; i < equipments.Count; i++)
        {
            unEquipped[equipments[i].EquipmentType].Add(equipments[i]);
        }
    }

    public void CalculateAfterGame()
    {
        ElimatedEnermy = 20;
        levelCount = 1;
        int numEquipment = (int)(ElimatedEnermy * levelCount * factor);
        int normalATK = 0;
        float normalATKPercent = 0.0f;
        float normalCritiPercent = 0.0f;
        List<Equipment> list = new List<Equipment>();
        for (int i = 0; i < numEquipment; i++)
        {
            int randomATK = Random.Range(-10, 10);
            float randomATKPercent = Random.Range(-3.0f, 3.0f);
            float randomCritiPercent = Random.Range(-2.0f, 2.0f);
            Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
            e.EquipmentType = (EquipmentType)Random.Range(0, 6);
            e.ATKPercent = normalATKPercent + randomATKPercent;
            e.ATK = normalATK + randomATK;
            e.hero = null;
            e.isUsed = false;
            e.value = (int)((normalATK + randomATK) * (1 + randomATKPercent / normalATKPercent));
            e.CritPercent = normalCritiPercent + randomATKPercent;
            //unEquipped[e.EquipmentType].Add(e);
            /*Equipment equipment = new Equipment
            {    
            ATK = normalATK + randomATK,
                ATKPercent = normalATKPercent + randomATKPercent,
                isUsed = false,
                hero = null,
                EquipmentType = (EquipmentType)Random.Range(0, 6),
                value = (int)((normalATK + randomATK) * (1 + randomATKPercent / normalATKPercent)),
                CritPercent = normalCritiPercent + randomATKPercent,
            };*/
            list.Add(e);
        }
        addEquipment(list);
    }
}
