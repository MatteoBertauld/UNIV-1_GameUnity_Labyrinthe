using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;

    private float verticalSpeed;
    private float horizontalSpeed;

    private Vector3 input;
    private Vector3 rotation;

    private Rigidbody rigidbody;

    private Camera pCamera;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        pCamera = GetComponent<Camera>();
        rotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FixedUpdate()
    {
        input.Set(Input.GetAxis("Horizontal") * Time.deltaTime, 0, Input.GetAxis("Vertical") * Time.deltaTime);
        rotation.Set(0, Input.GetAxis("Mouse X"), 0);
        Quaternion qRotation = Quaternion.Euler(rotation * Time.deltaTime * rotationSpeed);

        rigidbody.MovePosition(transform.position + input.normalized * movementSpeed);
        rigidbody.rotation = Quaternion.LookRotation(rotation);

        Debug.Log(input);
    }
}

