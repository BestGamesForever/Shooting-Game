using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    [SerializeField] float damage;
    private void Start()
    {
        Destroy(gameObject, 3);
    }
    private void Update()
    {
       transform.Translate(Vector3.forward * 10 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        EnemyHealthManager _enemyHealt = other.gameObject.GetComponent<EnemyHealthManager>();
        if (_enemyHealt!=null)
        {           
            _enemyHealt.TakeDamage(damage);
        }
    }
}
