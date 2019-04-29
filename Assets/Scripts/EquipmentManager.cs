using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    private Dictionary<EquipmentType, List<Equipment>> unEquipped;
    private Dictionary<BaseHero, List<Equipment>> Equipped;
    public UnEquipmentNode nodeUI;
    public HasEquipmentNode nodeUI1;
    public EquipmentUI equipmentUI;
    public string hero;
    public int ElimatedEnermy;
    public GameObject cubeF;
    private int levelCount;
    private double factor = 0.5;
    private EquipGenerator generator;
    private Vector3 fixedPosition;

    void Awake()
    {
        if (instance != null)
        {
            if (nodeUI != null)
            {
                nodeUI.ui.SetActive(false);
            }
            else if (nodeUI1 != null)
            {
                nodeUI1.ui.SetActive(false);
                nodeUI1.hero = CommonConfig.Knight;
                equipmentUI.ui.SetActive(true);
            }
            return;
        }
        instance = this;

        generator = new EquipGenerator();

        if (nodeUI != null)
        {
            nodeUI.ui.SetActive(false);
        }
        else if (nodeUI1 != null)
        {
            nodeUI1.ui.SetActive(false);
            nodeUI1.hero = CommonConfig.Knight;
            equipmentUI.ui.SetActive(true);
        }
        levelCount = 0;
        factor = 0.5;
        this.hero = null;
        if (GameObject.Find("/CheckResult") != null)
        {
            CalculateAfterGame();
            return;
        }
    }

    public void ShowEquipped(string hero)
    {
        equipmentUI.GetHeroEquiments(hero);
    }


    public List<Equipment> getHeroEquipment(string hero)
    {
        if (!EquipmentStorage.getEquippped().ContainsKey(hero))
        {
            EquipmentStorage.getEquippped()[hero] = new List<Equipment>();
            Logger.Log(111);
        }
        return EquipmentStorage.getEquippped()[hero];
    }

    public List<Equipment> getUnequippedEquipment(EquipmentType type)
    {
        return EquipmentStorage.getUnEquippped()[type];
    }

    public void selectEquippedEuipment(Equipment p, EquipmentType type)
    {
        nodeUI1.ui.SetActive(true);
        nodeUI1.set(p,type);
    }

    public void selectEquippedEuipment(EquipmentType type)
    {
        nodeUI1.ui.SetActive(true);
        nodeUI1.set(null, type);
    }

    public void selectUnEquippedEuipment(Equipment p)
    {
        nodeUI.ui.SetActive(true);
        nodeUI.Set(p);
    }


    public void CalculateAfterGame()
    {
        Transform tempG;
        levelCount = 1;
       //int numEquipment = 7;
        int numEquipment = (int)((levelCount*2+5) * factor * Random.Range(0.7f,1.0f));
        List <Equipment> list = new List<Equipment>();
        for (int i = 0; i < numEquipment; i++)
        {
            EquipmentType k = (EquipmentType)Random.Range(0, 6);
            Equipment newEquipment;
            if (k == EquipmentType.Armor)
            {
                newEquipment = generator.GenerateArmor(levelCount);
                list.Add(newEquipment);
            }
            else if (k == EquipmentType.Helmet)
            {   
                newEquipment = generator.GenerateHelmet(levelCount);
                list.Add(newEquipment);
            }
            else if (k == EquipmentType.Pants)
            {   
                newEquipment = generator.GeneratePants(levelCount);
                list.Add(newEquipment);
            }
            else if (k == EquipmentType.Shoes)
            {
                newEquipment = generator.GenerateShoes(levelCount);
                list.Add(newEquipment);
            }
            else if (k == EquipmentType.Gloves)
            {
               newEquipment = generator.GenerateGloves(levelCount);
                list.Add(newEquipment);
            }
            else
            {
                newEquipment = generator.GenerateWeapon(levelCount);
                list.Add(newEquipment);
            }
            EquipmentStorage.getUnEquippped()[newEquipment.EquipmentType].Add(newEquipment);
            //unEquipped[k].Add(newEquipment);
            Logger.Log(k);
            Logger.Log(EquipmentStorage.getUnEquippped()[k].Count);
        }

        for(int i = 0;i < numEquipment; i++)
        {
            tempG = GameObject.Find("CheckResult").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0);
            GameObject temp1 = (GameObject)Instantiate(cubeF, transform.position, transform.rotation);
            UnEquipmentNode newEquipment = temp1.GetComponent<UnEquipmentNode>();
            temp1.transform.SetParent(tempG.transform);
            temp1.transform.localScale = new Vector3(1.0f, 1.0f, 0.3f);
            if (i % 2 == 0)
            {
                newEquipment.transform.position = new Vector3(300, -170 - 1000 * (i / 2), 0f);
            }
            else
            {
                newEquipment.transform.position = new Vector3(300 + 600, -170 - 1000 * (i / 2), 0f);
            }
            newEquipment.Set(list[i]);
        }
    }          
}
