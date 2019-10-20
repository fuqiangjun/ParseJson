using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class ShowData : MonoBehaviour
{
    ParseItemJson  parseItemJson ;
    public dictionaryOfStringAndWeapon weaponDic;
    public  DictionaryOfStringAndEquipment equipmentDic;
    public  DictionaryOfStringAndConsumable consumableDic;


    private void Start()
    {
        ParseAllJsonFile();
    }


    public void ParseAllJsonFile()
    {
        parseItemJson = new ParseItemJson();
        weaponDic = parseItemJson.ParseItem_Weapon();
        equipmentDic = parseItemJson.ParseItem_Equipment();
        consumableDic = parseItemJson.parseItem_Consumable();
    }


    public  Item GetItemByName (string name )
    {
        return parseItemJson.GetItemByName(name);
    }
}
