using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ParseItemJson
{
    private  List<Weapon> weaponList = new List<Weapon> () ;
    private  dictionaryOfStringAndWeapon weaponDic  = new dictionaryOfStringAndWeapon () ;
    private List<Equipment> equipmentList = new List<Equipment>();
    private DictionaryOfStringAndEquipment equipmentDic = new DictionaryOfStringAndEquipment();
    private List<Consumable > consumableList = new List<Consumable>();
    private DictionaryOfStringAndConsumable consumableDic = new DictionaryOfStringAndConsumable();
    private string weaponJsonPath = Path.Combine ( Application.streamingAssetsPath , "Weapon.json");
    private string equipmentJsonPath = Path.Combine(Application.streamingAssetsPath , "Equipment.json");
    private string consumableJsonPath = Path.Combine(Application.streamingAssetsPath, "Consumable.json");


    public ParseItemJson()
    {

    }

    public Item GetItemByName(string _name)
    {
        if (weaponDic .ContainsKey (_name ))
        {
            return weaponDic[_name];
        }
        if (equipmentDic.ContainsKey(_name))
        {
            return equipmentDic[_name];
        }

        Debug.LogErrorFormat("不存在{0}该名字物品!", _name);
        return null;
    }


    public dictionaryOfStringAndWeapon ParseItem_Weapon()
    {
        //去内存读取 或 服务器读取
        //TextAsset t = Resources.Load<TextAsset>("Items4");
        //string itemsJson = t.text;
        string weaponJson = File.ReadAllText(weaponJsonPath);
        weaponList = JsonConvert.DeserializeObject<List<Weapon>>(weaponJson);

        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponDic.Add(weaponList[i].Name, weaponList[i]);
        }

        return weaponDic;
    }

    public DictionaryOfStringAndEquipment ParseItem_Equipment()
    {
        string str = File.ReadAllText(equipmentJsonPath);
        equipmentList = JsonConvert.DeserializeObject<List<Equipment>>(str);
        for (int i = 0; i < equipmentList.Count; i++)
        {
            equipmentDic.Add(equipmentList[i].Name, equipmentList[i]);
        }
        return equipmentDic;
    }

    public DictionaryOfStringAndConsumable parseItem_Consumable()
    {
        string str = File.ReadAllText(consumableJsonPath);
        consumableList = JsonConvert.DeserializeObject<List<Consumable>>(str);
        for (int i = 0; i < consumableList.Count; i++)
        {
            consumableDic .Add(consumableList[i].Name, consumableList[i]);
        }
        return consumableDic;
    }

}
