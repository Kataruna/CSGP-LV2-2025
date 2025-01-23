using UnityEngine;

public class Character : MonoBehaviour
{
    public void TakeDamage()
    {
        Debug.Log($"{gameObject.name} Take Damage");
    }
}
