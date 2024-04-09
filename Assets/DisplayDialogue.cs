using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialogue : MonoBehaviour
{
    [SerializeField] public Image imageToShow;
    [SerializeField] public string titleToShow;
    [SerializeField] public Text textToChange;

    void Start(){
        imageToShow.enabled = false;
        textToChange.text = "";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (imageToShow != null)
            {
                imageToShow.enabled = true;
            }

            if (textToChange != null)
            {
                textToChange.text = "New Text";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Turn off the image
            if (imageToShow != null)
            {
                imageToShow.enabled = false;
            }

            // Remove the text
            if (textToChange != null)
            {
                textToChange.text = "";
            }
        }
    }
}
