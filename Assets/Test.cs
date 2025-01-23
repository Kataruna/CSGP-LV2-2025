using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    // Update is called once per frame
    void Update()
    {
        if (_rb.linearVelocity.magnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(_rb.linearVelocity);
    }
}
