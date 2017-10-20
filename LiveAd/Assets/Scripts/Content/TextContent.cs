using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "LiveAd/Content/Text")]
public class TextContent : Content
{
    public string Title;
    public string[] Content; 


    protected override ContentType GetContentType()
    {
        return ContentType.Text;
    }  

}
