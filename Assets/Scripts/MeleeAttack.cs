using UnityEngine;

using System.Collections.Generic; // Add this one

public class MeleeAttack : MonoBehaviour
{
    public List<Character> enemies = new List<Character>();

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

    private void Attack()
    {
        // TODO: Insert Attack Logic here
        foreach (Character character in enemies)
        {
            character.TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Character>(out Character thatGuy))
        {
            enemies.Add(thatGuy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Character>(out Character thatGuy))
        {
            if(enemies.Contains(thatGuy))
            {
                enemies.Remove(thatGuy);
            }
        }
    }
}
