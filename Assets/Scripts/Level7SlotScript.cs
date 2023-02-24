using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Level7SlotScript : MonoBehaviour, IDropHandler
{
    public int id;
    public int level;
    //public AudioSource playSoundGood;
    //public AudioSource playSoundFalse;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>(); //Find animator

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition(); //Reset position dragged gameobject
                ScoreHandler.ScorePlus(level); //Increase the score
                //playSoundGood.Play(); //Play good answer sound
                animator.SetTrigger("Good"); //Play good animation
                Level7Controller.PlusOne(); //Next slide
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition(); //Reset position dragged gameobject
                ScoreHandler.ScoreMin(level); //Decrease the score
                //playSoundFalse.Play(); //Play bad answer sound
                animator.SetTrigger("Bad"); //Play bad animation
            }
        }
    }
}
