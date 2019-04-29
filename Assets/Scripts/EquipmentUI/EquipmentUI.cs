using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class EquipmentUI : MonoBehaviour
{
    public List<Equipment> equipments;

    public GameObject ui;
    public SingleEquipment helmet;
    public SingleEquipment gloves;
    public SingleEquipment weapon;
    public SingleEquipment armor;
    public SingleEquipment pants;
    public SingleEquipment shoes;
    public GameObject Scroller;
    public string initialHero;
    private bool[] hasEquipment;
    private Vector3 fixedPosition;
    private Vector3 outposition;
    private GameObject prev;
    void Awake()
    {
        prev = GameObject.Find("Knight1");
        fixedPosition = new Vector3(150f, 320f, 0f);
        outposition = new Vector3(-1000f, -1000f, 0f);
        prev.transform.position = fixedPosition;
        hasEquipment = new bool[6];
        GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Helmet");
        if (temp != null)
        {
            SingleEquipment e = temp.GetComponent<SingleEquipment>();
            e.noneName = "Helmet";
        }
        temp = GameObject.Find("/EquipmentUI/Equipments/Weapon");
        if (temp != null)
        {
            SingleEquipment e = temp.GetComponent<SingleEquipment>();
            e.noneName = "Weapon";
        }
        temp = GameObject.Find("/EquipmentUI/Equipments/Pants");
        if (temp != null)
        {
            SingleEquipment e = temp.GetComponent<SingleEquipment>();
            e.noneName = "Pants";
        }
        temp = GameObject.Find("/EquipmentUI/Equipments/Gloves");
        if (temp != null)
        {
            SingleEquipment e = temp.GetComponent<SingleEquipment>();
            e.noneName = "Gloves";
        }
        temp = GameObject.Find("/EquipmentUI/Equipments/Armor");
        if (temp != null)
        {
            SingleEquipment e = temp.GetComponent<SingleEquipment>();
            e.noneName = "Armor";
        }
        temp = GameObject.Find("/EquipmentUI/Equipments/Shoes");
        if (temp != null)
        {
            SingleEquipment e = temp.GetComponent<SingleEquipment>();
            e.noneName = "Shoes";
        }
    }

    void Start()
    {
        initialHero = CommonConfig.Knight;
        ui.SetActive(true);
        GetHeroEquiments(initialHero);
        helmet.type = EquipmentType.Helmet;
        gloves.type = EquipmentType.Gloves;
        weapon.type = EquipmentType.Sword;
        armor.type = EquipmentType.Armor;
        pants.type = EquipmentType.Pants;
        shoes.type = EquipmentType.Shoes;
        changeHero(initialHero);
        Scroller = GameObject.Find("Canvas/UnEquipments");
        if (Scroller != null)
        {
            Scroller.transform.position = new Vector3(-1000f, -1000f, 0f);

        }
        if (EquipmentManager.instance.getHeroEquipment("knight").Count == 0 && EquipmentStorage.hasNeverUsed == false)
        {
            addInitialEquipment();
        }

        for (int i = 0; i < equipments.Count; i++)
        {
            if (equipments[i].EquipmentType == EquipmentType.Helmet)
            {
                helmet.setEquipment(equipments[i]);
                hasEquipment[0] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Gloves)
            {
                gloves.setEquipment(equipments[i]);
                hasEquipment[1] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Pants)
            {
                pants.setEquipment(equipments[i]);
                hasEquipment[4] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Shoes)
            {
                shoes.setEquipment(equipments[i]);
                hasEquipment[5] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Armor)
            {
                armor.setEquipment(equipments[i]);
                hasEquipment[3] = true;
            }
            else
            {
                weapon.setEquipment(equipments[i]);
                hasEquipment[2] = true;
            }
        }

    }

    public void GetHeroEquiments(string hero)
    {
        equipments = EquipmentManager.instance.getHeroEquipment(hero);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void close()
    {
        hide();
    }

    public void changeKnight()
    {
        changeHero(CommonConfig.Knight);
        GameObject t = GameObject.Find("Knight1");
        weapon.type = EquipmentType.Sword;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeArcher()
    {
        changeHero(CommonConfig.Archer);
        GameObject t = GameObject.Find("Archer1");
        weapon.type = EquipmentType.Bow;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeIceMage()
    {
        changeHero(CommonConfig.IceMage);
        GameObject t = GameObject.Find("IceMage1");
        weapon.type = EquipmentType.Staff;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeFireMage()
    {
        changeHero(CommonConfig.FireMage);
        GameObject t = GameObject.Find("FireMage1");
        weapon.type = EquipmentType.Staff;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changePreist()
    {
        changeHero(CommonConfig.Priest);
        GameObject t = GameObject.Find("Priest1");
        weapon.type = EquipmentType.Staff;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeHero(string hero)
    {
        EquipmentManager.instance.nodeUI1.hero = hero;
        GetHeroEquiments(hero);
        initialHero = hero;
        GameObject temp;
        SingleEquipment tempS;
        temp = GameObject.Find("/EquipmentUI/Equipments/Helmet");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        temp = GameObject.Find("/EquipmentUI/Equipments/Armor");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        temp = GameObject.Find("/EquipmentUI/Equipments/Pants");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        temp = GameObject.Find("/EquipmentUI/Equipments/Shoes");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        temp = GameObject.Find("/EquipmentUI/Equipments/Weapon");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        temp = GameObject.Find("/EquipmentUI/Equipments/Gloves");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        temp = GameObject.Find("/HasEquipmentNode");
        if (temp != null)
        {
            HasEquipmentNode tempH;
            tempH = temp.GetComponent<HasEquipmentNode>();
            tempH.close();
        }
        helmet.setEquipment(null);
        gloves.setEquipment(null);
        weapon.setEquipment(null);
        armor.setEquipment(null);
        pants.setEquipment(null);
        shoes.setEquipment(null);
        for (int i = 0; i < 6; i++)
        {
            hasEquipment[i] = false;
        }

        for (int i = 0; i < equipments.Count; i++)
        {
            if (equipments[i].EquipmentType == EquipmentType.Helmet)
            {
                helmet.setEquipment(equipments[i]);
                hasEquipment[0] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Gloves)
            {
                gloves.setEquipment(equipments[i]);
                hasEquipment[1] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Pants)
            {
                pants.setEquipment(equipments[i]);
                hasEquipment[4] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Shoes)
            {
                shoes.setEquipment(equipments[i]);
                hasEquipment[5] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Armor)
            {
                armor.setEquipment(equipments[i]);
                hasEquipment[3] = true;
            }
            else
            {
                weapon.setEquipment(equipments[i]);
                hasEquipment[2] = true;
            }
        }
    }

    private void addInitialEquipment(){
        Equipment e = EquipmentManager.instance.generator.GenerateArmor(1);
        EquipmentManager.instance.getHeroEquipment(CommonConfig.Knight).Add(e);
        e.isUsed = true;
        e = EquipmentManager.instance.generator.GenerateHelmet(1);
        EquipmentManager.instance.getHeroEquipment(CommonConfig.Knight).Add(e);
        e.isUsed = true;
        e = EquipmentManager.instance.generator.GeneratePants(1);
        EquipmentManager.instance.getHeroEquipment(CommonConfig.Knight).Add(e);
        e.isUsed = true;
        e = EquipmentManager.instance.generator.GenerateGloves(1);
        EquipmentManager.instance.getHeroEquipment(CommonConfig.Knight).Add(e);
        e.isUsed = true;
        e = EquipmentManager.instance.generator.GenerateShoes(1);
        EquipmentManager.instance.getHeroEquipment(CommonConfig.Knight).Add(e);
        e.isUsed = true;

        e = (Equipment)ScriptableObject.CreateInstance("Equipment");
        string SwordPath = "Equipments/Sword/";
        List<string> temp1 = EquipmentStorage.Sword;
        e.EquipmentType = EquipmentType.Sword;
        e.PATK = (int)(1 * UnityEngine.Random.Range(0.8f, 1.2f) * 1.0f);
        e.MATK = (int)(1 * UnityEngine.Random.Range(0.8f, 1.2f) * 0.5f);
        e.Crit = (float)Math.Round(1 * 1.5f * UnityEngine.Random.Range(0.8f, 1.2f) * 0.03f + 0.04f, 2);
        e.CritDMG = (float)Math.Round(1 * UnityEngine.Random.Range(0.8f, 1.2f) * 0.03f + 0.03f, 2);
        int id = UnityEngine.Random.Range(0, temp1.Count);
        e.path = SwordPath + temp1[id];
        e.ename = temp1[id];
        e.isUsed = true;
        EquipmentManager.instance.getHeroEquipment(CommonConfig.Knight).Add(e);
        EquipmentStorage.hasNeverUsed = true;
    }
}

