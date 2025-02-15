﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _laserPrefab;

    [Header("Boundaries")]
    [SerializeField] private float _topBoundary = 0f;
    [SerializeField] private float _bottomBoundary = -3.8f;
    [SerializeField] private float _leftBoundary = -11.3f;
    [SerializeField] private float _rightBoundary = 11.3f;

    [Header("Laser")]
    [SerializeField] private float _fireRate = 0.15f;
    private float _canFire = -1f;
  

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > _canFire))
        {
            FireLaser();
        }

        
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

    void FireLaser()
    {     
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity); 

    }
}