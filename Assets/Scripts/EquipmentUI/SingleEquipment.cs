using UnityEngine;
using UnityEngine.UI;

public class SingleEquipment : MonoBehaviour
{
    private Equipment equipment;
    public EquipmentType type;
    public Text ename;
    public GameObject ui;

    public void setEquipment(Equipment e)
    {
        equipment = e;
        if (e == null)
        {
            ename.text = "none";
        }
        else
        {
            ename.text = e.ename;
        }
    }

    public void detail()
    {   
        if(equipment == null)
        {
            EquipmentManager.instance.selectEquippedEuipment(type);
        }
        else if (equipment.isUsed == false)
        {
            EquipmentManager.instance.selectUnEquippedEuipment(equipment);
        }
        else
        {
            EquipmentManager.instance.selectEquippedEuipment(equipment,type);
        }
        GameObject temp;
        SingleEquipment tempS;
        temp = GameObject.Find("/EquipmentUI/Equipments/Helmet");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Armor");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Pants");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Shoes");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Gloves");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
        temp = GameObject.Find("/EquipmentUI/Equipments/Weapon");
        tempS = temp.GetComponent<SingleEquipment>();
        tempS.ui.SetActive(false);
    }
}
