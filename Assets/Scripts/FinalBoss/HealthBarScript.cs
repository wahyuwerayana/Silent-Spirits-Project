using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private float _fillSpeed;
    [SerializeField] private Gradient _colorGradient;

    void Start()
    {
        _currentHealth = _maxHealth;
        UpdateHealthBar();
    }

    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, _maxHealth);
        //if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        //if (_currentHealth < 0) _currentHealth = 0;

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        //_healthBarFill.fillAmount = targetFillAmount;
        _healthBarFill.DOFillAmount(targetFillAmount, _fillSpeed);
        _healthBarFill.color = _colorGradient.Evaluate(targetFillAmount);
    
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }
}
