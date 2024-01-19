using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentProjectile : MonoBehaviour
{
    private RubberHandler _rubberHandler;
    private Rigidbody2D _rigidbody2D;
    private bool _isDropped = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.angularDrag = 1f;
        _rubberHandler = FindObjectOfType<RubberHandler>();
    }

    private void Update()
    {
        if (_isDropped)
        {
            if (_rigidbody2D.velocity.magnitude < 0.2f) 
            {
                FindObjectOfType<ProjectileSpawner>().Spawn();
                Destroy(gameObject);
            }
        }
    }

    private void ChangeState()
    {
        _isDropped = true;
    }

    private void OnEnable()
    {
        _rubberHandler.OnRubberRelease += ChangeState;
    }

    private void OnDisable()
    {
        _rubberHandler.OnRubberRelease -= ChangeState;
    }
}
