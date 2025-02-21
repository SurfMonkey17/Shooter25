using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private float _bombTimer = 3f;  
    [SerializeField] private float _bombSpeed = 3f;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private MeshRenderer _bombModel;
    void Start()
    {
        Debug.Log("BombScript started");
        StartCoroutine(BombTimer());
    }

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(Vector3.up * Time.deltaTime * _bombSpeed);
        }
    }
     IEnumerator BombTimer()
    {   
        yield return new WaitForSeconds(_bombTimer);
        _explosion.Play();
        _bombModel.enabled = false;    
    }

    
}
