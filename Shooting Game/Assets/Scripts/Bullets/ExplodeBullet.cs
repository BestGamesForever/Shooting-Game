using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] ParticleSystem explode;
    [SerializeField] GameObject ExplodeParticle;
    bool shooting;
    private void Start()
    {
        StartCoroutine(DestroyAndExplode());
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * 25 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        EnemyHealthManager _enemyHealt = other.gameObject.GetComponent<EnemyHealthManager>();
        if (_enemyHealt != null)
        {
            _enemyHealt.TakeDamage(damage);
        }
    }   
    IEnumerator DestroyAndExplode()
    {
        float startTime = Time.time;
        while (Time.time - startTime < 1f)
        {
            ParticleSystem _explode = Instantiate(explode);
            _explode.transform.parent = gameObject.transform;
            _explode.transform.position = transform.position;
            yield return new WaitForSeconds(.5f);
            _explode.Play();          
            yield return new WaitForSeconds(.5f);
            Destroy(_explode);
            Destroy(gameObject);
        }
        

    }
}
