using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContentType {PostersList, Vidio, ModelsList, Text}

public abstract class Content : ScriptableObject {
    private ContentType contentType;
    public ContentType Type {
        get { return GetContentType(); }
    }
    public string Name { get; private set; }

    protected abstract ContentType GetContentType();
}
