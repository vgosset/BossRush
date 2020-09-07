using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spike;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> lifeLst;
    
    [SerializeField] private float waveRate;
    [SerializeField] private float waveAmount;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spikeSpeed;
    
    [SerializeField] private int projDamage;

    private int life = 0;
    private float waveTimer = 0;
    
    void Start()
    {
        life = lifeLst.Count;
    }

    void Update()
    {
        if (waveTimer >= 0)
        {
            waveTimer -= Time.deltaTime;
        }
        else
        {
            waveTimer = waveRate;
            StartCoroutine(SpawnWave());
        }
    }
    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveAmount; i++)
        {
            GameObject tmp = Instantiate(spike, spawnPoint.position, spike.transform.rotation);
            tmp.GetComponent<SpikeMissile>().SetSpeed(spikeSpeed);
            tmp.GetComponent<EnemieProj>().SetDamage(projDamage);
            yield return new WaitForSeconds(spawnRate);
        }
    }
    public void GetHit()
    {
        if (lifeLst.Count > 0)
        {
            Destroy(lifeLst[0]);
            lifeLst.RemoveAt(0);
        }
    }
}
