using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEventScript : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] AudioClip hoverSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
