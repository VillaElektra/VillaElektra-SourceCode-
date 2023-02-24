using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public int id;
    public int level;
    public Image img;
    public Text txt;
    public AudioSource playSoundGood;
    public AudioSource playSoundFalse;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>(); //Find animator
        
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition; //Give dragged gameobject same position as this gameobject
                eventData.pointerDrag.GetComponent<DragAndDrop>().locked = true; //Lock the dragged gameobject
                ScoreHandler.ScorePlus(level); //Increase the score
                playSoundGood.Play(); //Play good answer sound
                animator.SetTrigger("Good"); //Play good animation
                if (img != null)
                {
                    img.enabled = false;
                }
                if (txt != null)
                {
                    txt.enabled = false;
                }
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition(); //Reset position dragged gameobject
                ScoreHandler.ScoreMin(level); //Decrease the score
                playSoundFalse.Play(); //Play bad answer sound
                animator.SetTrigger("Bad"); //Play bad animation
            }
        }
    }
}
