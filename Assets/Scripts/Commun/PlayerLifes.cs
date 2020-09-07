using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifes : MonoBehaviour
{
    [SerializeField] private List<GameObject> lifeLst;
    [SerializeField] private List<MeshRenderer> meshs;

    [SerializeField] private GameObject fx_die;

    private void Start()
    {
    }
    public void GetHit(int amount)
    {
        if (lifeLst.Count > 0)
        {
            Destroy(lifeLst[0]);
            lifeLst.RemoveAt(0);
        }
        if (lifeLst.Count == 0)
        {
            Instantiate(fx_die, this.transform.position, Quaternion.identity);

            for (int i = 0; i < meshs.Count; i++)
            {
                meshs[i].enabled = false;
            }
            StartCoroutine(Restart());
        }
    }
    private IEnumerator Restart()
    {
        GameManager.Instance.SetPlayerState(false);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
