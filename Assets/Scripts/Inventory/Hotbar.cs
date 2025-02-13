using UnityEngine;
using UnityEngine.InputSystem;

public class Hotbar : MonoBehaviour
{
    public InventorySlot[] _slots;

    public Transform _itemHolder;

    private PlayerInput _input;

    private void OnEnable()
    {
        _input = InputManager.Instance.Input;

        _input.Hotbar.SelectedSlot.performed += OnHotbarSlotSelected;
    }

    private void OnDisable()
    {
        _input.Hotbar.SelectedSlot.performed -= OnHotbarSlotSelected;
    }

    private void OnHotbarSlotSelected(InputAction.CallbackContext context)
    {
        string keyPressed = context.control.name; // "1", "2", "3"

        if(int.TryParse(keyPressed, out int index))
        {
            PullOutItem(_slots[index-1]);
        }
    }

    private void PullOutItem(InventorySlot slot)
    {
        if(slot.transform.childCount == 0) return;

        if(_itemHolder.childCount != 0)
            Destroy(_itemHolder.GetChild(0));

        InventoryItem item =
        slot.GetComponentInChildren<InventoryItem>();

        if(item._item.ItemPrefab == null) return;

        Instantiate(item._item.ItemPrefab, _itemHolder);
    }
}
