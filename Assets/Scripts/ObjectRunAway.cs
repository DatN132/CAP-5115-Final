using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectRunAway : MonoBehaviour
{
  public float speed = 1f;
  void Update()
  {
    Animator animator = GetComponent<Animator>();
    if (animator.GetBool("RunBack"))
    {
      Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
      transform.position = newPosition;
    }
  }

}
