using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class Level7Controller : MonoBehaviour
{
    [Header("Backgrounds")]
    [SerializeField] private GameObject RoomBackground;

    [Header("Buttons")]
    [SerializeField] private GameObject ZoominButton;
    [SerializeField] private GameObject ZoomoutButton;
    [SerializeField] private GameObject MeterkastButton;

    [Header("Texts")]
    [SerializeField] private GameObject[] InstructionTexts;

    [Header("DropElements")]
    [SerializeField] private GameObject DropElements;

    [Header("SlideController Data")]
    public GameObject   Slides;
    public GameObject[] SlidesList;
    public static int   SlidesLength;
    public static int   ShowSlide;
    public GameObject   Electricity;

    [Header("Misc")]
    [SerializeField] private bool isZoomedIn;
    [SerializeField] private bool isThePowerOff;
    [SerializeField] public static bool WentToTurnOffPower;
    [SerializeField] public static List<bool> CurrentStateSwitches;

    // Start is called before the first frame update
    void Start()
    {
        Setuplevel();
    }

    // Update is called once per frame
    void Update()
    {
        PowerCheck();
        SlideUpdater();
    }
    /// <summary>
    /// turns off all the texts in the list
    /// </summary>
    private void TurnTextOff()
    {
        for (int i = 0; i < InstructionTexts.Count(); i++)
        {
            InstructionTexts[i].SetActive(false);
        }
    }
    /// <summary>
    /// To transition so the to use the tools and wires section
    /// turning off the level background and turning the wire ones on to transition between them
    /// with dynamic text for each text between them
    /// </summary>
    public void ZoomIn()
    {
        RoomBackground.SetActive(false);
        ZoominButton.SetActive(false);
        MeterkastButton.SetActive(false);
        ZoomoutButton.SetActive(true);
        PowerDisplay();
        Slides.SetActive(true);
        SetZoomInText();
        isZoomedIn = !isZoomedIn;
    }
    /// <summary>
    /// this is method sets a warning text for when the player goes to fix the wires without turning off the power
    /// </summary>
    private void SetZoomInText()
    {
        TurnTextOff();
        if (isThePowerOff)
        {
            InstructionTexts[ShowSlide].SetActive(true);
        }
        else
        {
            InstructionTexts[9].SetActive(true);
        }
    }
    /// <summary>
    /// To transition so the open room section
    /// turning off the tools and wires background and turning the to open room transition between them
    /// with dynamic text for each text between them
    /// </summary>
    public void ZoomOut()
    {
        RoomBackground.SetActive(true);
        ZoominButton.SetActive(true);
        MeterkastButton.SetActive(true);
        DropElements.SetActive(false);
        ZoomoutButton.SetActive(false);
        Slides.SetActive(false);
        Electricity.SetActive(false);
        SetZoomOutText();
        isZoomedIn = !isZoomedIn;
    }
    /// <summary>
    /// text outside the the hole in the wall
    /// </summary>
    private void SetZoomOutText()
    {
        TurnTextOff();
        if (isThePowerOff)
        {
            InstructionTexts[8].SetActive(true);
        }
        else
        {
            InstructionTexts[7].SetActive(true);
        }
    }
    /// <summary>
    /// the check that make you able to fix the wires.
    /// </summary>
    private void PowerDisplay()
    {
        if (isThePowerOff)
        {
            DropElements.SetActive(true);
        }
        else
        {
            Electricity.SetActive(true);
        }
    }
    /// <summary>
    /// the check that makes sure the power is off.
    /// </summary>
    private void PowerCheck()
    {
        if (WentToTurnOffPower)
        {
            UpdateSwitches();
            if (CurrentStateSwitches[8] == true)
            {
                isThePowerOff = true;
                MeterkastButton.SetActive(false);
                if (!isZoomedIn)
                {
                    SetZoomOutText();
                }
                else
                {
                    InstructionTexts[8].SetActive(false);
                    InstructionTexts[7].SetActive(false);
                }
            }
        }
    }
    /// <summary>
    /// Updates the state off the switches off the meterkast to check.
    /// </summary>
    public static void UpdateSwitches()
    {
        if (MeterkastController.CurrentStateSwitches != null)
        {
            CurrentStateSwitches.Clear();
            for (int i = 0; i < MeterkastController.CurrentStateSwitches.Count; i++)
            {
                CurrentStateSwitches.Add(MeterkastController.CurrentStateSwitches[i]);
            }
        }
    }
    /// <summary>
    /// This is method that changes the the background while fixing the level(only on good inputs).
    /// also updates the texts to the level state to guide the player
    /// </summary>
    private void SlideUpdater()
    {
        if (isZoomedIn)
        {
            for (int i = 0; i < SlidesLength; i++) //Only show the slide with number of 'show'
            {
                if (i != ShowSlide)
                {
                    SlidesList[i].GetComponent<Image>().enabled = false; //Dont show other slide images
                    InstructionTexts[i].SetActive(false); //Dont show other slide texts
                }
                else
                {
                    SlidesList[i].GetComponent<Image>().enabled = true; //Show current slide image
                    if (isThePowerOff)
                    {
                        InstructionTexts[i].SetActive(true);
                    }
                }
            }
            if (SlidesList[SlidesLength - 1].GetComponent<Image>().enabled == true) //If last slide is reached, load next scene
            {
                GetComponent<SceneLoader>().LoadScene();
            }
        }
    }
    /// <summary>
    /// moves the slide along with the good inputs
    /// </summary>
    public static void PlusOne() //Next slide
    {
        if (ShowSlide < SlidesLength)
        {
            ShowSlide += 1;
        }
    }
    /// <summary>
    /// this method sets up everything so the level is playable at the beginning of the level
    /// </summary>
    private void Setuplevel()
    {
        ShowSlide = 0;
        SlidesLength = SlidesList.Length;
        isZoomedIn = false;
        MeterkastController.CurrentLevel = 7;
        if (!WentToTurnOffPower)
        {
            CurrentStateSwitches = new List<bool> { false, false, false, false, false, false, false, false, false };
            MeterkastController.SetupList(CurrentStateSwitches);
        }
    }
    /// <summary>
    /// this method is the scene loader for when the player is going to the Meterkast
    /// making sure to pass the " MeterkastController.CurrentLevel = 7 " so it sets up the meterkast specifically for this level
    /// </summary>
    public void LoadMeterkast()
    {
        WentToTurnOffPower = true;
        MeterkastController.CurrentLevel = 7;
        if ("Meterkast" != null && "Meterkast" != "")
        {
            print("Loaded scene: " + "Meterkast");
            SceneManager.LoadScene("Meterkast"); //Load scene with this name
        }
    }
    /// <summary>
    /// this method is the scene loader for when the player finishes the level and goes to see the results
    /// </summary>
    public void LoadLevelComplete()
    {
        if ("Level7Complete" != null && "Level7Complete" != "")
        {
            print("Loaded scene: " + "Level7Complete");
            SceneManager.LoadScene("Level7Complete"); //Load scene with this name
        }
    }

    /// <summary>
    /// ENGLISH:
    ///My contribution to the project was level 7 and the meterkast.
    /// I didn't change much from the main project. 
    /// The changes i made outside my two additions were:

    ///   Increasing the level cap to ten, because I did not know how many levels we were going to make.
    ///   In the main game, i added my own stamp to enter my level (level 7).
    ///   Putting a lock requirement to my level.
    ///   On the pause screen, it will show my level's score.

    ///   I went through three iterations of concepts for my level. 
    ///   All hand drawn by me, which took some time, because I am not an artist and I had to plan out ahead.What we should see in the level and what the step by step for the level should be.
    ///   Most of the time for development went to level design and since I don't have a lot of knowledge for Electra, it took longer than it should.
    ///   The first level design;
    ///   We wanted to do a level where the player was just going to fix a lamp.We scrapped that. Then we knew we wanted to do a "fix the few wires level" that would cause like an electrical malfunction, but we did not know how exactly to do it.So I went and made it, just the player fixing the wires with tape. By connecting the wires and then taping them back up, but then we noticed that it didn't seem professional. So we did the Solution the right way, by adding a Kroonsteen and having that be the connector between the wires and then use like screwing the wires back together. 
    ///
    ///   I also made it a meterkast in between levels. It was made in mind that others developers were supposed to use it.I reused assets from previous levels that were already in the game. This made it that I could finish this level really quickly and that the art would be in line with the game. As it stands, the only level that was is using the Meterkast (the in between level) is my own level.We knew we wanted to draw attention to safety for my level since we were fixing live electrical wires, so we wanted this level to be made. This way, we would have the player turn off the power each time they would need to deal with something this dangerous.
    /// 
    /// DUTCH:
    /// 
    ///Mijn bijdrage aan het project was niveau 7 en de meterkast.
    /// Ik heb niet veel veranderd ten opzichte van het hoofdproject.
    /// De wijzigingen die ik heb aangebracht buiten mijn twee toevoegingen waren:

    ///    De level cap verhogen naar tien, omdat ik niet wist hoeveel levels we gingen maken.
    ///    In het hoofdspel heb ik mijn eigen stempel toegevoegd om mijn niveau in te voeren (niveau 7).
    ///    Een slotvereiste op mijn niveau zetten.
    ///    Op het pauzescherm wordt de score van mijn niveau weergegeven.

    ///    Ik heb drie iteraties van concepten voor mijn niveau doorlopen.
    ///    Allemaal met de hand getekend door mij, wat wat tijd kostte, omdat ik geen artiest ben en ik vooruit moest plannen. Wat we in het niveau zouden moeten zien en wat de stap voor stap voor het niveau zou moeten zijn.
    ///    De meeste tijd voor ontwikkeling ging naar levelontwerp en aangezien ik niet veel kennis heb van Electra, duurde het langer dan zou moeten.
    ///    Het ontwerp op het eerste niveau;
    ///    We wilden een level doen waarbij de speler gewoon een lamp ging repareren.Dat hebben we geschrapt.Toen wisten we dat we een "reparatie van de paar draden niveau" wilden doen die een elektrische storing zou veroorzaken, maar we wisten niet hoe we het precies moesten doen. Dus ik ging en maakte het, alleen de speler die de draden met tape vastmaakte.Door de draden aan te sluiten en daarna weer vast te tapen, maar toen merkten we dat het niet professioneel overkwam.Dus we hebben de oplossing op de juiste manier gedaan, door een Kroonsteen toe te voegen en dat de connector tussen de draden te laten zijn en vervolgens de draden weer in elkaar te schroeven.

    ///    Ik heb er ook een meterkast tussen gemaakt. Er werd rekening mee gehouden dat andere ontwikkelaars het moesten gebruiken.Ik heb middelen van eerdere niveaus hergebruikt die al in het spel zaten.Dit zorgde ervoor dat ik dit level heel snel kon afmaken en dat de art in lijn zou zijn met de game. Zoals het er nu uitziet, is het enige niveau dat gebruik maakte van de Meterkast (het tussenniveau) mijn eigen niveau. We wisten dat we de aandacht wilden vestigen op veiligheid voor mijn niveau, aangezien we stroomvoerende draden aan het repareren waren, dus we wilden dat dit niveau gemaakt werd. Op deze manier zouden we de speler de stroom laten uitschakelen elke keer dat hij met zoiets gevaarlijks te maken zou krijgen.
    /// </summary>
}
