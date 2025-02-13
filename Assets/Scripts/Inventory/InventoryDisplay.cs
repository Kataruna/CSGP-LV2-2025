using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public StarterAssets.StarterAssetsInputs _starterInput;

    public CanvasGroup _canvasGroup;

    private PlayerInput _input;

    private bool _isOpened = false;

    private void OnEnable()
    {
        _input = InputManager.Instance.Input;

        _input.Player.Inventory.performed += _ => ToggleDisplay();
    }

    private void OnDisable()
    {
        _input.Player.Inventory.performed -= _ => ToggleDisplay();
    }

    private void Awake()
    {
        _isOpened = false;

        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;
    }

    private void ToggleDisplay()
    {
        _isOpened = !_isOpened;

        if (_isOpened)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
