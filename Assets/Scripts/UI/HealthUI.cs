using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private TMP_Text _healthText;
    private PlayerHealthManager _healthManager;

    private void Awake()
    {
        _healthText = GetComponent<TMP_Text>();
        _healthManager = FindObjectOfType<PlayerHealthManager>();
    }

    void Update()
    {
        _healthText.text = _healthManager.CurrentHealth.ToString();
    }
}
