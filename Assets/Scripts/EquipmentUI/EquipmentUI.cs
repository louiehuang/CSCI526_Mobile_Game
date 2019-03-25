using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    private EquipmentType type;
    public List<Equipment> equipments;

    public GameObject ui;
    public SingleEquipment helmet;
    public SingleEquipment gloves;
    public SingleEquipment weapon;
    public SingleEquipment armor;
    public SingleEquipment pants;
    public SingleEquipment shoes;
    public BaseHero initialHero;
    private bool[] hasEquipment;

    void Start()
    {
        hasEquipment = new bool[6];
        ui.SetActive(true);
        initialHero = EquipmentManager.instance.knight;
        Debug.Log(initialHero);
        GetHeroEquiments(initialHero);
        helmet.type = EquipmentType.Helmet;
        gloves.type = EquipmentType.Gloves;
        weapon.type = EquipmentType.Helmet;
        armor.type = EquipmentType.Armor;
        pants.type = EquipmentType.Pants;
        shoes.type = EquipmentType.Shoes;

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
                Debug.Log(equipments[i].ename);
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
    }

    public void changeArcher()
    {
        changeHero(EquipmentManager.instance.archer);
    }

    public void changeIceMage()
    {
        changeHero(EquipmentManager.instance.iceMage);
    }

    public void changeFireMage()
    {
        changeHero(EquipmentManager.instance.fireMage);
    }

    public void changePreist()
    {
        changeHero(EquipmentManager.instance.priest);
    }

    public void changeHero(BaseHero hero)
    {
        GetHeroEquiments(hero);
        initialHero = hero;
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
                hasEquipment[2] = true;
            }
        }
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
        if (temp == null) return;
        HasEquipmentNode tempH;
        tempH = temp.GetComponent<HasEquipmentNode>();
        tempH.close();
    }

}
