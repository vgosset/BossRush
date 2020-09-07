using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] int lifeCount;
    [SerializeField] List<Material> matType = new List<Material>();
    // Start is called before the first frame update
    private NavMeshObstacle obstacle;

    private void Awake()
    {
        GetComponent<Renderer>().material = matType[lifeCount - 1];
        obstacle = GetComponent<NavMeshObstacle>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerProj")
        {
            HasBeenHit();
            Destroy(other.gameObject);
        }
    }
    public void HasBeenHit()
    {
        lifeCount --;
        if (lifeCount == 0)
        {
            Destroy(gameObject);
            obstacle.carving = false;
        }
        else
            GetComponent<Renderer>().material = matType[lifeCount - 1];
    }
}
