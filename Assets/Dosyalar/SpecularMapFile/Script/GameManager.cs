using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject mapObj;
    [SerializeField] public GameObject particleObj;
    [HideInInspector] CharacterMovement characterGround;

    public float moveDistance = 1f;
    public float moveDuration = 1f;

    public bool dotween = true;
    bool escDown = false;
    bool firstEscPress = true;
    private Tweener mapTween;


    private void Start()
    {
        Vector3 startPosition = mapObj.transform.position;

        // Sa�a ve sola hareket eden tween'i olu�turun
        mapTween = mapObj.transform.DOMoveY(startPosition.x + moveDistance, moveDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }


    public void Update()
    {
        if (dotween)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !escDown)
            {
                particleObj.SetActive(true);
                mapTween.Pause();
                escDown = true;
                
                if (firstEscPress)
                {
                    VoiceManager.instance.Play("sahne8");
                }
                
                firstEscPress = false;
            }
            else if (escDown && Input.GetKeyDown(KeyCode.Escape))
            {
                particleObj.SetActive(false);
                mapTween.Play();
                escDown = false;
            }
        }
    }

}
