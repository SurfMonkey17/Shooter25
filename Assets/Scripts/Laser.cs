using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
 
    //speed variable of 8
    [SerializeField] private float _laserSpeed = 8.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //laser moves up infinitely
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
    }
}
