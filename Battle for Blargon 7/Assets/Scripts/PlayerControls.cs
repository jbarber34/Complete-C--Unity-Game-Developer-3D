using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    // NEW INPUT SYSTEM //
    // [SerializeField] InputAction movement;
    // [SerializeField] InputAction fire;
    // NEW INPUT SYSTEM //

    [Header("Movement Tuning")]
    [Tooltip("Controls speed of the ship up/down movement")][SerializeField] float controlSpeed = 25f;
    [Tooltip("Left/Right movement range")][SerializeField] float xRange = 15f;
    [Tooltip("Up movement range")][SerializeField] float yMin = 5f;
    [Tooltip("Down movement range")][SerializeField] float yMax = 15f;

    [Header("Laser gun array")]
    [Tooltip("Array of lasers to turn on/off when firing")][SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]
    // [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("Amount of Yaw when turning")][SerializeField] float positionYawFactor = 2f;

    [Header("Control throw based tuning")]
    [Tooltip("Amount of Pitch/Roll when going up/down")][SerializeField] float controlFactor = -20f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
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
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }


    void ProcessFiring()
    {
        // Old Unity Input System //
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
        // Old Unity Input System //

        // New Unity Input System //
        // if (fire.ReadValue<float>() > 0)
        // {
        //     print("Pew Pew");
        // }
        // New Unity Input System //
    }

    void ProcessRotation()
    {
        float pitch = yThrow * controlFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        // Old Unity Input System //
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
        // Old Unity Input System //

        // New Unity Input System //
        // float xThrow = movement.ReadValue<Vector2>().x;
        // float yThrow = movement.ReadValue<Vector2>().y;
        // New Unity Input System //

        float xOffSet = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffSet = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yMin, yMax);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(208);

        SceneManager.LoadScene(3);
    }
}
