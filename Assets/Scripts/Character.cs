using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes; // Add this one

public class Character : MonoBehaviour
{
    public int _maxHealth;
    public float _movementSpeed;
    public int _atk;

    public List<Character> enemies = new List<Character>();

    public Skill[] _skills;

    [ShowNonSerializedField]
    protected int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Debug.Log($"{gameObject.name} Take Damage");
        _health -= damage;
    }

    protected void Attack()
    {
        // TODO: Insert Attack Logic here
        foreach (Character character in enemies)
        {
            if (character != this)
            {
                character.TakeDamage(_atk);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character thatGuy))
        {
            enemies.Add(thatGuy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Character>(out Character thatGuy))
        {
            if (enemies.Contains(thatGuy))
            {
                enemies.Remove(thatGuy);
            }
        }
    }
}
