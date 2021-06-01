using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] float MaksHealth;

   public void TakeDamage(float amount)
    {
        MaksHealth -= amount;
        if (MaksHealth<=0)
        {
            Destroy(gameObject);
        }
    }
}
