using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCoin : MonoBehaviour
{
    public int value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin get");
        GameManager.gm.score += value;
        Destroy(gameObject);
    }




}
