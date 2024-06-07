using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;

    void Start()
    {
        _currentHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        if (_currentHealth < 0) _currentHealth = 0;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBarFill.fillAmount = targetFillAmount;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
}
