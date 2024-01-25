using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
public class DialogueScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] TextMeshProUGUI textDialogue;
    [SerializeField] string[] dialogue;
    [SerializeField] List<CinemachineVirtualCamera> virtualCameras = new List<CinemachineVirtualCamera>();
    [SerializeField] float textSpeed;
    [SerializeField] private int index;

    // Start is called before the first frame update
    void Start()
    {
        textDialogue.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
            gameObject.SetActive(false);
        }
    }

    void CameraTransition(int camIndex)
    {
        virtualCameras[index].enabled = true;
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue[index].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
