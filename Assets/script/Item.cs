using UnityEngine;



[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public Sprite image;
    public int hpGiven;
    public int speedGive;
    public float speedDuration;
    public int price;

}
