using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _projectiles;
    [SerializeField] private Transform _idleTransform;

    public event UnityAction OnProjectilesOut;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (!_projectiles.Any())
        {
            OnProjectilesOut?.Invoke();
        }
        else
        {
            var projectile = _projectiles.FirstOrDefault();
            projectile.transform.SetParent(_idleTransform);
            projectile.transform.position = _idleTransform.position;
            projectile.AddComponent<CurrentProjectile>();
            _projectiles.Remove(projectile);
        }
    }
}
