using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBoost : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("boosted");
        GameManager.gm.boostTimer = 0.5f;
        Destroy(gameObject);

        //GameManager.gm.player.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 500);
    }

}
