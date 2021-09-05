using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float rotationspeed = 30f;
    [SerializeField] private float movespeed = 150f;
    [SerializeField] private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
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
          
    }

   
}
