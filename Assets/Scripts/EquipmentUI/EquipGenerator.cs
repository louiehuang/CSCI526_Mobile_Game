using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class EquipGenerator : MonoBehaviour
{
    private float ArmorConstant = 1f;
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
        string ArmorPath = "Assets/Icons/Equipments/Armor/";
        List<string> temp = new List<string>();
        List<string> temp1 = new List<string>();
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Armor;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (int)levelCount * Random.Range(0.9f, 1.1f) * ArmorConstant;
        e.MDEF = (int)levelCount * Random.Range(0.9f, 1.1f) * ArmorConstant;
        DirectoryInfo folder = new DirectoryInfo(ArmorPath);
        foreach (FileInfo file in folder.GetFiles("*.png"))
        {
            temp.Add(file.FullName);
            temp1.Add(file.Name);
        }
        int index = Random.Range(0, temp.Count);
        e.path = temp[index];
        e.ename = temp1[index];
        if (true)
        {
            e.Block = levelCount * levelCount * BlockConstant + 0.02f;
        }
        if (true)
        {
            e.CritResistance = levelCount * levelCount * CritResistanceConstant + 0.02f;
        }
        return e;
    }

    public Equipment GenerateShoes(int levelCount) {
        string ShoesPath = "Assets/Icons/Equipments/Boots/";
        List<string> temp = new List<string>();
        List<string> temp1 = new List<string>();
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Shoes;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        e.MDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        DirectoryInfo folder = new DirectoryInfo(ShoesPath);
        foreach (FileInfo file in folder.GetFiles("*.png"))
        {
            temp.Add(file.FullName);
            temp1.Add(file.Name);
        }
        int index = Random.Range(0, temp.Count);
        e.path = temp[index];
        e.ename = temp1[index];
        if (true)
        {
            e.ACC = levelCount * levelCount * 0.7f * ACCConstant + 0.02f;
        }
        if (true)
        {
            e.Dodge = levelCount * levelCount * DodgeConstant + 0.05f;
        }
        return e;
    }

    public Equipment GeneratePants(int levelCount) {
        string PantsPath = "Assets/Icons/Equipments/Pants/";
        List<string> temp = new List<string>();
        List<string> temp1 = new List<string>();
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Pants;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        e.MDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        DirectoryInfo folder = new DirectoryInfo(PantsPath);
        foreach (FileInfo file in folder.GetFiles("*.png"))
        {
            temp.Add(file.FullName);
            temp1.Add(file.Name);
        }
        int index = Random.Range(0, temp.Count);
        e.path = temp[index];
        e.ename = temp1[index];
        if (true)
        {
            e.HP = levelCount * levelCount * Random.Range(0.8f,1.2f) * HPConstant;
        }
        if (true)
        {
            e.CritResistance = levelCount * levelCount * 0.7f * Random.Range(0.8f, 1.2f) * CritResistanceConstant + 0.02f;
        }
        return e;
    }

    public Equipment GenerateHelmet(int levelCount)
    {
        string HelmetPath = "Assets/Icons/Equipments/Helmet/";
        List<string> temp = new List<string>();
        List<string> temp1 = new List<string>();
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Helmet;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        e.MDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        DirectoryInfo folder = new DirectoryInfo(HelmetPath);
        foreach (FileInfo file in folder.GetFiles("*.png"))
        {   
            temp.Add(file.FullName);
            temp1.Add(file.Name);
        }
        int index = Random.Range(0, temp.Count);
        e.path = temp[index];
        e.ename = temp1[index];
        if (true)
        {
            e.ACC = levelCount * levelCount * 0.6f * Random.Range(0.8f, 1.2f) * ACCConstant + 0.01f*levelCount;
        }
        if (true)
        {
            e.Block = levelCount * levelCount * 0.6f * Random.Range(0.8f, 1.2f) * BlockConstant + 0.02f;
        }
        return e;
    }

    public Equipment GenerateGloves(int levelCount)
    {
        string GlovesPath = "Assets/Icons/Equipments/Gloves/";
        List<string> temp = new List<string>();
        List<string> temp1 = new List<string>();
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        e.EquipmentType = EquipmentType.Gloves;
        e.hero = null;
        e.isUsed = false;
        e.PDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        e.MDEF = (int)levelCount * Random.Range(0.8f, 1.2f) * OtherConstant;
        DirectoryInfo folder = new DirectoryInfo(GlovesPath);
        foreach (FileInfo file in folder.GetFiles("*.png"))
        {
            temp.Add(file.FullName);
            temp1.Add(file.Name);
        }
        int index = Random.Range(0, temp.Count);
        e.path = temp[index];
        e.ename = temp1[index];
        if (true)
        {
            e.Pernetration = levelCount * levelCount * Random.Range(0.8f, 1.2f) * PenerationConstant + 0.01f * levelCount;
        }
        if (true)
        {
            e.Crit = levelCount * Random.Range(0.8f, 1.2f) * CritConstant + 0.02f;
        }
        return e;
    }

    public Equipment GenerateWeapon(int levelCount)
    {
        Equipment e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        int index = Random.Range(0, 5);
        if(index == 0)
        {
            int index1 = Random.Range(0, 2);
            if(index1 == 0)
            {
                string SwordPath = "Assets/Icons/Equipments/Sword/";
                List<string> temp = new List<string>();
                List<string> temp1 = new List<string>();
                e.EquipmentType = EquipmentType.Sword;
                e.PATK = (int)(levelCount * Random.Range(0.8f, 1.2f) * WeaponConstant);
                e.MATK = (int)(levelCount * Random.Range(0.8f, 1.2f) * WeaponConstant1);
                e.Crit = levelCount * 1.5f * Random.Range(0.8f, 1.2f) * CritConstant + 0.04f;
                e.CritDMG = levelCount * Random.Range(0.8f, 1.2f) * CritDMGConstant + 0.03f;
                DirectoryInfo folder = new DirectoryInfo(SwordPath);
                foreach (FileInfo file in folder.GetFiles("*.png"))
                {
                    temp.Add(file.FullName);
                    temp1.Add(file.Name);
                }
                int id = Random.Range(0, temp.Count);
                e.path = temp[id];
                e.ename = temp1[id];
            }
            else
            {
                string ShieldPath = "Assets/Icons/Equipments/Shield/";
                List<string> temp = new List<string>();
                List<string> temp1 = new List<string>();
                e.EquipmentType = EquipmentType.Shield;
                e.PDEF = (int)levelCount * 2 * Random.Range(0.8f, 1.2f) * OtherConstant;
                e.MDEF = (int)levelCount * 2 * Random.Range(0.8f, 1.2f) * OtherConstant;
                e.Block = levelCount * 1.5f * Random.Range(0.8f, 1.2f) * BlockConstant + 0.04f;
                e.CritResistance = levelCount * 1.5f * Random.Range(0.8f, 1.2f) * CritResistanceConstant + 0.04f;
                DirectoryInfo folder = new DirectoryInfo(ShieldPath);
                foreach (FileInfo file in folder.GetFiles("*.png"))
                {
                    temp.Add(file.FullName);
                    temp1.Add(file.Name);
                }
                int id = Random.Range(0, temp.Count);
                e.path = temp[id];
                e.ename = temp1[id];
            }

        }
        else if(index == 1)
        {
            string BowPath = "Assets/Icons/Equipments/Bow/";
            List<string> temp = new List<string>();
            List<string> temp1 = new List<string>();
            e.EquipmentType = EquipmentType.Bow;
            e.PATK = (int)(levelCount * Random.Range(0.8f, 1.2f) * WeaponConstant);
            e.MATK = (int)(levelCount * Random.Range(0.8f, 1.2f) * WeaponConstant1);
            e.Crit = levelCount * 1.5f * Random.Range(0.8f, 1.2f) * CritConstant + 0.04f;
            e.CritDMG = levelCount * Random.Range(0.8f, 1.2f) * CritDMGConstant + 0.03f;
            DirectoryInfo folder = new DirectoryInfo(BowPath);
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                temp.Add(file.FullName);
                temp1.Add(file.Name);
            }
            int id = Random.Range(0, temp.Count);
            e.path = temp[id];
            e.ename = temp1[id];
        }
        else
        {
            string StaffPath = "Assets/Icons/Equipments/Staves/";
            List<string> temp = new List<string>();
            List<string> temp1 = new List<string>();
            e.EquipmentType = EquipmentType.Staff;
            e.MATK = (int)(levelCount * Random.Range(0.8f, 1.2f) * WeaponConstant);
            e.PATK = (int)(levelCount * Random.Range(0.8f, 1.2f) * WeaponConstant1);
            e.Crit = levelCount * 1.5f * Random.Range(0.8f, 1.2f) * CritConstant + 0.04f;
            e.CritDMG = levelCount * Random.Range(0.8f, 1.2f) * CritDMGConstant + 0.03f;
            DirectoryInfo folder = new DirectoryInfo(StaffPath);
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                temp.Add(file.FullName);
                temp1.Add(file.Name);
            }
            int id = Random.Range(0, temp.Count);
            e.path = temp[id];
            e.ename = temp1[id];
        }
        e.hero = null;
        e.isUsed = false;
        return e;
    }
}