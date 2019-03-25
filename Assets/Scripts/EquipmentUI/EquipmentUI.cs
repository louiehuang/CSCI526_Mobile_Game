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
    private Vector3 fixedPosition;
    private Vector3 outposition;
    private BaseHero prev;

    void Awake()
    {
        fixedPosition = new Vector3(150f, 320f, 0f);
        outposition = new Vector3(-1000f, -1000f, 0f);
        initialHero = EquipmentManager.instance.knight;
        EquipmentManager.instance.knight.transform.position = fixedPosition;
        prev = EquipmentManager.instance.knight;
    }

    void Start()
    {   
        hasEquipment = new bool[6];
        ui.SetActive(true);
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
        if (prev != null)
        {
            if (prev == EquipmentManager.instance.priest)
            {
                GameObject priest1 = GameObject.Find("Priest1");
                priest1.transform.position = outposition;
            }
            else
            {
                prev.transform.position = outposition;
            }
        }
        EquipmentManager.instance.knight.transform.position = fixedPosition;
        prev = EquipmentManager.instance.knight;
    }

    public void changeArcher()
    {
        changeHero(EquipmentManager.instance.archer);
        if (prev != null)
        {
            if (prev == EquipmentManager.instance.priest)
            {
                GameObject priest1 = GameObject.Find("Priest1");
                priest1.transform.position = outposition;
            }
            else
            {
                prev.transform.position = outposition;
            }
        }
        EquipmentManager.instance.archer.transform.position = fixedPosition;
        prev = EquipmentManager.instance.archer;
    }

    public void changeIceMage()
    {
        changeHero(EquipmentManager.instance.iceMage);
        if (prev != null)
        {
            if (prev == EquipmentManager.instance.priest)
            {
                GameObject priest1 = GameObject.Find("Priest1");
                priest1.transform.position = outposition;
            }
            else
            {
                prev.transform.position = outposition;
            }
           
        }
        EquipmentManager.instance.iceMage.transform.position = fixedPosition;
        prev = EquipmentManager.instance.iceMage;
    }

    public void changeFireMage()
    {
        changeHero(EquipmentManager.instance.fireMage);
        if (prev != null) { 
            if (prev == EquipmentManager.instance.priest)
            {
                GameObject priest1 = GameObject.Find("Priest1");
                priest1.transform.position = outposition;
            }
            else
            {
                prev.transform.position = outposition;
            }
        }
        EquipmentManager.instance.fireMage.transform.position = fixedPosition;
        prev = EquipmentManager.instance.fireMage;
    }

    public void changePreist()
    {   
        changeHero(EquipmentManager.instance.priest);
        GameObject priest1 = GameObject.Find("Priest1");
        priest1.transform.position = fixedPosition;
        if (prev != null && prev)
            if (prev != EquipmentManager.instance.priest)
            {
                prev.transform.position = outposition;
            }
        EquipmentManager.instance.priest.transform.position = fixedPosition;
        prev = EquipmentManager.instance.priest;
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
