using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private PlayerAction p_action;
    [SerializeField] private PlayerMovement p_movement;

    [SerializeField] private PlayableDirector t_intro;

    private bool hasBeenTrigger;

    private void Awake()
    {
        Instance = this;

        if (!hasBeenTrigger)
            StartCoroutine(Cor_Intro());
    }

    private IEnumerator Cor_Intro()
    {
        t_intro.Play();
        hasBeenTrigger = true;

        yield return new WaitForSeconds((float) t_intro.duration);
        
        SetPlayerState(true);
    }
    public void SetPlayerState(bool state)
    {
        p_action.enabled = state;
        p_movement.enabled = state;
    }
}
