using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _enemySpeed = 4f;

    
    private float _topBoundary = 7.8f;
    private float _bottomBoundary = -5.7f;
    private float _leftBoundary = -9f;
    private float _rightBoundary = 9f;

    void Start()
    {

    }

    void Update()
    {

        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
                
        if (transform.position.y < _bottomBoundary)
        {
            transform.position = (new Vector3(Random.Range(_leftBoundary, _rightBoundary), _topBoundary, 0));

        }

    }    

    private void OnTriggerEnter(Collider other)
    {
            //if other is player
        if (other == GameObject.FindWithTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("destroy enemy");
        }
            //damage the player

            //if other is laser

        if (other == GameObject.FindWithTag("Laser")){

            Destroy(this.gameObject);
            Debug.Log("Laser destroy enemy");
        }
         
    }

    

}
       

    



