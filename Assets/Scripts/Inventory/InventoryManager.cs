using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public InventorySlot[] _inventorySlots;
    public InventoryItem _uiItemPrefab;

    private int _slotQuantity;

    void Start()
    {
        _slotQuantity = _inventorySlots.Length;
    }

    public bool AddItem(ItemSO item)
    {
        for (int i = 0; i < _slotQuantity; i++)
        {
            InventoryItem itemInSlot = _inventorySlots[i].GetComponentInChildren<InventoryItem>();

            if (itemInSlot != null &&
                itemInSlot._item == item &&
                itemInSlot._item.IsStackable == true &&
                itemInSlot.count < itemInSlot._item.maxStack)
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true;
                }
        }

        for (int i = 0; i < _slotQuantity; i++)
        {
            InventoryItem itemInSlot = _inventorySlots[i].GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, _inventorySlots[i]);
                return true;
            }
        }

        return false;
    }

    private void SpawnNewItem(ItemSO item, InventorySlot slot){
        InventoryItem itemInSlot = Instantiate(_uiItemPrefab, slot.transform);
        itemInSlot.Setup(item);
    }

    [Space(10)]
    [SerializeField] private int DebugQuantity;
    [SerializeField] private ItemSO DebugItem;

    [ContextMenu("Add Debug Item")]
    void AddDebugItem()
    {
        for (int i = 0; i < DebugQuantity; i++)
        {
            AddItem(DebugItem);
        }
    }
}
