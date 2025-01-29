using UnityEngine;

public class Example_Bow : MonoBehaviour
{
    public Rigidbody _arrowPrefab; // Arrow Prefab
    public Transform _arrowSpawnpoint; // Where to spawn Arrow

    public float _maxAimingTime = 3f; // How long it take to fully aim
    public float _baseForce = 15f; // Base force of arrow in case multiplier is 1x 
    public float _maximumMultiplier = 1.2f; // Maximum Force Multiplier

    private float _aimingTime; // Variable to track aiming time
    private bool _isAiming = false; // Variable to track if is aiming

    private PlayerInput _input; // Main Input module

    private void OnEnable()
    {
        _input = InputManager.Instance.Input;

        _input.Player.Aim.performed += _ => _isAiming = true;
        _input.Player.Aim.canceled += _ => Shoot();
    }

    private void OnDisable()
    {
        _input.Player.Aim.performed -= _ => _isAiming = true;
        _input.Player.Aim.canceled -= _ => Shoot();
    }

    private void Update()
    {
        if (_isAiming && _aimingTime < _maxAimingTime)
        {
            //While aiming, Count in aiming time
            _aimingTime += Time.deltaTime;
        }
        else if (_aimingTime > _maxAimingTime)
        {
            // set aiming time to percise number in case it's not
            _aimingTime = _maxAimingTime;
        }
    }

    private void Shoot()
    {
        _isAiming = false;

        float aimPercent = _aimingTime / _maxAimingTime;

        // Debug.Log($"aim Percent is {aimPercent}");

        Rigidbody arrow = Instantiate(_arrowPrefab, _arrowSpawnpoint.position, _arrowSpawnpoint.rotation);

        arrow.AddForce(
            (aimPercent * _maximumMultiplier * _baseForce) * arrow.transform.forward
            , ForceMode.Impulse
            );

        _aimingTime = 0f;
    }
}
