using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Transform motor;

    //-------- Movement --------//
    public float speed = .1f;
    public float maxSpeed = 10f;
    public float steerPower = .1f;

    private Rigidbody rb;

    //-------- UI --------//
    //[SerializeField]
    //public GameObject UI;

    public void Start()
    {
        //UI.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        var steer = 0;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0)
            steer = 1;
        if (horizontal < 0)
            steer = -1;

        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);

        if (vertical > 0)
        {
            rb.AddForceAtPosition(steer * transform.right * 1f, motor.position);
            rb.AddForce(-.5f * forward, ForceMode.VelocityChange);
        }
    }

    //public void Update()
    //{
    //    //if (!EventSystem.current.IsPointerOverGameObject())
    //    //{
    //    //
    //    //}
    //    
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        UI.SetActive(true);
    //    }
    //}
}
