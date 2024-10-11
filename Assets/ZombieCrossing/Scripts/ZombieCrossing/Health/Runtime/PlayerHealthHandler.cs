using UnityEngine;
using System.Collections;
using ZombieCrossing.Health.Runtime;

public class PlayerHealthHandler : MonoBehaviour
{
    /// <summary>
    /// Health event channel to get callbacks from
    /// </summary>
    [SerializeField]
    private HealthEventChannel healthEventChannel;
    /// <summary>
    /// Player health
    /// </summary>
    [SerializeField]
    private float health;

    private bool IsDead = false;
    private bool HasTakenDamage = false;
    private float IFramesTimer = 0.0f;
    private float IFramesTime = 0.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.0f && !IsDead)
        {
            die();
        }
        // iframes
        if (HasTakenDamage)
        {
            IFramesTimer += Time.deltaTime;
            if (IFramesTimer >= IFramesTime) 
            {
                HasTakenDamage = false;
                IFramesTimer = 0.0f;// reset iframes timer
            }
        }
        
    }

    private void takeDamage(float damageDealt)
    {
        health -= damageDealt;
        HasTakenDamage = true;
        healthEventChannel.HandlePlayerHit();
        Debug.Log(gameObject.name + " took" + damageDealt + " damage at " + Time.time);

    }

    private void die()
    {
        health = 0.0f;
        // do stuff to die
        IsDead = true;
        healthEventChannel.HandlePlayerDeath();
        Debug.Log(gameObject.name + " died.");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("enemy") && !HasTakenDamage && !IsDead)
        {
            takeDamage(1.0f);// some enemy.damage value
        }
    }
}
