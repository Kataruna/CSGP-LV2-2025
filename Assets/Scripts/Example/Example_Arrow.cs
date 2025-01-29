using UnityEngine;

/// <summary>
/// This class served as logic for arrow.
/// Mainly for its rotating physics
/// 
/// But it might served as damage in future work
/// </summary>
public class Example_Arrow : MonoBehaviour
{
    public Rigidbody _rb;

    void Update()
    {
        if (_rb.linearVelocity.sqrMagnitude > 0.01f) // Avoid division by zero
        {
            transform.rotation = Quaternion.LookRotation(_rb.linearVelocity);
        }
    }
}
