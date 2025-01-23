using UnityEngine;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    #region Simple Singleton
    public static InputManager Instance;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //-----
        Input = new PlayerInput();
    }
    #endregion

    public PlayerInput Input;

    private void OnEnable(){
        Input.Enable();
    }

    private void OnDisable()
    {
        Input.Disable();
    }
}
