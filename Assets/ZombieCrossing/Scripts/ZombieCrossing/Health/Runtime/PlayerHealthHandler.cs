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
        if (health <= 0.0f)
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
            }
        }
        
    }

    private void dealDamage(float damageDealt)
    {
        health -= damageDealt;
        healthEventChannel.HandlePlayerHit();
        Debug.Log("Oof! I took damage at " + Time.time);

    }

    private void die()
    {
        health = 0.0f;
        // do stuff to die
        healthEventChannel.HandlePlayerDeath();
        Debug.Log("Oh no! I died!");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("enemy"))// && !HasTakenDamage)
        {
            dealDamage(1.0f);/// some enemy.damage value

        }
    }
}
