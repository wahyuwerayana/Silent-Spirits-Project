using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth_Mansion : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    void Start(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}