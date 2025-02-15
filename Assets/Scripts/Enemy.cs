using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _enemySpeed = 4f;

    [Header("Boundaries")]
    [SerializeField] private float _topBoundary = 7.8f;
    [SerializeField] private float _bottomBoundary = -5.7f;
    [SerializeField] private float _leftBoundary = -9f;
    [SerializeField] private float _rightBoundary = 9f;

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

}
       

    



