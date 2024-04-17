using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpKat : MonoBehaviour
{

    public Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("power");
        GameManager.gm.player.localScale += new Vector3(0.3f,0.3f,0.3f);
        if (mainCamera != null)
        {
            float scaleFactor = GameManager.gm.player.localScale.x; // Assuming uniform scaling
            mainCamera.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
        Destroy(gameObject);
    }

}
