using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class HasEquipmentNode : MonoBehaviour
{
    public GameObject ui;
    public Equipment equipment;
    public Text euipmentName;
    public Text TypeName;
    public Text value;
    public Text PDEF;
    public Text MDEF;
    public Text FirstAttribute;
    public Text SecondAttribute;
    public Image image;
    public EquipmentType forNull;
    public List<GameObject> temp;
    private bool hasClick;
    public GameObject prefab;
    public string hero;
    private Vector3 prev;
    private Vector3 cur;
    GameObject scroller;
    ScrollViewManager manager;

    private string NoneString = "Blank";

    private void Awake()
    {
        prev = new Vector3(-1000f, -1000f, -1000f);
        cur = new Vector3(120f, 470f, 0f);
        hasClick = false;
        ui.SetActive(false);
        scroller = GameObject.Find("Canvas/UnEquipments");
        if (scroller != null)
        {
            manager = scroller.GetComponent<ScrollViewManager>();
            manager.ui.SetActive(false);
            scroller.transform.position = prev;
        }
    }

    public void change()
    {
        if (hasClick == true)
        {
            manager.ui.SetActive(false);
            for(int i = 0; i < temp.Count; i++)
            {
                Destroy(temp[i]);
            }
            temp = new List<GameObject>();
            addHero();
        }
        else
        {   
            if(scroller.transform.position == prev)
            {
                scroller.transform.position = cur;
            }
            else
            {
                manager.ui.SetActive(true);
            }
            List<Equipment> list;
            if (equipment == null)
            {   
                if(forNull == EquipmentType.Sword || forNull == EquipmentType.Shield)
                {
                    list = EquipmentManager.instance.getUnequippedEquipment(forNull);
                    foreach(Equipment e1 in EquipmentManager.instance.getUnequippedEquipment(EquipmentType.Shield))
                    {
                        list.Add(e1);
                    }
                }
                else
                {
                    list = EquipmentManager.instance.getUnequippedEquipment(forNull);
                    Debug.Log(list.Count);
                }
            }
            else
            {
                list = EquipmentManager.instance.getUnequippedEquipment(equipment.EquipmentType);
            }
            manager.ui.SetActive(true);
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
                Single.transform.SetParent(manager.transform.GetChild(0).GetChild(0));
            }
            removeHero();
        }
        hasClick = !hasClick;
    }


    public void Unequip()
    {
        hasClick = false;
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
            for(int i = 0; i < temp.Count; i++)
            {
                Destroy(temp[i]);
            }
            temp = new List<GameObject>();
            manager.ui.SetActive(false);
            addHero();
            return;
        }
        if (equipment.isUsed)
        {
            equipment.RemoveEquipmentFromHero(equipment.hero);
            equipment.isUsed = false;
            if (equipment.EquipmentType == EquipmentType.Helmet)
            {
                GameObject tt = GameObject.Find("/EquipmentUI/Equipments/Helmet");
                SingleEquipment t = tt.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if(equipment.EquipmentType == EquipmentType.Armor)
            {
                GameObject tt = GameObject.Find("/EquipmentUI/Equipments/Armor");
                SingleEquipment t = tt.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if (equipment.EquipmentType == EquipmentType.Gloves)
            {
                GameObject tt = GameObject.Find("/EquipmentUI/Equipments/Gloves");
                SingleEquipment t = tt.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if (equipment.EquipmentType == EquipmentType.Pants)
            {
                GameObject tt = GameObject.Find("/EquipmentUI/Equipments/Pants");
                SingleEquipment t = tt.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else if (equipment.EquipmentType == EquipmentType.Shoes)
            {
                GameObject tt = GameObject.Find("/EquipmentUI/Equipments/Shoes");
                SingleEquipment t = tt.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            else
            {
                GameObject tt = GameObject.Find("/EquipmentUI/Equipments/Weapon");
                SingleEquipment t = tt.GetComponent<SingleEquipment>();
                t.setEquipment(null);
            }
            if(temp == null || temp.Count == 0)
            {
                List<Equipment> list;
                if (equipment == null)
                {
                    if (forNull == EquipmentType.Sword || forNull == EquipmentType.Shield)
                    {
                        list = EquipmentManager.instance.getUnequippedEquipment(forNull);
                        foreach (Equipment e1 in EquipmentManager.instance.getUnequippedEquipment(EquipmentType.Shield))
                        {
                            list.Add(e1);
                        }
                    }
                    else
                    {
                        list = EquipmentManager.instance.getUnequippedEquipment(forNull);
                        Debug.Log(list.Count);
                    }
                }
                else
                {
                    list = EquipmentManager.instance.getUnequippedEquipment(equipment.EquipmentType);
                }
                manager.ui.SetActive(true);
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
                    Single.transform.SetParent(manager.transform.GetChild(0).GetChild(0));
                }
                manager.ui.SetActive(true);
                set(null, equipment.EquipmentType);
            }
            else
            {
                manager.ui.SetActive(true);
                GameObject temp1 = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
                UnEquipmentNode unNode = temp1.GetComponent<UnEquipmentNode>();
                unNode.setHero(hero);
                unNode.index = temp.Count;
                unNode.tempList = temp;
                unNode.Set(equipment);
                set(null, equipment.EquipmentType);
                Vector3 v = temp[temp.Count - 1].transform.position;
                temp1.transform.position = new Vector3(100f, v.y - 150f, 0f);
               // temp1.transform.position = new Vector3(100f, 540f - (temp.Count - 1) * 150f, 0f);
                temp1.transform.localScale = new Vector3(0.5f, 0.5f, 0.3f);
                temp1.transform.SetParent(manager.transform.GetChild(0).GetChild(0));
                temp.Add(temp1);
            }
            /*manager.ui.SetActive(true);
              GameObject temp1 = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
              UnEquipmentNode unNode = temp1.GetComponent<UnEquipmentNode>();
              unNode.setHero(hero);
              unNode.index = temp.Count;
              unNode.tempList = temp;
              unNode.Set(equipment);
              set(null, equipment.EquipmentType);
              temp.Add(temp1);
              Debug.Log(temp.Count);
              temp1.transform.position = new Vector3(100f, 540f - (temp.Count - 1) * 150f, 0f);
              temp1.transform.localScale = new Vector3(0.4f, 0.4f, 0.3f);
              temp1.transform.SetParent(manager.transform.GetChild(0).GetChild(0));
            set(null, equipment.EquipmentType);*/
            removeHero();
        }

    }

    public void set(Equipment e,EquipmentType type)
    {   
        if(e == null)
        {
            //image;
            equipment = null;
            forNull = type;
            showText(null, type);
            image.sprite = setSprite(NoneString);
        }
        else
        {
            forNull = e.EquipmentType;
            equipment = e;
            showText(e, type);
            image.sprite = setSprite(e.path);
        }
        ui.SetActive(true);
    }

    private void showText(Equipment e, EquipmentType type)
    {   
        if(e != null)
        {
            euipmentName.text = "name:"+e.ename;
            TypeName.text = "type:"+e.EquipmentType.ToString();
            value.text = "value:" + equipment.value.ToString();
            image.sprite = setSprite(e.path);
            if (type == EquipmentType.Helmet)
            {
                PDEF.text = "PDEF:"+ equipment.PDEF;
                MDEF.text = "MDEF:" + equipment.MDEF;
                FirstAttribute.text = "ACC:" + equipment.ACC;
                SecondAttribute.text = "Block:" + equipment.Block;
                TypeName.text = "Type:" + EquipmentType.Helmet.ToString();
            }

            else if(type == EquipmentType.Gloves)
            {
                PDEF.text = "PDEF:" + equipment.PDEF;
                MDEF.text = "MDEF:" + equipment.MDEF;
                TypeName.text = "Type:" + EquipmentType.Helmet.ToString();
                FirstAttribute.text = "Pernetration:" + equipment.Pernetration;
                SecondAttribute.text = "Crit:" + equipment.Crit;
            }

            else if(type == EquipmentType.Pants)
            {
                PDEF.text = "PDEF:" + equipment.PDEF;
                MDEF.text = "MDEF:" + equipment.MDEF;
                TypeName.text = "Type:" + EquipmentType.Pants.ToString();
                FirstAttribute.text = "HP:" + equipment.HP;
                SecondAttribute.text = "Crit:" + equipment.Crit;
            }

            else if(type == EquipmentType.Shoes)
            {
                PDEF.text = "PDEF:" + equipment.PDEF;
                MDEF.text = "MDEF:" + equipment.MDEF;
                TypeName.text = "Type:" + EquipmentType.Shoes.ToString();
                FirstAttribute.text = "ACC:" + equipment.ACC;
                SecondAttribute.text = "Dodge:" + equipment.Dodge;
            }

            else if(type == EquipmentType.Armor)
            {
                PDEF.text = "PDEF:" + equipment.PDEF;
                MDEF.text = "MDEF:" + equipment.MDEF;
                TypeName.text = "Type:" + EquipmentType.Armor.ToString();
                FirstAttribute.text = "Block:" + equipment.Block;
                SecondAttribute.text = "CritResistance:" + equipment.CritResistance;
            }

            else
            {
                PDEF.text = "ATK:" + equipment.PATK;
                MDEF.text = "MATK:" + equipment.MATK;
                TypeName.text = "Type:"+type.ToString();
                FirstAttribute.text = "Crit:" + equipment.Crit;
                SecondAttribute.text = "CritDMG:" + equipment.CritDMG;
            }
        }
        else
        {
            euipmentName.text = "name:none";
            TypeName.text = "type:none";
            value.text = "value:none";
            PDEF.text = "none";
            MDEF.text = "none";
            FirstAttribute.text = "none";
            SecondAttribute.text = "none";
        }
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
        addHero();
        manager.ui.SetActive(false);
        if (equipment == null)
        {
            hasClick = false;
            return;
        }

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
        else
        {
            tempG = GameObject.Find("/EquipmentUI/Equipments/Weapon");
            tempS = tempG.GetComponent<SingleEquipment>();
            tempS.setEquipment(equipment);
        }
        hasClick = false;
    }

    private void addHero()
    {
        if(hero == CommonConfig.Knight)
        {
            GameObject tt = GameObject.Find("Knight1");
            tt.transform.position = new Vector3(150f, 320f, 0f);
        }
        else if (hero == CommonConfig.Archer)
        {
            GameObject tt = GameObject.Find("Archer1");
            tt.transform.position = new Vector3(150f, 320f, 0f);
        }
        else if (hero == CommonConfig.IceMage)
        {
            GameObject tt = GameObject.Find("IceMage1");
            tt.transform.position = new Vector3(150f, 320f, 0f);
        }
        else if (hero == CommonConfig.FireMage)
        {
            GameObject tt = GameObject.Find("FireMage1");
            tt.transform.position = new Vector3(150f, 320f, 0f);
        }
        else
        {
            GameObject tt = GameObject.Find("Priest1");
            tt.transform.position = new Vector3(150f, 320f, 0f);
        }
    }

    private void removeHero()
    {
            GameObject tt = GameObject.Find("Knight1");
            tt.transform.position = new Vector3(-1000f, -1000f, 0f);
            tt = GameObject.Find("Archer1");
            tt.transform.position = new Vector3(-1000f, -1000f, 0f);
            tt = GameObject.Find("IceMage1");
            tt.transform.position = new Vector3(-1000f, -1000f, 0f);
            tt = GameObject.Find("FireMage1");
            tt.transform.position = new Vector3(-1000f, -1000f, 0f);
            tt = GameObject.Find("Priest1");
            tt.transform.position = new Vector3(-1000f, -1000f, 0f);
    }


    public Sprite setSprite(string text)
    {
        Texture2D aa = (Texture2D)Resources.Load(text) as Texture2D;
        Sprite kk = Sprite.Create(aa, new Rect(0, 0, aa.width, aa.height), new Vector2(0.5f, 0.5f));
        return kk;
    }
}
