using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject group;

    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.tag == "Player")
      {
          group.SetActive(true);
      }
    }
}
