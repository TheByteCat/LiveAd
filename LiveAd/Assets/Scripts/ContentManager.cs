﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ContentManager : MonoBehaviour
{
    private static ContentManager instance;
    private static Dictionary<string, Content> content = new Dictionary<string, Content>();
    private static string path = "/Content";

    public static ContentManager Instance
    {
        get
        {
#if UNITY_EDITOR
            if (instance == null) {
                instance = FindObjectOfType<ContentManager>();

                if (instance == null) {
                    GameObject container = new GameObject("ContentManager");
                    instance = container.AddComponent<ContentManager>();
                    DontDestroyOnLoad(container);
                }
            }
#endif
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(transform.root.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        var data = Resources.LoadAll<Content>(path);
        content = data.ToDictionary(x => x.Name);
    }
}
