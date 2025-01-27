using UnityEngine;

public class Player : Character
{
    private PlayerInput _input;

    private void OnEnable()
    {
        _input = InputManager.Instance.Input;

        _input.Player.Attack.performed += _ => Attack();
    }

    private void OnDisable()
    {
        _input.Player.Attack.performed -= _ => Attack();
    }
}
