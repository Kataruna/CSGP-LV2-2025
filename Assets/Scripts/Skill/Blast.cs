using Unity.VisualScripting;
using UnityEngine;

public class Blast : Skill
{
    public float _targetSize = 5f;

    public override void Use()
    {
        if(Physics.SphereCast(transform.position, _targetSize, transform.forward, out RaycastHit hit, _distance, _targetLayers))
        {
            if(hit.collider.TryGetComponent<Character>(out Character target))
            {
                target.TakeDamage((int)_power);
            }
        }

        base.Use();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward*_distance);
        Gizmos.DrawWireSphere(transform.position + (transform.forward * _distance), _targetSize);
    }
}
