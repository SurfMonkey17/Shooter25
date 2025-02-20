using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const bool V = true;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _lives = 3;

    [Header("Boundaries")]
    [SerializeField] private float _topBoundary = 0f;
    [SerializeField] private float _bottomBoundary = -3.8f;
    [SerializeField] private float _leftBoundary = -11.2f;
    [SerializeField] private float _rightBoundary = 11.2f;

    [Header("Laser")]
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.15f;
    private float _canFire = -1f;

    [SerializeField] private bool _canUseBomb = true;
    public Bomb bomb;


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


        if (Input.GetKeyDown(KeyCode.R) && (_canUseBomb == true))
        {
            StartCoroutine(Bomb.CreateBomb());
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

    public void Damage()
    {
        _lives -= 1;

        if (_lives < 1)
        {
            Destroy(gameObject);
        }
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);

    }
}

   