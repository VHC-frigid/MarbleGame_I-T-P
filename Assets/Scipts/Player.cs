using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float camspeed;
    public float maxspeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gm.player = transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }

        Movement(speed);

        Camera.main.transform.parent.Rotate(Vector3.up * Input.GetAxis("Mouse X") * camspeed);
        Camera.main.transform.parent.position = transform.position;

    }

    private void Movement(float movespeed)
    {
        
        //this chunk adds velocity to the player based on the horizonal and vertical axis's
        Vector3 movement = Vector3.zero;
        movement += Camera.main.transform.right * Input.GetAxis("Horizontal");
        movement += Camera.main.transform.forward * Input.GetAxis("Vertical");
        movement.y = 0;
        movement.Normalize();
        GetComponent<Rigidbody>().AddForce(movement * movespeed * Time.deltaTime);

        //make sure the player is not going TOO fast
        movement = GetComponent<Rigidbody>().velocity;
        movement.y = 0;
        movement = Vector3.ClampMagnitude(movement, maxspeed);
        movement.y = GetComponent<Rigidbody>().velocity.y;
        GetComponent<Rigidbody>().velocity = movement;

    }




}
