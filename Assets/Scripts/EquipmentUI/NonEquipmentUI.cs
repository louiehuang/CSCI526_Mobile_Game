using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class NonEquipmentUI : MonoBehaviour
{
    public List<Equipment> equipments;
    public GameObject ui;
    public GameObject temp;
    public GameObject prefab;
    private Vector3 UIvector;
    private List<GameObject> list;

    void Awake()
    { 
        ui.SetActive(true);
        UIvector = this.transform.position;
        list = new List<GameObject>();
    }

    public void ShowUnEquipped(EquipmentType type)
    {   
        for(int i = 0; i < list.Count; i++)
        {
            Destroy(list[i]);
        }
        if (temp == null)
        {
            temp = new GameObject();
            temp.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5.0f;
            temp.AddComponent<TextMesh>();
            var style = temp.GetComponent<TextMesh>();
            style.text = "You don't have equipments of this type.";
            style.anchor = TextAnchor.MiddleCenter;
            style.fontSize = 8;
            style.color = Color.black;
        }
        temp.SetActive(false);
        equipments = EquipmentManager.instance.getUnequippedEquipment(type);
        if(equipments == null || equipments.Count == 0)
        {
            temp.SetActive(true);
            ui.SetActive(true);
            return;
        }

        int r = 0;
        int c = 0;
        for (int i = 0; i < equipments.Count; i++)
        {
            GameObject singleEuipmentGo = (GameObject)Instantiate(prefab, transform.position, transform.rotation);
            SingleEquipment single = singleEuipmentGo.GetComponent<SingleEquipment>();
            list.Add(singleEuipmentGo);
            single.setEquipment(equipments[i]);
            if (i % 5 == 0)
            {
                r++;
                c = 0;
                single.transform.position = new Vector3(UIvector.x-200, UIvector.y+200 - 150 * r, UIvector.z);
                Debug.Log(UIvector.y + single.transform.localPosition.y * c);
            }
            else
            {
                c++;
                single.transform.position = new Vector3(UIvector.x-200 + 100 * c, UIvector.y+200 - 150 * r, UIvector.z);
            }
        }
        ui.SetActive(true);
    }


    public void ShowUnEquippedSword()
    {
       ShowUnEquipped(EquipmentType.Sword);
    }

    public void ShowUnEquippedShield()
    {
        ShowUnEquipped(EquipmentType.Shield);
    }

    public void ShowUnEquippedStaff()
    {
        ShowUnEquipped(EquipmentType.Staff);
    }

    public void ShowUnEquippedBow()
    {
        ShowUnEquipped(EquipmentType.Bow);
    }

    public void ShowUnEquippedHelmet()
    {
        ShowUnEquipped(EquipmentType.Helmet);
    }

    public void ShowUnEquippedGloves()
    {
        ShowUnEquipped(EquipmentType.Gloves);
    }

    public void ShowUnEquippedArmor()
    {
        ShowUnEquipped(EquipmentType.Armor);
    }

    public void ShowUnEquippedPants()
    {
        ShowUnEquipped(EquipmentType.Pants);
    }

    public void ShowUnEquippedShoes()
    {
        ShowUnEquipped(EquipmentType.Shoes);
    }

    public void hide()
    {
        ui.SetActive(false);
    }

    public void close()
    {
        ui.SetActive(false);
    }

}
