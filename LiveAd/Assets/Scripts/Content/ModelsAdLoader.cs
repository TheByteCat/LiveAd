using UnityEngine;
using UnityEngine.UI;
using System;

public class ModelsAdLoader : MonoBehaviour
{
    public Text title;
    public Button nextElement;
    public Button prevElement;
    public Transform modelsContainer;
    public string ContentName;

    private ModelsContent content;
    private GameObject[] elements;
    private int currentElement = 0;
    private int elementCount;

    // Use this for initialization
    void Start()
    {
        content = ContentManager.Instance.GetContent(ContentName) as ModelsContent;
        if (content == null) {
            //throw new Exception("Incorrect content");
            title.text = "Incorrect content";
        } else {
            title.text = content.Title;
            elementCount = content.Content.Length;
            if (elementCount <= 1) {
                prevElement.gameObject.SetActive(false);
                nextElement.gameObject.SetActive(false);
            }
            elements = new GameObject[elementCount];
            for (int i = 0; i < elementCount; i++) {
                GameObject m = Instantiate(content.Content[i], modelsContainer);
                m.SetActive(false);
                elements[i] = m;
            }
            elements[currentElement].SetActive(true);
        }
    }

    public void NextElement()
    {
        elements[currentElement].SetActive(false);
        currentElement = (++currentElement) % elementCount;
        elements[currentElement].SetActive(true);
    }

    public void PrevElement()
    {
        elements[currentElement].SetActive(false);
        currentElement = (currentElement - 1 >= 0) ? currentElement - 1 : elementCount - 1;
        elements[currentElement].SetActive(true);
    }
}
