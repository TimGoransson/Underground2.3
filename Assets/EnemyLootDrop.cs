using UnityEngine;
using System.Collections;

public class EnemyLootDrop : MonoBehaviour {
    static ItemDataBaseList inventoryItemList;
    // Use this for initialization
    void Start ()
    {
        inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");

    }

    // Update is called once per frame
    void Update () {
	
	}
    public void DropLoot(Vector2 dropPoint, int whatItem)
    {
        GameObject lootItem = (GameObject)Instantiate(inventoryItemList.itemList[whatItem].itemModel, dropPoint, Quaternion.Euler(0,0,0));
        PickUpItem item = lootItem.AddComponent<PickUpItem>();
        item.item = inventoryItemList.itemList[whatItem];
        lootItem.transform.localPosition = dropPoint;
    }
}
