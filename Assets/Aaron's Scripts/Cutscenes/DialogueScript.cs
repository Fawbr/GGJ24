using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class DialogueScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] TextMeshProUGUI textDialogue;
    [SerializeField] EnemyBrain enemyBrain;
    [SerializeField] string[] dialogue;
    [SerializeField] Camera cinemachineCam;
    [SerializeField] List<CinemachineVirtualCamera> virtualCameras = new List<CinemachineVirtualCamera>();
    [SerializeField] float textSpeed;
    [SerializeField] private int index;
    [SerializeField] GameObject bat;
    // Start is called before the first frame update
    void Start()
    {
        textDialogue.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textDialogue.text == dialogue[index])
            {
                NextLine();
                CameraTransition(index);
            }
            else
            {
                StopAllCoroutines();
                textDialogue.text = dialogue[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine("TypeLine");
    }

    void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            textDialogue.text = string.Empty;
            StartCoroutine("TypeLine");
        }
        else
        {
            CameraTransition(index + 1);
            StartCoroutine("CloseDialogue");
        }
    }

    void CameraTransition(int camIndex)
    {
        virtualCameras[camIndex].enabled = true;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue[index].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator CloseDialogue()
    {
        enemyBrain.enabled = true;
        foreach (EnemyAI enemyAI in enemyBrain.enemyList)
        {
            enemyAI.enabled = true;
            enemyAI.isAggressive = false;
        }
        bat.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        cinemachineCam.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
