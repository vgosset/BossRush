using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrival : MonoBehaviour
{
    [SerializeField] private List<GameObject> cameraLst;

    private PlayerMovement p_move;

    private void Start()
    {
       p_move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void NextCame()
    {
        for (int i = 0; i < cameraLst.Count; i++)
        {
            if (cameraLst[i].activeSelf && i < cameraLst.Count)
            {
                cameraLst[i].SetActive(false);
                cameraLst[i + 1].SetActive(true);
                return;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.transform.tag == "Player")
      {
          NextCame();
          p_move.CameraTransition(1);
          Destroy(this.gameObject);
      }
    }
}
