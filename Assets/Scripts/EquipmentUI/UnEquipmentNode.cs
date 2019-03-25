using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnEquipmentNode : MonoBehaviour
{
    private Equipment equipment;
    public GameObject ui;
    public Text euipmentName;
    public Text value;
    public Text ATK;
    public Text ATKPercent;
    public Text CritPercent;
    public Text Type;
    public Image image;
    private BaseHero hero;
    public int index;
    public List<GameObject> tempList;

    void Start()
    {
        ui.SetActive(true);
    }

    public void equip()
    {
        GameObject cubeF = GameObject.Find("HasEquipmentNode");
        HasEquipmentNode t = cubeF.GetComponent<HasEquipmentNode>();
        if (cubeF == null) return;
        Equipment temp = t.equipment;
        equipment.Equip(hero);
        t.set(equipment, equipment.EquipmentType);
        if(temp == null)
        {
            Destroy(tempList[index]);
            tempList.Remove(tempList[index]);
        }
        Set(temp);
    }

    public void sell()
    {
        //PlayerStats.Money += equipment.value;
        equipment.Destroy();
        ui.SetActive(false);
    }

    public void Close()
    {
        ui.SetActive(false);
        EquipmentManager.instance.nodeUI = null;
    }

    public void Set(Equipment p)
    {   
        if(p == null)
        {   
            return;
        }
        ui.SetActive(true);
        equipment = p;
        Type.text = "type:"+equipment.EquipmentType.ToString();
        euipmentName.text = "name:"+equipment.ename;
        value.text = "value:"+equipment.value.ToString();
        ATK.text = "ATK:"+equipment.ATK.ToString();
        ATKPercent.text = "ATKPercent:"+equipment.ATKPercent.ToString();
        CritPercent.text = "CritPercent:" + equipment.CritPercent.ToString();
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void setHero(BaseHero h)
    {
        hero = h;
    }
}
