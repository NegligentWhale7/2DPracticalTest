using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] PlayerInputManager inputManager;
    [SerializeField] Canvas interactPanel;
    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] UnityEvent interactEvent;
    [SerializeField] string interactDesc;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inputManager.CanInteract = true;
            interactPanel.enabled = true;
            interactText.text = interactDesc; ;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (inputManager.InteractInput && inputManager.CanInteract)
        {
            interactEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactPanel.enabled = false;
            inputManager.CanInteract = false;
            interactText.text = "";
        }
    }
}
