using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
    public BaseHero initialHero;
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
    }

   void Start()
    {
        initialHero = EquipmentManager.instance.knight;
        hasEquipment = new bool[6];
        ui.SetActive(true);
        GetHeroEquiments(initialHero);
        helmet.type = EquipmentType.Helmet;
        gloves.type = EquipmentType.Gloves;
        weapon.type = EquipmentType.Sword;
        armor.type = EquipmentType.Armor;
        pants.type = EquipmentType.Pants;
        shoes.type = EquipmentType.Shoes;

        Scroller = GameObject.Find("Canvas/UnEquipments");
        if (Scroller != null)
        {
            Scroller.transform.position = new Vector3(-1000f, -1000f, 0f);
           /* ScrollViewManager manager = Scroller.GetComponent<ScrollViewManager>();
            manager.ui.SetActive(false);*/
        }


        for (int i = 0; i < equipments.Count; i++)
        {
            if(equipments[i].EquipmentType == EquipmentType.Helmet)
            {
                helmet.setEquipment(equipments[i]);
                hasEquipment[0] = true;
            }
            else if (equipments[i].EquipmentType == EquipmentType.Gloves)
            {
                gloves.setEquipment(equipments[i]);
                hasEquipment[1] = true;
            }
            else if(equipments[i].EquipmentType == EquipmentType.Pants)
            {
                pants.setEquipment(equipments[i]);
                hasEquipment[4] = true;
            }
            else if(equipments[i].EquipmentType == EquipmentType.Shoes)
            {
                shoes.setEquipment(equipments[i]);
                hasEquipment[5] = true;
            }
            else if(equipments[i].EquipmentType == EquipmentType.Armor)
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

    public void GetHeroEquiments(BaseHero hero)
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
        changeHero(EquipmentManager.instance.knight);
        GameObject t = GameObject.Find("Knight1");
        weapon.type = EquipmentType.Sword;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeArcher()
    {
        changeHero(EquipmentManager.instance.archer);
        GameObject t = GameObject.Find("Archer1");
        weapon.type = EquipmentType.Bow;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeIceMage()
    {
        changeHero(EquipmentManager.instance.iceMage);
        GameObject t = GameObject.Find("IceMage1");
        weapon.type = EquipmentType.Staff;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeFireMage()
    {
        changeHero(EquipmentManager.instance.fireMage);
        GameObject t = GameObject.Find("FireMage1");
        weapon.type = EquipmentType.Staff;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changePreist()
    {   
        changeHero(EquipmentManager.instance.priest);
        GameObject t = GameObject.Find("Priest1");
        weapon.type = EquipmentType.Staff;
        prev.transform.position = outposition;
        t.transform.position = fixedPosition;
        prev = t;
    }

    public void changeHero(BaseHero hero)
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
        for(int i = 0; i < 6; i++)
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
            else if(equipments[i].EquipmentType == EquipmentType.Pants)
            {
                pants.setEquipment(equipments[i]);
                hasEquipment[4] = true;
            }
            else if(equipments[i].EquipmentType == EquipmentType.Shoes)
            {
                shoes.setEquipment(equipments[i]);
                hasEquipment[5] = true;
            }
            else if(equipments[i].EquipmentType == EquipmentType.Armor)
            {
                armor.setEquipment(equipments[i]);
                hasEquipment[3] = true;
            }
            else
            {   
                weapon.setEquipment(equipments[i]);
              /*  if(equipments[i].EquipmentType == EquipmentType.Sword)
                {

                }*/
                hasEquipment[2] = true;
            }
        }
        /*GameObject temp;
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
        if (temp == null) return;
        HasEquipmentNode tempH;
        tempH = temp.GetComponent<HasEquipmentNode>();
        tempH.close();*/
    }

}
