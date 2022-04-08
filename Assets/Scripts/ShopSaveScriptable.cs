using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{ 
    [CreateAssetMenu(fileName ="ShopData",menuName ="Scriptable/Create ShopData")]
public class ShopSaveScriptable : ScriptableObject
{
        public ShopItem[] shopItems;
}
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public bool isUnlocked;
        public int unlockCost;
        public int unlockedLevel;
        public CarInfo[] carLevel;    
    }

    [System.Serializable]
    public class CarInfo
   {
        public int unlockCost;
        public int speed;
        public int accelaration;
        
   }

}