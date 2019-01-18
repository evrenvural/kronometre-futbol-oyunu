using UnityEngine;
using UnityEditor;
using System;

public class AiryUIAnchorsEditorWindow : EditorWindow
{
    private static EditorWindow window;

    [MenuItem("Airy UI/Anchors Window &%r", priority = 1)]
    private static void ShowWindow()
    {
        window = GetWindow<AiryUIAnchorsEditorWindow>("Anchors Editor");
        window.Show();
        window.maxSize = new Vector2(270, 520);
        window.minSize = new Vector2(270, 520);
    }

    private void OnGUI()
    {
        GUI.color = Color.gray;

        WindowTitle_LABEL();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.cyan;

        SetAnchorsToFitRect();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.magenta;

        SetAnchorsCenterOfRect();
        SetAnchorsTopRight();
        SetAnchorsTopLeft();
        SetAnchorsBottomRight();
        SetAnchorsBottomLeft();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.yellow;

        SetRectToAnchorSelectedGameObject();
    }

    private void WindowTitle_LABEL()
    {
        GUILayout.Space(10);

        var titleLabelStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperCenter, fontSize = 30, fontStyle = FontStyle.Bold, fixedHeight = 50 };

        EditorGUILayout.LabelField("Anchors Editor", titleLabelStyle);
        EditorGUILayout.Space(); EditorGUILayout.Space(); EditorGUILayout.Space();

        GUILayout.Space(30);
    }

    private static void SetAnchorsToFitRect()
    {
        var btnContent = new GUIContent() { text = "Align Anchors With Rect\nCtrl+Shift+Q", tooltip = "Move Anchors to be aligned with the rect" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetAnchorsToRect(rectTransform);
                }
            }
        }

        GUILayout.Label("Note: You may need to click twice to fit the anchors if the pivot is not centered", new GUIStyle() { alignment = TextAnchor.MiddleCenter, wordWrap = true });

        GUILayout.Space(20);
    }

    [MenuItem("Airy UI/Anchors/Set Anchors To Fit Rect %#q", priority = 2)]
    public static void SetAnchorsToFitRect_Shortcut()
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        foreach (var g in selectedGameObjects)
        {
            RectTransform rectTransform = g.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                AiryUIAnchors.SetAnchorsToRect(rectTransform);
            }
        }
    }

    private void SetAnchorsCenterOfRect()
    {
        var btnContent = new GUIContent() { text = "Set Anchors To Center Of Rect", tooltip = "Move Anchors to the center of the rect" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetAnchorsCenterOfRect(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsTopRight()
    {
        var btnContent = new GUIContent() { text = "Set Anchors Top Right", tooltip = "Move Anchors to top right of the rect" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetAnchorsTopRight(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsTopLeft()
    {
        var btnContent = new GUIContent() { text = "Set Anchors Top Left", tooltip = "Move Anchors to top left of the rect" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetAnchorsTopLeft(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsBottomRight()
    {
        var btnContent = new GUIContent() { text = "Set Anchors Bottom Right", tooltip = "Move Anchors to bottom right of the rect" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetAnchorsBottomRight(rectTransform);
                }
            }
        }
    }

    private void SetAnchorsBottomLeft()
    {
        var btnContent = new GUIContent() { text = "Set Anchors Bottom Left", tooltip = "Move Anchors to bottom left of the rect" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetAnchorsBottomLeft(rectTransform);
                }
            }
        }

        GUILayout.Space(20);
    }

    private static void SetRectToAnchorSelectedGameObject()
    {
        var btnContent = new GUIContent() { text = "Align Rect To Anchors\nCtrl+Shift+W", tooltip = "Align The Rect's borders With The Anchors" };

        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (var g in selectedGameObjects)
            {
                RectTransform rectTransform = g.GetComponent<RectTransform>();

                if (rectTransform != null)
                {
                    AiryUIAnchors.SetRectToAnchor(rectTransform);
                }
            }
        }

        GUILayout.Space(5);
    }

    [MenuItem("Airy UI/Anchors/Align Selected To Anchors %#w", priority = 2)]
    public static void SetRectToAnchorSelectedGameObject_Shortcut()
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        foreach (var g in selectedGameObjects)
        {
            RectTransform rectTransform = g.GetComponent<RectTransform>();

            if (rectTransform != null)
            {
                AiryUIAnchors.SetRectToAnchor(rectTransform);
            }
        }
    }

    private void CloseButton()
    {
        var btnContent = new GUIContent() { text = "Close", tooltip = "Close this editor window" };
        if (GUILayout.Button(btnContent, GUILayout.Height(50)))
        {
            window.Close();
        }

        GUILayout.Space(5);
    }
}