using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Rigidbody Rb;
    [SerializeField] float speed;
  
    void Start()
    {
        Rb = GetComponent<Rigidbody>();      
    }

    void Update()
    {       
        MoveRb();    
    }  
   
  void MoveRb()
  {
      float Xpos = Input.GetAxis("Horizontal");
      float Zpos = Input.GetAxis("Vertical");
      Vector3 Movementdir = new Vector3(Xpos, 0, Zpos);
      Movementdir.Normalize();
      transform.Translate(Movementdir * speed*Time.deltaTime,Space.World) ;    
  }
}

