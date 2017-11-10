using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    struct DialogLine
    {
        public string name;
        public string emote;
        public string face;
        public string dialog;

        public DialogLine(string Name, string Emote, string Face, string Dialog)
        {
            name = Name;
            emote = Emote;
            face = Face;
            dialog = Dialog;
        }
    }

    [Space(10)]
    public GameObject textBox;
    [Space(10)]
    public Text dialogText;
    [Space(10)]
    public Image charImage;
    [Space(10)]
    public Image emoteImage;
    [Space(10)]
    public Text charName;
    [Space(10)]
    public TextAsset textFile;

    private string[] textLine;
    private string[] textParse;
    private DialogLine[] dialogInfo;
    [Space(10)]
    public int currentLine;
    public int endLine;
    [Space(10)]
    private bool isTyping = false;
    private bool cancelTyping = false;
    [Space(10)]
    public float typeSpeed;
	[Space(10)]
	public UnityEngine.Events.UnityEvent onEnd;

    private string characterPath = "CharacterSprites/";

	void Start ()
    {
        if (textFile != null)
        {                
            textParse = (textFile.text.Split('\n'));
            dialogInfo = new DialogLine[textParse.Length];

            for (int i = 0; i < textParse.Length ; i++)
            {
                textLine = (textParse[i].Split(':'));
                dialogInfo[i] = new DialogLine(textLine[0], textLine[1], textLine[2], textLine[3]);
            }           
        }        
        if (endLine == 0)
        {
            endLine = dialogInfo.Length - 1;
        }

        switchImage();
        StartCoroutine(TextScroll(dialogInfo[currentLine].dialog));

    }
		
	void Update ()
    {
    
        
	}

    public void NextText()
    {
        if (!isTyping)
        {
            currentLine += 1;

			if (currentLine > endLine)
			{
				currentLine = endLine;
				onEnd.Invoke();
			}
			else
            {
                switchImage();
                StartCoroutine(TextScroll(dialogInfo[currentLine].dialog));
            }
        }
        else if (isTyping && !cancelTyping)
        {
            cancelTyping = true;
        }
    }

    private void switchImage()
    {
        if (dialogInfo[currentLine].name == "narrator")
        {
            charName.text = "";
            charImage.GetComponent<Image>().enabled = false;
        }
        else
        {
            charName.text = dialogInfo[currentLine].name;
            Sprite newSprite = Resources.Load<Sprite>(characterPath + dialogInfo[currentLine].name + "/" + dialogInfo[currentLine].face);
            charImage.GetComponent<Image>().enabled = true;
            charImage.GetComponent<Image>().sprite = newSprite;
        }

        if (dialogInfo[currentLine].emote == "none")
        {
            emoteImage.GetComponent<Image>().enabled = false;
        }
        else
        {
            Sprite tempSprite = Resources.Load<Sprite>(characterPath + dialogInfo[currentLine].name + "/" + dialogInfo[currentLine].emote);
            emoteImage.GetComponent<Image>().enabled = true;
            emoteImage.GetComponent<Image>().sprite = tempSprite;
        }
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        dialogText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            dialogText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }
}
