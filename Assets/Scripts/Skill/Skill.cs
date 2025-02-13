using NaughtyAttributes;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public TypeOfSkill _skillType;

    public ParticleSystem _particle;

    public float _distance;
    public float _power;
    public float _cooldownDuration;
    
    [ShowIf("_skillType", TypeOfSkill.MultipleTarget)]
    public float _fieldOfEffect;

    public LayerMask _targetLayers;

    protected float _cooldownTimer;

    [Button("Use Skill")]
    public virtual void Use()
    {
        _cooldownTimer = _cooldownDuration;
        if(_particle != null) _particle.Play();
    }

    public virtual void Update()
    {
        if(_cooldownTimer <= 0) return;

        _cooldownTimer -= Time.deltaTime;
    }
}

public enum TypeOfSkill
{
    SingleTarget, // เป้าหมายเดียว
    MultipleTarget, // ยิงเป็น Cone
    AreaOfEffect
}
