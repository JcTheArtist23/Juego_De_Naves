using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
      void OnCollisionEnter2D(Collision2D collision)
    {
       collision.gameObject.SetActive(false);
    }
}
