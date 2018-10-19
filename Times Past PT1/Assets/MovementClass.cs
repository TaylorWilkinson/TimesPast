using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementClass : MonoBehaviour
{
    //1. 8-directional movement
    //2. stop and face current direction when input is absent

    public float velocity = 5;
    public float turnSpeed = 10;
    Vector2 input;
    float angle;
    Quaternion targetRotation;
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update() {
        GetInput();

        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

        CalculateDirection();
        Rotate();
        Move();
    }

    void GetInput() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void CalculateDirection() {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    void Rotate() {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move() {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }


    /*
    [SerializeField]

    float moveSpeed = 5.0f;
    Vector3 forward, right, heading;
    //will dictate forward and right vectors that will differ from the world axes

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0; //for clarity; ensures that y value is always set to 0
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //creating a rotation for the right vector, telling it to be moved 90 degrees around the x-axis
        //times that by the forward vector, which gives a right vector roughly facing -45 degrees from the world x-axis
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //new direction is equal to the value of X and Y input at any given time

        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //rotation transformation
        transform.forward = heading;

        //movement transformation
        transform.position += rightMovement;
        transform.position += upMovement;
    }
    */
}
