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
    public NonEquipmentUI nonequipmentUI;
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
                nonequipmentUI.ui.SetActive(true);
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
        //Object.DontDestroyOnLoad(instance);
        /*if (GameObject.Find("/CheckResult") != null)
        {
            CalculateAfterGame();
            return;
        }*/
      /*  fixedPosition = new Vector3(150f, 323f, 0f);
        if(knight != null)
        {
            knight.transform.position = fixedPosition;
        }
        else
        {
            knight = new Knight();
            iceMage = new IceMage();
            fireMage = new FireMage();
            archer = new Archer();
            priest = new Priest();
            EquipmentStorage.getEquippped()[knight] = new List<Equipment>();
            EquipmentStorage.getEquippped()[iceMage] = new List<Equipment>();
            EquipmentStorage.getEquippped()[fireMage] = new List<Equipment>();
            EquipmentStorage.getEquippped()[archer] = new List<Equipment>();
            EquipmentStorage.getEquippped()[priest] = new List<Equipment>();
        }*/
        generator = new EquipGenerator();

        /*unEquipped[EquipmentType.Sword] = new List<Equipment>();
        unEquipped[EquipmentType.Shield] = new List<Equipment>();
        unEquipped[EquipmentType.Staff] = new List<Equipment>();
        unEquipped[EquipmentType.Bow] = new List<Equipment>();
        unEquipped[EquipmentType.Helmet] = new List<Equipment>();
        unEquipped[EquipmentType.Armor] = new List<Equipment>();
        unEquipped[EquipmentType.Gloves] = new List<Equipment>();
        unEquipped[EquipmentType.Pants] = new List<Equipment>();
        unEquipped[EquipmentType.Shoes] = new List<Equipment>();*/
        if (nodeUI != null)
        {
            nodeUI.ui.SetActive(false);
            nonequipmentUI.ui.SetActive(true);
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
        }
        return EquipmentStorage.getEquippped()[hero];
        //return Equipped[hero];
    }

    public List<Equipment> getUnequippedEquipment(EquipmentType type)
    {
        return EquipmentStorage.getUnEquippped()[type];
        //return unEquipped[type];
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

   /* private void addEquipment(List<Equipment> equipments)
    {
        for (int i = 0; i < equipments.Count; i++)
        {
            unEquipped[equipments[i].EquipmentType].Add(equipments[i]);
        }
    }*/

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
            Debug.Log(k);
            Debug.Log(EquipmentStorage.getUnEquippped()[k].Count);
        }
        //addEquipment(list);
       // Destroy(tempG);
        for(int i = 0;i < numEquipment; i++)
        {
            tempG = GameObject.Find("CheckResult").transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0);
            GameObject temp1 = (GameObject)Instantiate(cubeF, transform.position, transform.rotation);
            UnEquipmentNode newEquipment = temp1.GetComponent<UnEquipmentNode>();
            temp1.transform.SetParent(tempG.transform);
            temp1.transform.localScale = new Vector3(0.5f, 0.5f, 0.3f);
            if (i % 2 == 0)
            {
                newEquipment.transform.position = new Vector3(231, -50 - 170 * (i / 2), 0f);
            }
            else
            {
                newEquipment.transform.position = new Vector3(231 + 400, -50 - 170 * (i / 2), 0f);
            }
            newEquipment.Set(list[i]);
        }
    }          
}
