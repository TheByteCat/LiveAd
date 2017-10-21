using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContentType {Posters, Vidio, Models, Text}

public abstract class Content : ScriptableObject {
    public ContentType Type {
        get { return GetContentType(); }
    }
    public string Name;

    protected abstract ContentType GetContentType();
}
