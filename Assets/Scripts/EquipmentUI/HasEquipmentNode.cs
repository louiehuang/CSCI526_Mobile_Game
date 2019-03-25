using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HasEquipmentNode : MonoBehaviour
{
    public GameObject ui;
    public Equipment equipment;
    public Text euipmentName;
    public Text value;
    public Text ATK;
    public Text ATKPercent;
    public Text CritPercent;
    public Text typeName;
    public Image image;
    public EquipmentType forNull;
    public List<GameObject> temp;
    private bool hasClick;
    public GameObject prefab;
    public BaseHero hero;

    private void Awake()
    {
        hasClick = false;
        ui.SetActive(false);
    }

    public void change()
    {      
        if(hasClick == true)
        {
            for(int i = 0; i < temp.Count; i++)
            {
                Destroy(temp[i]);
            }
            temp = new List<GameObject>();
        }
        else
        {
            List<Equipment> list;
            if (equipment == null)
            {
                list = EquipmentManager.instance.getUnequippedEquipment(forNull);
            }
            else
            {
                list = EquipmentManager.instance.getUnequippedEquipment(equipment.EquipmentType);
            }
            for (int i = 0; i < list.Count; i++)
            {
                GameObject Single = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
                UnEquipmentNode node = Single.GetComponent<UnEquipmentNode>();
                node.index = i;
                node.tempList = temp;
                Single.transform.localScale = new Vector3(0.4f, 0.4f, 0.3f);
                node.transform.position = new Vector3(100f, 540f - 150f * i, 0f);
                node.ui.SetActive(true);
                node.setHero(hero);
                temp.Add(Single);
                node.Set(list[i]);
            }
        }
        hasClick = !hasClick;
    }


    public void Unequip()
    {   
        if(equipment == null || !equipment.isUsed)
        {
            ui.SetActive(false);
            GameObject tempG;
            SingleEquipment tempS;
            tempG = GameObject.Find("/EquipmentUI/Equipments/Helmet");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Armor");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Pants");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Shoes");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Gloves");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Weapon");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            return;
        }
        if (equipment.isUsed)
        {
            equipment.Unequip(equipment.hero);
            equipment.isUsed = false;
            if (equipment.EquipmentType == EquipmentType.Helmet)
            {
                GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Helmet");
                SingleEquipment t = temp.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if(equipment.EquipmentType == EquipmentType.Armor)
            {
                GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Armor");
                SingleEquipment t = temp.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if (equipment.EquipmentType == EquipmentType.Gloves)
            {
                GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Gloves");
                SingleEquipment t = temp.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if (equipment.EquipmentType == EquipmentType.Pants)
            {
                GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Pants");
                SingleEquipment t = temp.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if (equipment.EquipmentType == EquipmentType.Shoes)
            {
                GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Shoes");
                SingleEquipment t = temp.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else
            {
                GameObject temp = GameObject.Find("/EquipmentUI/Equipments/Weapon");
                SingleEquipment t = temp.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            set(null, equipment.EquipmentType);
            ui.SetActive(false);
            GameObject tempG;
            SingleEquipment tempS;
            tempG = GameObject.Find("/EquipmentUI/Equipments/Helmet");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Armor");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Pants");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Shoes");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Gloves");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
            tempG = GameObject.Find("/EquipmentUI/Equipments/Weapon");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.ui.SetActive(true);
        }

    }

    public void set(Equipment e,EquipmentType type)
    {   
        if(e == null)
        {
            //image;
            equipment = null;
            forNull = type;
            euipmentName.text = "name:none";
            value.text = "value:none";
            ATK.text = "ATK:none";
            ATKPercent.text = "ATKPercent:none";
            CritPercent.text = "CritPercent:none";
            typeName.text = "type:none";
        }
        else
        {
            forNull = e.EquipmentType;
            image = e.image;
            equipment = e;
            euipmentName.text = "name:"+equipment.ename;
            value.text = "value:"+equipment.value.ToString();
            ATK.text = "ATK:"+equipment.ATK.ToString();
            ATKPercent.text = "ATKPercent:"+equipment.ATKPercent.ToString();
            CritPercent.text = "CritPercent:"+equipment.CritPercent.ToString();
            typeName.text = "type:" + forNull.ToString();
        }
        ui.SetActive(true);
    }

    public void close()
    {
        for (int i = 0; i < temp.Count; i++)
        {
            Destroy(temp[i]);
        }
        temp = new List<GameObject>();
        ui.SetActive(false);
        GameObject tempG;
        SingleEquipment tempS;
        tempG = GameObject.Find("/EquipmentUI/Equipments/Helmet");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        tempG = GameObject.Find("/EquipmentUI/Equipments/Armor");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        tempG = GameObject.Find("/EquipmentUI/Equipments/Pants");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        tempG = GameObject.Find("/EquipmentUI/Equipments/Shoes");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        tempG = GameObject.Find("/EquipmentUI/Equipments/Gloves");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        tempG = GameObject.Find("/EquipmentUI/Equipments/Weapon");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(true);
        if(equipment.EquipmentType == EquipmentType.Helmet)
        {
            tempG = GameObject.Find("/EquipmentUI/Equipments/Helmet");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.setEquipment(equipment);
        }
        else if (equipment.EquipmentType == EquipmentType.Armor)
        {
            tempG = GameObject.Find("/EquipmentUI/Equipments/Armor");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.setEquipment(equipment);
        }
        else if (equipment.EquipmentType == EquipmentType.Gloves)
        {
            tempG = GameObject.Find("/EquipmentUI/Equipments/Gloves");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.setEquipment(equipment);
        }
        else if (equipment.EquipmentType == EquipmentType.Pants)
        {
            tempG = GameObject.Find("/EquipmentUI/Equipments/Pants");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.setEquipment(equipment);
        }
        else if (equipment.EquipmentType == EquipmentType.Shoes)
        {
            tempG = GameObject.Find("/EquipmentUI/Equipments/Shoes");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.setEquipment(equipment);
        }
        tempG = GameObject.Find("/EquipmentUI/Equipments/Weapon");
        tempS = tempG.GetComponent<SingleEquipment>();
        tempS.setEquipment(equipment);
    }
}
