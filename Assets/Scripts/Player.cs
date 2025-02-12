using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] GameObject _laserPrefab;

    [Header("Boundaries")]
    [SerializeField] private float _topBoundary = 0f;
    [SerializeField] private float _bottomBoundary = -3.8f;
    [SerializeField] private float _leftBoundary = -11.3f;
    [SerializeField] private float _rightBoundary = 11.3f; 


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();
     }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        float clampedY = Mathf.Clamp(transform.position.y, _bottomBoundary, _topBoundary);
        float wrappedX = Mathf.Repeat(transform.position.x - _leftBoundary, _rightBoundary - _leftBoundary) + _leftBoundary;

        transform.position = new Vector3(wrappedX, clampedY, 0); 
    }

    void fireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space)){

            Instantiate(_laserPrefab, transform.position, Quaternion.identity);

        }
    }
}