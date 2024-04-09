using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDialogue : MonoBehaviour
{
    [SerializeField] public Image imageToShow;
    [SerializeField] public string titleToShow;
    [SerializeField] public TextElementType textToChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the image visible
            if (imageToShow != null)
            {
                imageToShow.enabled = true;
            }

            // Change the text of the text TMP item
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
