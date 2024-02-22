using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime; // Ink is a addon that makes it easier to make dialogue.
using UnityEngine.EventSystems;


public class DialogueManager : MonoBehaviour
{
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [SerializeField] private GameObject player;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;

    [Header("Global Ink File")]

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject continueIcon;

    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Animator portraitAnimator;
    private Animator layoutAnimator;
    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying;

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private DialogueVariables dialogueVariables;

   
    
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mulitple DialogManager");
        }
        instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);

    }
    
    public static DialogueManager GetInstance()
    {
        return instance;
    }
    
    private void Start()
    {
        // Closes dielog panel so it is not open on start.
        dialogueIsPlaying = false; 
        dialoguePanel.SetActive(false);
        
        layoutAnimator = dialoguePanel.GetComponent<Animator>();

        // Gets choices(Buttons)
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        // Return if dialogue isn't playing
        if (!dialogueIsPlaying)
        {
            return;
        }
        // Continue to next line if button pressed.
        if (canContinueToNextLine 
            && Input.GetKeyDown(KeyCode.Space) 
            && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
        if (canContinueToNextLine
            && Input.GetKeyDown(KeyCode.Mouse0)
            && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
        if (canContinueToNextLine
            && Input.GetKeyDown(KeyCode.E)
            && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON) // Gets the new "story" and enables the dialoguepanel.
    {
        
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        player.GetComponent<PlayerMove>().enabled = false;
        dialogueVariables.StartListening(currentStory);
        //reset
        displayNameText.text = "???";
        portraitAnimator.Play("default");
        layoutAnimator.Play("right");

        ContinueStory();


    }

    
    private IEnumerator ExitDialogueMode() // Disables dialoguepanel and resets text(story).
    {
        yield return new WaitForSeconds(0.2f);
        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        player.GetComponent<PlayerMove>().enabled = true;
        

    }

    private void ContinueStory() // Checks if story can continue. Continue if possible else exit dialogue mode.
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line) 
    {
        // Resets text and hides choices and continue icon. 
        dialogueText.text = "";

        continueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;
        // Makes the text look like it's writing itself.
        foreach (char letter in line.ToCharArray())
        {
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            
        }
        continueIcon.SetActive(true);
        DisplayChoices();

        canContinueToNextLine = true;
    }

    private void HideChoices() 
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        // Loop and handle every tag.
        foreach (string tag in currentTags)
        {
            // Pars tag
            string[] splitTag = tag.Split(":");
            if (splitTag.Length != 2)
            {
                Debug.LogError("This aint workin:" + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            // Handle tag.
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag (" + tag + ") not being handled");
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        // Checks so theres enough choices for the "story".
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too little choice woppsie");
        }

        int index = 0;
        // Enables enough choices for the "story"
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // Hide the choices that are not necessary.
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Waite for a frame so thatc can set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        
    }
    public void MakeChoice(int choiceIndex)
    {
        // Continue story
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        
    }
    
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("INk varible null:" + variableName);
        }
        return variableValue;
    }
    

}
