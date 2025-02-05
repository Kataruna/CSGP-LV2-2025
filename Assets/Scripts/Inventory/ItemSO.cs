using UnityEngine;

[CreateAssetMenu(menuName = "Object/Item")]
public class ItemSO : ScriptableObject
{
    public string ItemName;
    [TextArea(3, 10)] public string ItemDescription;
    public Sprite ItemIcon;

    public bool IsStackable = true;
    public int maxStack = 64;

    public ItemType Type;
}

public enum ItemType
{
    Comsumable,
    Armor,
    Item,
    Weapon
}