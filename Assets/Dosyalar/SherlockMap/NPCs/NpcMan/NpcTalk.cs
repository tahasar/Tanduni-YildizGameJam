using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTalk : MonoBehaviour
{
    [SerializeField] GameObject character;
    Animator anim;
    public bool isTalking = false;
    bool playTalk;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Update()
    {
        float distance = Vector3.Distance(transform.position, character.transform.position);

        if (distance < 3f && !playTalk)
        {
            StartCoroutine(NpcTalkState());
        }

    }

    IEnumerator NpcTalkState()
    {
        playTalk = true;

        Vector3 direction = character.transform.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(direction),Time.deltaTime);

        isTalking = true;
        anim.SetBool("isTalking", true);

        yield return new WaitForSeconds(5f);

        anim.SetBool("isTalking", false);
        isTalking = false;
    }
}
