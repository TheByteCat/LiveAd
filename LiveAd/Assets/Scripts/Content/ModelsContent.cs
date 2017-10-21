using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "LiveAd/Content/Models")]
public class ModelsContent : Content
{
    public string Title;
    public GameObject[] Content;


    protected override ContentType GetContentType()
    {
        return ContentType.Models;
    }

}
