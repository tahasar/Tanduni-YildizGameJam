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
    private Tweener mapTween;


    private void Start()
    {
        Vector3 startPosition = mapObj.transform.position;

        // Saða ve sola hareket eden tween'i oluþturun
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
