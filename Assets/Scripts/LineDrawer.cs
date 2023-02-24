using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer lineRend; //Linerenderer
    private Vector2 mousePos; //Current mouse position
    private Vector2 startMousePos; //Mouse position when click begins
    private Vector2 endMousePos; //Mouse position when click ends
    public GameObject L; //Point in room
    public GameObject N; //Point in room
    public GameObject W1; //Point in room
    public GameObject W2; //Point in room
    public GameObject S1; //Point in room
    public GameObject S2; //Point in room
    public GameObject L1; //Point in room
    public GameObject L2; //Point in room
    public GameObject N_L2; //Wire between points
    public GameObject L_W1; //Wire between points
    public GameObject N_W2; //Wire between points
    public GameObject L_S1; //Wire between points
    public GameObject S2_L1; //Wire between points
    public AudioSource playSoundGood; 
    public AudioSource playSoundFalse;
    public int level;
    public Canvas myCanvas;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //When mouse click begins, activate linerenderer and save position
        {
            lineRend.positionCount = 2;
            startMousePos = Input.mousePosition / myCanvas.scaleFactor;
        }

        if (Input.GetMouseButton(0)) //During the click, draw the linrenderer
        {
            mousePos = Input.mousePosition / myCanvas.scaleFactor;
            lineRend.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            lineRend.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
        }
        if(Input.GetMouseButtonUp(0)) //When clcik ends, save mouse position, deactivate linerender and check if line is correct
        {
            endMousePos = Input.mousePosition / myCanvas.scaleFactor;
            lineRend.positionCount = 0;
            Calc(startMousePos, endMousePos);
        }
    }

    void Calc(Vector2 a, Vector2 b) //This function checks if starting and ending point are at correct positions. //Sorry for the long code, could easily be made smaller
    {
        if (Vector2.Distance(a,L.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at L");
            if (Vector2.Distance(b,W1.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (L_W1.activeSelf == false)
                {
                    print("Ending in W1");
                    L_W1.SetActive(true);
                    Good();
                }
            }
            else if (Vector2.Distance(b,S1.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (L_S1.activeSelf == false)
                {
                    print("Ending in S1");
                    L_S1.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,N.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at N");
            if (Vector2.Distance(b,W2.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (N_W2.activeSelf == false)
                {
                    print("Ending in W2");
                    N_W2.SetActive(true);
                    Good();
                }
            }
            else if (Vector2.Distance(b,L2.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (N_L2.activeSelf == false)
                {
                    print("Ending in L2");
                    N_L2.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,L1.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at L1");
            if (Vector2.Distance(b,S2.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (S2_L1.activeSelf == false)
                {
                    print("Ending in S2");
                    S2_L1.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,L2.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at L2");
            if (Vector2.Distance(b,N.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (N_L2.activeSelf == false)
                {
                    print("Ending in N");
                    N_L2.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,S1.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at S1");
            if (Vector2.Distance(b,L.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (L_S1.activeSelf == false)
                {
                    print("Ending in L");
                    L_S1.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,S2.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at S2");
            if (Vector2.Distance(b,L1.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (S2_L1.activeSelf == false)
                {
                    print("Ending in L1");
                    S2_L1.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,W1.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at W1");
            if (Vector2.Distance(b,L.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (L_W1.activeSelf == false)
                {
                    print("Ending in L");
                    L_W1.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
        else if (Vector2.Distance(a,W2.GetComponent<RectTransform>().anchoredPosition) < 40)
        {
            print("Starting at W2");
            if (Vector2.Distance(b,N.GetComponent<RectTransform>().anchoredPosition) < 40)
            {
                if (N_W2.activeSelf == false)
                {
                    print("Ending in N");
                    N_W2.SetActive(true);
                    Good();
                }
            }
            else
            {
                print("Ending in nothing");
                Bad();
            }
        }
    }

    void Good()
    {
        ScoreHandler.ScorePlus(level); //Increase the score
        playSoundGood.Play(); //Play good answer sound
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>();
        animator.SetTrigger("Good"); //Play good animation
    }

    void Bad()
    {
        ScoreHandler.ScoreMin(level); //Decrease the score
        playSoundFalse.Play(); //Play bad answer sound
        GameObject GoodBad = GameObject.Find("GoodBadAnswer");
        Animator animator = GoodBad.GetComponent<Animator>();
        animator.SetTrigger("Bad"); //Play bad animation
    }
}
