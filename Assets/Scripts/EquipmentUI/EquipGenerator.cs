using UnityEngine;
using System;
using System.Collections.Generic;

public class EquipGenerator : MonoBehaviour
{

    private float ArmorConstant = 3f;
    private float OtherConstant = 0.4f;
    private float BlockConstant = 0.003f;
    private float DodgeConstant = 0.003f;
    private float ACCConstant = 0.01f;
    private float PenerationConstant = 0.01f;
    private float HPConstant = 5f;
    private float CritResistanceConstant = 0.01f;
    private float CritConstant = 0.03f;
    private float CritDMGConstant = 0.03f;
    private float WeaponConstant = 2.0f;
    private float WeaponConstant1 = 0.5f;


    public Equipment GenerateArmor(int levelCount)
    {
        string ArmorPath = "Equipments/Armor/";
        List<string> temp1 =EquipmentStorage.Armor;
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Armor;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.9f, 1.1f) * ArmorConstant,2);
        e.MDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.9f, 1.1f) * ArmorConstant,2);
        int index =  UnityEngine.Random.Range(0, temp1.Count);
        e.path = ArmorPath+temp1[index];
        e.ename = temp1[index];
        if (true)
        {
            e.Block = (float)Math.Round(levelCount * levelCount * BlockConstant + 0.02f,2);
        }
        if (true)
        {
            e.CritResistance = (float)Math.Round(levelCount * levelCount * CritResistanceConstant + 0.02,2);
        }
        return e;
    }

    public Equipment GenerateShoes(int levelCount) {
        string ShoesPath = "Equipments/Boots/";
        List<string> temp1 = EquipmentStorage.Boot;
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Shoes;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        e.MDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        int index =  UnityEngine.Random.Range(0, temp1.Count);
        e.path = ShoesPath + temp1[index];
        e.ename = temp1[index];
        if (true)
        {
            e.ACC = (float)Math.Round(levelCount * levelCount * 0.7f * ACCConstant + 0.02f,2);
        }
        if (true)
        {
            e.Dodge = (float)Math.Round(levelCount * levelCount * DodgeConstant + 0.05f,2);
        }
        return e;
    }

    public Equipment GeneratePants(int levelCount) {
        string PantsPath = "Equipments/Pants/";
        List<string> temp1 = EquipmentStorage.Pants;
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Pants;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (float)Math.Round(levelCount * UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        e.MDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        int index =  UnityEngine.Random.Range(0, temp1.Count);
        e.path = PantsPath+temp1[index];
        e.ename = temp1[index];
        if (true)
        {
            e.HP = (int)levelCount * levelCount *  UnityEngine.Random.Range(0.8f,1.2f) * HPConstant;
        }
        if (true)
        {
            e.CritResistance = (float)Math.Round(levelCount * levelCount * 0.7f *  UnityEngine.Random.Range(0.8f, 1.2f) * CritResistanceConstant + 0.02f,2);
        }
        return e;
    }

    public Equipment GenerateHelmet(int levelCount)
    {
        string HelmetPath = "Equipments/Helmet/";
        List<string> temp1 = EquipmentStorage.Helmet;
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Helmet;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        e.MDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        int index =  UnityEngine.Random.Range(0, temp1.Count);
        e.path = HelmetPath+temp1[index];
        e.ename = temp1[index];
        if (true)
        {
            e.ACC = (float)Math.Round(levelCount * levelCount * 0.6f *  UnityEngine.Random.Range(0.8f, 1.2f) * ACCConstant + 0.01f*levelCount,2);
        }
        if (true)
        {
            e.Block = (float)Math.Round(levelCount * levelCount * 0.6f *  UnityEngine.Random.Range(0.8f, 1.2f) * BlockConstant + 0.02f,2);
        }
        return e;
    }

    public Equipment GenerateGloves(int levelCount)
    {
        string GlovesPath = "Equipments/Gloves/";
        List<string> temp1 = EquipmentStorage.Gloves;
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Gloves;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
        e.MDEF = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2); 
        int index =  UnityEngine.Random.Range(0, temp1.Count);
        e.path = GlovesPath+temp1[index];
        e.ename = temp1[index];
        if (true)
        {
            e.Pernetration = (float)Math.Round(levelCount * levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * PenerationConstant + 0.01f * levelCount,2);
        }
        if (true)
        {
            e.Crit = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * CritConstant + 0.02f,2);
        }
        return e;
    }

    public Equipment GenerateWeapon(int levelCount)
    {
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        int index =  UnityEngine.Random.Range(0, 5);
        if(index == 0)
        {
            int index1 =  UnityEngine.Random.Range(0, 2);
            if(index1 == 0)
            {
                string SwordPath = "Equipments/Sword/";
                List<string> temp1 = EquipmentStorage.Sword;
                e.EquipmentType = EquipmentType.Sword;
                e.PATK = (int)(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * WeaponConstant);
                e.MATK = (int)(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * WeaponConstant1);
                e.Crit = (float)Math.Round(levelCount * 1.5f *  UnityEngine.Random.Range(0.8f, 1.2f) * CritConstant + 0.04f,2);
                e.CritDMG = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * CritDMGConstant + 0.03f,2);
                int id =  UnityEngine.Random.Range(0, temp1.Count);
                e.path = SwordPath+temp1[id];
                e.ename = temp1[id];
            }
            else
            {
                string ShieldPath = "Equipments/Shield/";
                List<string> temp1 = EquipmentStorage.Shield;
                e.EquipmentType = EquipmentType.Shield;
                e.PDEF = (float)Math.Round(levelCount * 2 *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
                e.MDEF = (float)Math.Round(levelCount * 2 *  UnityEngine.Random.Range(0.8f, 1.2f) * OtherConstant,2);
                e.Block = (float)Math.Round(levelCount * 1.5f *  UnityEngine.Random.Range(0.8f, 1.2f) * BlockConstant + 0.04f,2);
                e.CritResistance = (float)Math.Round(levelCount * 1.5f *  UnityEngine.Random.Range(0.8f, 1.2f) * CritResistanceConstant + 0.04f,2);
                int id =  UnityEngine.Random.Range(0, temp1.Count);
                e.path = ShieldPath+temp1[id];
                e.ename = temp1[id];
            }

        }
        else if(index == 1)
        {
            string BowPath = "Equipments/Bow/";
            List<string> temp1 = EquipmentStorage.Bow;
            e.EquipmentType = EquipmentType.Bow;
            e.PATK = (int)(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * WeaponConstant);
            e.MATK = (int)(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * WeaponConstant1);
            e.Crit = (float)Math.Round(levelCount * 1.5f *  UnityEngine.Random.Range(0.8f, 1.2f) * CritConstant + 0.04f,2);
            e.CritDMG = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * CritDMGConstant + 0.03f,2);
            int id =  UnityEngine.Random.Range(0, temp1.Count);
            e.path = BowPath+temp1[id];
            e.ename = temp1[id];
        }
        else
        {
            string StaffPath = "Equipments/Staves/";
            List<string> temp1 = EquipmentStorage.Staves;
            e.EquipmentType = EquipmentType.Staff;
            e.MATK = (int)(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * WeaponConstant);
            e.PATK = (int)(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * WeaponConstant1);
            e.Crit = (float)Math.Round(levelCount * 1.5f *  UnityEngine.Random.Range(0.8f, 1.2f) * CritConstant + 0.04f,2);
            e.CritDMG = (float)Math.Round(levelCount *  UnityEngine.Random.Range(0.8f, 1.2f) * CritDMGConstant + 0.03f,2);
            int id =  UnityEngine.Random.Range(0, temp1.Count);
            e.path = StaffPath+temp1[id];
            e.ename = temp1[id];
        }
        e.hero = null;
        e.isUsed = false;
        return e;
    }
}