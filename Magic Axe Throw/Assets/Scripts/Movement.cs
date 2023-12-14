using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    // PARAMETERS
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 200f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem thrustParticles;


    // CACHE
    Rigidbody rb;
    AudioSource audioSource;

    // STATE
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    // Process Thrusting and Rotation
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            // Start Landing 
            rb.AddRelativeForce(Vector3.down * mainThrust * Time.deltaTime);
        }
        else
        {
            StopThrusting();
        }
    }


    void ProcessRotation()
    {
        StartRotating();
    }

    // Create Thrusting and Rotation Methods
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        // transform.position += new Vector3(0, 0.1f, 0);
        // Play audio when thrusting
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        // Play particles when thrusting
        if (!thrustParticles.isPlaying)
        {
            thrustParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        thrustParticles.Stop();
    }

    void StartRotating()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    // Apply Rotation
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }

    // Disable thrusters when Movment script is disabled
    void OnDisable()
    {
        thrustParticles.Stop();
    }
}
