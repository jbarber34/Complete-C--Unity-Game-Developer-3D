using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // NEW INPUT SYSTEM //
    // [SerializeField] InputAction movement;
    // [SerializeField] InputAction fire;
    // NEW INPUT SYSTEM //

    // Start is called before the first frame update
    void Start()
    {

    }

    // NEW INPUT SYSTEM //
    // void OnEnable()
    // {
    //     movement.Enable();
    // }

    // void OnDisable()
    // {
    //     movement.Disable();
    // }
    // NEW INPUT SYSTEM //

    // Update is called once per frame
    void Update()
    {
        // Old Unity Input System //
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        // Old Unity Input System //

        // New Unity Input System //
        // float xThrow = movement.ReadValue<Vector2>().x;
        // float yThrow = movement.ReadValue<Vector2>().y;
        // New Unity Input System //
    }
}
