using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform health;

    private EnemyHealthManager _enemyHealth;
    private float _currentHealth;
    private float _maxHealth;
    private Camera _mainCamera;

    private void OnEnable()
    {
        _enemyHealth.onHealthUpdated += HealthUpdate;
    }

    private void OnDisable()
    {
        _enemyHealth.onHealthUpdated -= HealthUpdate;
    }

    private void Awake()
    {
        _enemyHealth = GetComponentInParent<EnemyHealthManager>();
        _currentHealth = _enemyHealth.CurrentHealth;
        _maxHealth = _enemyHealth.MaxHealth; 
        _mainCamera = Camera.main;
    }

    void Update()
    {
        UpdateBar();
        //AlignCamera();
    }

    private void UpdateBar()
    {

    }

    private void AlignCamera()
    {
        if (_mainCamera != null)
        {
            var camXform = _mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }

    private void HealthUpdate(float currentHealth)
    {
        if (_currentHealth <= 0)
        {
            enabled = false;
        }

        float percentChange = 1 - currentHealth / _currentHealth;

        _currentHealth -= percentChange * _currentHealth;
        health.localScale -= new Vector3(percentChange * health.localScale.x, 0, 0);
    }
}
