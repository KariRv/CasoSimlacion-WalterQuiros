using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Implementar sistema de salud al jugador 30 PUNTOS
// * Agentes da;an 5
// * Los objetos obsilantes da;an 15
// * Cuando pierden la vida reinician la escena 20 PUNTOS

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0F;
    float _currentHealth;

    [SerializeField]
    bool isPlayer;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        _currentHealth -= Mathf.Abs(damage);
        if (_currentHealth <= 0.0F)
        {
            if (isPlayer)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Heal(float repair)
    {
        _currentHealth += Mathf.Abs(repair);
    }

    
}
