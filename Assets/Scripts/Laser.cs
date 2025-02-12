using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
 
    [SerializeField] private float _laserSpeed = 8.0f;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        //if position on y > 8, destroy laser

        if (transform.position.y > 8f)
        {
            Destroy(gameObject);
        }
    }
}
