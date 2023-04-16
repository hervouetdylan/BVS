using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvicible = false;

    public float InvincibilityFlashDelay = 0.15f;

    public float InvicibilityTimeAfterHit = 3f;

    public HealthBar healthBar;

    public SpriteRenderer graphics;

    public static PlayerHealth instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'un instance de PayerHealth dans la scène");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if(currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvicible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void Die()
    {
        Mouvements player = GameObject.Find("Player").GetComponent<Mouvements>();
        player.isDead = true;
        Debug.Log("Le joueur est iliminé");
        player.animator.SetTrigger("Die");
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(InvincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvicibilityTimeAfterHit);
        isInvicible = false;
    }
}
