using System;
using System.Collections.Generic;

public static class EquipmentStorage {
    private static Dictionary<EquipmentType, List<Equipment>> unEquipped = new Dictionary<EquipmentType, List<Equipment>>();
    private static Dictionary<BaseHero, List<Equipment>> Equipped = new Dictionary<BaseHero, List<Equipment>>();

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
    }

    public static void AddunEquipped(Equipment e) {
        unEquipped[e.EquipmentType].Add(e);
    }

    public static Dictionary<EquipmentType, List<Equipment>> getUnEquippped(){
        return unEquipped;
    }

    public static Dictionary<BaseHero, List<Equipment>> getEquippped(){
        return Equipped;
    }
}
