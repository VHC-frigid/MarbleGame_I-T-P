using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float camspeed;
    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
        }

        Movement(speed);

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * camspeed);

    }

    private void Movement(float movespeed)
    {
        
        //this chunk adds velocity to the player based on the horizonal and vertical axis's
        Vector3 movement = Vector3.zero;
        movement += transform.right * Input.GetAxis("Horizontal");
        movement += transform.forward * Input.GetAxis("Vertical");
        GetComponent<Rigidbody>().AddForce(movement * movespeed * Time.deltaTime);

        //make sure the player is not going TOO fast
        movement = GetComponent<Rigidbody>().velocity;
        movement = Vector3.ClampMagnitude(movement, maxspeed);
        GetComponent<Rigidbody>().velocity = movement;

    }




}
