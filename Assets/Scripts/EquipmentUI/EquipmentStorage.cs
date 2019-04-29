using System;
using System.Collections.Generic;

public static class EquipmentStorage
{
    private static Dictionary<EquipmentType, List<Equipment>> unEquipped = new Dictionary<EquipmentType, List<Equipment>>();
    private static Dictionary<string, List<Equipment>> Equipped = new Dictionary<string, List<Equipment>>();
    public static bool hasNeverUsed = false;
    public static List<string> Armor = new List<string>();
    public static List<string> Helmet = new List<string>();
    public static List<string> Pants = new List<string>();
    public static List<string> Gloves = new List<string>();
    public static List<string> Boot = new List<string>();
    public static List<string> Sword = new List<string>();
    public static List<string> Shield = new List<string>();
    public static List<string> Bow = new List<string>();
    public static List<string> Staves = new List<string>();

    static EquipmentStorage(){
        unEquipped[EquipmentType.Armor] = new List<Equipment>();
        unEquipped[EquipmentType.Sword] = new List<Equipment>();
        unEquipped[EquipmentType.Shoes] = new List<Equipment>();
        unEquipped[EquipmentType.Gloves] = new List<Equipment>();
        unEquipped[EquipmentType.Pants] = new List<Equipment>();
        unEquipped[EquipmentType.Bow] = new List<Equipment>();
        unEquipped[EquipmentType.Helmet] = new List<Equipment>();
        unEquipped[EquipmentType.Shield] = new List<Equipment>();
        unEquipped[EquipmentType.Staff] = new List<Equipment>();
        Equipped[CommonConfig.Knight] = new List<Equipment>();
        Equipped[CommonConfig.Archer] = new List<Equipment>();
        Equipped[CommonConfig.IceMage] = new List<Equipment>();
        Equipped[CommonConfig.FireMage] = new List<Equipment>();
        Equipped[CommonConfig.Priest] = new List<Equipment>();
        Boot.Add("Fire Walkers");
        Boot.Add("Greaves");
        Boot.Add("Heavy Boots");
        Boot.Add("Heavy Sabatons");
        Boot.Add("Illusory Boots");
        Boot.Add("Lost Boys");
        Boot.Add("Lut Socks");
        Boot.Add("Sabatons");
        Boot.Add("The Crudest Boots");
        Armor.Add("armor of the sun");
        Armor.Add("Chaingmail");
        Armor.Add("Goldskin");
        Armor.Add("Leather Doublet");
        Armor.Add("Rakkisgard Armor");
        Armor.Add("Robes of the Rydraelm");
        Armor.Add("Shi Mizu's Haori");
        Armor.Add("Splint Cuirass");
        Armor.Add("Tyrael's Might");
        Gloves.Add("iron bracelets");
        Gloves.Add("Magefist");
        Gloves.Add("Battle Gauntlets");
        Gloves.Add("Chain Gloves");
        Gloves.Add("Pendergrasps");
        Gloves.Add("Plated Gauntlets");
        Gloves.Add("Sage's Grasp");
        Gloves.Add("Tasker and Theo");
        Pants.Add("iron leggings");
        Pants.Add("Ascended Faulds");
        Pants.Add("Boneweave Faulds");
        Pants.Add("Faulds");
        Pants.Add("Hammer Jammers");
        Pants.Add("Pox Faulds");
        Pants.Add("Swamp Land Waders");
        Pants.Add("Gehennas");
        Pants.Add("Sovereign Tassets");
        Helmet.Add("Cain's Laurel");
        Helmet.Add("Blind Faith");
        Helmet.Add("Ascended Crown");
        Helmet.Add("iron helm");
        Helmet.Add("Arming Cap");
        Helmet.Add("Sovereign Helm");
        Helmet.Add("Plated Helm");
        Shield.Add("Eberli Charo");
        Shield.Add("Lidless Wall");
        Shield.Add("Stormshield");
        Sword.Add("Deathwish");
        Sword.Add("Exarian");
        Sword.Add("Gift of Silaria");
        Sword.Add("Griswold's Masterpiece");
        Bow.Add("Wildwood");
        Bow.Add("Short Bow");
        Bow.Add("Uskang");
        Bow.Add("Windforce");
        Bow.Add("Twinbow");
        Staves.Add("sages crystal staff");
        Staves.Add("court sorcerers staff");
        Staves.Add("witchtree branch");
        Staves.Add("man grubs staff");
        Staves.Add("preacher's right arm");
    }

    public static void AddunEquipped(Equipment e) {
        unEquipped[e.EquipmentType].Add(e);
    }

    public static Dictionary<EquipmentType, List<Equipment>> getUnEquippped(){
        return unEquipped;
    }

    public static Dictionary<string, List<Equipment>> getEquippped(){
        return Equipped;
    }
}