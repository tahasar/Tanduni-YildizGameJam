using DG.Tweening;
using UnityEngine;

namespace Dosyalar.SpecularMapFile.Script
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] public GameObject mapObj;
        [SerializeField] public GameObject particleObj;
        [HideInInspector] CharacterMovement _characterGround;

        public float moveDistance = 1f;
        public float moveDuration = 1f;

        public bool dotween = true;
        bool _escDown = false;
        bool _firstEscPress = true;
        private Tweener _mapTween;


        private void Start()
        {
            Vector3 startPosition = mapObj.transform.position;

            // Sa�a ve sola hareket eden tween'i olu�turun
            _mapTween = mapObj.transform.DOMoveY(startPosition.x + moveDistance, moveDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }


        public void Update()
        {
            if (dotween)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && !_escDown)
                {
                    particleObj.SetActive(true);
                    _mapTween.Pause();
                    _escDown = true;
                
                    if (_firstEscPress)
                    {
                        VoiceManager.İnstance.Play("sahne8");
                    }
                
                    _firstEscPress = false;
                }
                else if (_escDown && Input.GetKeyDown(KeyCode.Escape))
                {
                    particleObj.SetActive(false);
                    _mapTween.Play();
                    _escDown = false;
                }
            }
        }

    }
}
