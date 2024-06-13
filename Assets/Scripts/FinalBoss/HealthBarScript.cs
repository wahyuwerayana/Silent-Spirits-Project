using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBarScript : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private float _fillSpeed;
    [SerializeField] private Gradient _colorGradient;

    public event Action OnHealthZero; 

    void Start()
    {
        _currentHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);
        UpdateHealthBar();

        if (_currentHealth <= 0 && OnHealthZero != null)
        {
            OnHealthZero.Invoke();
        }
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBarFill.DOFillAmount(targetFillAmount, _fillSpeed);
        _healthBarFill.color = _colorGradient.Evaluate(targetFillAmount);
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
}
