using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image _itemIcon;
    public TMP_Text _quantityText;

    public ItemSO _item;
    public Transform parentAfterDrag;

    public int count = 1;

    public void ChangeDisplayIcon(ItemSO newItem)
    {
        _itemIcon.sprite = newItem.ItemIcon;
    }

    public void Setup(ItemSO newItem)
    {
        _item = newItem;
        ChangeDisplayIcon(newItem);

        RefreshCount();
    }

    public void RefreshCount()
    {
        _quantityText.text = count.ToString();

        _quantityText.gameObject.SetActive(count > 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _itemIcon.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _itemIcon.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
