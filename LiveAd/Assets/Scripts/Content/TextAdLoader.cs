using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class TextAdLoader : MonoBehaviour
{
    public Text title;
    public Text textContent;
    public Button nextElement;
    public Button prevElement;
    public string ContentName;

    private TextContent content;
    private int currentElement = 0;
    private int elementCount;

    // Use this for initialization
    void Start()
    {       
        content = ContentManager.Instance.GetContent(ContentName) as TextContent;
        if (content == null) {
            //throw new Exception("Incorrect content");
            title.text = "Incorrect content";
            textContent.text = "";
        } else {
            title.text = content.Title;
            textContent.text = content.Content[currentElement];
            elementCount = content.Content.Length;
            if(elementCount <= 1) {
                prevElement.gameObject.SetActive(false);
                nextElement.gameObject.SetActive(false);
            }
        }
    }

    public void NextElement()
    {
        currentElement = (++currentElement) % elementCount;
        textContent.text = content.Content[currentElement];
    }

    public void PrevElement()
    {
        currentElement = (currentElement - 1 >= 0) ? currentElement - 1 : elementCount - 1;
        textContent.text = content.Content[currentElement];
    }
}
