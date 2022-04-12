using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeVehicleController : MonoBehaviour
{
    public enum groundCheck { rayCast, sphereCaste };
    public enum MovementMode { Velocity, AngularVelocity };
    public MovementMode movementMode;
    public groundCheck GroundCheck;
    public LayerMask drivableSurface;
    public float MaxSpeed, accelaration, turn;
    public Rigidbody rb, carBody;
    
    private RaycastHit hit;
    public AnimationCurve frictionCurve;
    public AnimationCurve turnCurve;
    public PhysicMaterial frictionMaterial;
    [Header("Visuals")]
    public Transform BodyMesh;
    public Transform[] FrontWheels = new Transform[2];
    public Transform[] RearWheels = new Transform[2];
    [HideInInspector]
    public Vector3 carVelocity;
    
    [Range(0,10)]
    public float BodyTilt;
    [Header("Audio settings")]
    public AudioSource engineSound;
    [Range(0, 1)]
    public float minPitch;
    [Range(1, 3)]
    public float MaxPitch;
    public AudioSource SkidSound;

    [HideInInspector]
    public float skidWidth;


    private float radius, horizontalInput, verticalInput;
    private Vector3 origin;

    [HideInInspector] public float sign;
    [HideInInspector] public float TurnMultiplyer;

    private void Start()
    {
        radius = rb.GetComponent<SphereCollider>().radius;
        if (movementMode == MovementMode.AngularVelocity)
        {
            Physics.defaultMaxAngularSpeed = 100;
        }

    }
    private void Update()
    {
        verticalInput = Mathf.Min(Input.GetAxis("Vertical") * 2 + 1, 1);
        horizontalInput = SimpleInput.GetAxis("Horizontal"); //turning input
        Visuals();
        AudioManager();

    }
    public void AudioManager()
    {
        engineSound.pitch = Mathf.Lerp(minPitch, MaxPitch, Mathf.Abs(carVelocity.z) / MaxSpeed);
        if (Mathf.Abs(carVelocity.x) > 10 && grounded())
        {
            SkidSound.mute = false;
        }
        else
        {
            SkidSound.mute = true;
        }
    }


    public void FixedUpdate()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Ingame)
        {           
            carVelocity = carBody.transform.InverseTransformDirection(carBody.velocity);

            if (Mathf.Abs(carVelocity.x) > 0)
            {
                //changes friction according to sideways speed of car
                frictionMaterial.dynamicFriction = frictionCurve.Evaluate(Mathf.Abs(carVelocity.x / 100));
            }


            if (grounded())
            {

                //turnlogic
                sign = Mathf.Sign(carVelocity.z);
                TurnMultiplyer = turnCurve.Evaluate(carVelocity.magnitude / MaxSpeed);
                if (verticalInput > 0.1f || carVelocity.z > 1)
                {
                    carBody.AddTorque(Vector3.up * horizontalInput * sign * turn * 100 * TurnMultiplyer);
                }
                else if (verticalInput < -0.1f || carVelocity.z < -1)
                {
                    carBody.AddTorque(Vector3.up * horizontalInput * sign * turn * 100 * TurnMultiplyer);
                }

                //brakelogic
                if (Input.GetAxis("Jump") > 0.1f)
                {
                    rb.constraints = RigidbodyConstraints.FreezeRotationX;
                }
                else
                {
                    rb.constraints = RigidbodyConstraints.None;
                }

                //accelaration logic

                if (movementMode == MovementMode.AngularVelocity)
                {
                    if (Mathf.Abs(verticalInput) > 0.1f)
                    {
                        rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, carBody.transform.right * verticalInput * MaxSpeed / radius, accelaration * Time.deltaTime);
                    }
                }
                else if (movementMode == MovementMode.Velocity)
                {
                    if (Mathf.Abs(verticalInput) > 0.1f && Input.GetAxis("Jump") < 0.1f)
                    {
                        rb.velocity = Vector3.Lerp(rb.velocity, carBody.transform.forward * verticalInput * MaxSpeed, accelaration / 10 * Time.deltaTime);
                    }
                }

                //body tilt
                carBody.MoveRotation(Quaternion.Slerp(carBody.rotation, Quaternion.FromToRotation(carBody.transform.up, hit.normal) * carBody.transform.rotation, 0.12f));
            }
            else
            {
                carBody.MoveRotation(Quaternion.Slerp(carBody.rotation, Quaternion.FromToRotation(carBody.transform.up, Vector3.up) * carBody.transform.rotation, 0.02f));
            }
        }
        

    }
    public void Visuals()
    {
        //tires
        foreach (Transform FW in FrontWheels)
        {
            FW.localRotation = Quaternion.Slerp(FW.localRotation, Quaternion.Euler(FW.localRotation.eulerAngles.x,
                               30 * horizontalInput, FW.localRotation.eulerAngles.z), 0.1f);
            FW.GetChild(0).localRotation = rb.transform.localRotation;
        }
        RearWheels[0].localRotation = rb.transform.localRotation;
        RearWheels[1].localRotation = rb.transform.localRotation;

        //Body
        if(carVelocity.z > 1)
        {
            BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(Mathf.Lerp(0, -5, carVelocity.z / MaxSpeed),
                               BodyMesh.localRotation.eulerAngles.y, BodyTilt * horizontalInput), 0.05f);
        }
        else
        {
            BodyMesh.localRotation = Quaternion.Slerp(BodyMesh.localRotation, Quaternion.Euler(0,0,0) , 0.05f);
        }
        

    }
    public bool grounded() //checks for if vehicle is grounded or not
    {
        origin = rb.position + rb.GetComponent<SphereCollider>().radius * Vector3.up;
        var direction = Vector3.down;
        var maxdistance = rb.GetComponent<SphereCollider>().radius + 0.2f;

        if (GroundCheck == groundCheck.rayCast)
        {
            if (Physics.Raycast(rb.position, Vector3.down, out hit, maxdistance, drivableSurface))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        else if(GroundCheck == groundCheck.sphereCaste)
        {
            if (Physics.SphereCast(origin, radius + 0.1f, direction, out hit, maxdistance, drivableSurface))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        else { return false; }
    }

    private void OnDrawGizmos()
    {
        //debug gizmos
        radius = rb.GetComponent<SphereCollider>().radius;
        float width = 0.02f;
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(rb.transform.position + ((radius + width) * Vector3.down), new Vector3(2 * radius, 2*width, 4 * radius));
            if (GetComponent<BoxCollider>())
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
            }
            
        }

    }
    void Finish()
    {
        accelaration = 5;
        GameManager.Instance.gameState = GameManager.GameState.Next;

    }

    void Death()
    {

        GameManager.Instance.gameState = GameManager.GameState.Gameover;

        if (MaxSpeed == 0)

        {
            FindObjectOfType<AudioManager>().Play("fail");

            FindObjectOfType<AudioManager>().Stop("acc");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Finish();

        }

        if (other.CompareTag("Obstacle"))
        {
            verticalInput = 0;
            turn = 0;
            Death();
        }
    }

}
