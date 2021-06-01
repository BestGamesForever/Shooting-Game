using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public Rigidbody[] _bulletPrefabs;
    [SerializeField] ParticleSystem Muzzle;    
    [Header("CounterShooting")]
    List<Rigidbody> Bullets = new List<Rigidbody>();
    [SerializeField] Text Counting;
    [Header("Button For Bullet types")]
    [SerializeField] Button _bulletTyper;
    bool isBullets;

    float angle;
    private void Update()
    {
        //For Mobile Use
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())//Input.GetTouch(0).fingerId)
            {
                return;
            }
        }
            Raycast();
        Rotategun();       
        HandleShooting();
    }
    void Raycast()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 2f);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, 20, 9))
        {
            if (hitinfo.collider == null)
            {
                return;
            }
            else
            {
                var direction = hitinfo.point - transform.position;
                direction.y = 0;
                direction.Normalize();
                transform.forward = direction;
                transform.LookAt(ray.direction);
            }
        }
    }
    void Rotategun()
    {       
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        transform.rotation = Quaternion.Euler(new Vector3(-5, Mathf.Clamp(-angle, -40, 40), 0));
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2((a.x - b.x), -(a.y - b.y)) * Mathf.Rad2Deg;
    }
  
    void HandleShooting()
    {
        if (Input.GetButton("Fire1"))
        {
            Rigidbody _bullet;
            Vector3 ScatterValue = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
            if (!isBullets)
            {
                _bullet = Instantiate(_bulletPrefabs[0], transform.position + ScatterValue, transform.rotation) as Rigidbody;
            }
            else
            {
                int RandomBullets = Random.Range(0, _bulletPrefabs.Length);
                _bullet = Instantiate(_bulletPrefabs[RandomBullets], transform.position + ScatterValue, transform.rotation) as Rigidbody;
            }
                      
            Bullets.Add(_bullet);           
            Counting.text = Bullets.Count.ToString();
            Muzzle.Play();

        }
    }
    public void changeBullets()
    {
        isBullets =! isBullets;
        Debug.Log("isBullets" + isBullets);
        if (isBullets)
        {
            _bulletTyper.GetComponent<Image>().color = Color.green;
        }
        else
        {
            _bulletTyper.GetComponent<Image>().color = Color.red;
        }
    }
}
