using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] private float rotationspeed = 30f;
    [SerializeField] private float movespeed = 150f;
    [SerializeField] private CharacterController controller;
    public float speedyJump = 250;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontal * rotationspeed * Time.deltaTime);
        float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", vertical);
        controller.SimpleMove(-transform.forward * movespeed * vertical * Time.deltaTime);
       
        float jump = Input.GetAxis("Jump");
        animator.SetFloat("SpeedJump", jump);
        Vector3 jumpy = new Vector3(0.0f, 3.0f, 0.0f);
        rb.AddForce(jumpy * speedyJump * 2);

    }

   
}
