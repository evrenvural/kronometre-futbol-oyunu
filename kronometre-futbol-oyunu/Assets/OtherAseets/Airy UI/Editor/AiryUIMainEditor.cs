using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class AiryUIMainEditor : EditorWindow
{
    private static EditorWindow window;

    [MenuItem("Airy UI/Main Editor &%e", priority = 0)]
    private static void ShowWindow()
    {
        window = GetWindow<AiryUIMainEditor>("Airy UI");
        window.Show();
        window.maxSize = new Vector2(325, 500);
        window.minSize = new Vector2(325, 500);
    }

    private void OnGUI()
    {
        GUI.color = Color.gray;

        WindowTitle_LABEL();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.cyan;

        AddRemoveAnimationManager_BUTTONS();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.magenta;

        AddRemoveAnimation_BUTTONS();

        GUI.color = Color.white;
        GUI.backgroundColor = Color.blue;

        AddRemoveBackBtn_BUTTONS();
    }

    private void WindowTitle_LABEL()
    {
        GUILayout.Space(10);

        var titleLabelStyle = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.UpperCenter, fontSize = 25, fontStyle = FontStyle.Bold, fixedHeight = 50 };

        EditorGUILayout.LabelField("Airy UI Main Window", titleLabelStyle);
        GUILayout.Space(50);
    }

    private void AddRemoveAnimationManager_BUTTONS()
    {
        if (GUILayout.Button("Add Animation Manager", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIAnimationManager>() == null)
                {
                    g.AddComponent<AiryUIAnimationManager>();
                }
            }
        }
        if (GUILayout.Button("Remove Animation Manager", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIAnimationManager>() != null)
                    DestroyImmediate(g.GetComponent<AiryUIAnimationManager>());
            }
        }

        GUILayout.Space(20);
    }

    private void AddRemoveAnimation_BUTTONS()
    {
        if (GUILayout.Button("Add Animated Element", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIAnimatedElement>() == null)
                {
                    g.AddComponent<AiryUIAnimatedElement>();
                }
            }
        }
        if (GUILayout.Button("Add Custom Animated Element", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUICustomAnimationElement>() == null)
                {
                    g.AddComponent<AiryUICustomAnimationElement>();
                }
            }
        }
        if (GUILayout.Button("Remove Animated Element", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIAnimatedElement>() != null)
                    DestroyImmediate(g.GetComponent<AiryUIAnimatedElement>());

                if (g.GetComponent<AiryUICustomAnimationElement>() != null)
                    DestroyImmediate(g.GetComponent<AiryUICustomAnimationElement>());
            }
        }

        GUILayout.Space(20);
    }

    private void AddRemoveAnchor_BUTTONS()
    {
        if (GUILayout.Button("Add Anchor Controller", GUILayout.Height(100)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIAnchors>() == null)
                {
                    g.AddComponent<AiryUIAnchors>();
                }
            }
        }

        if (GUILayout.Button("Remove Anchor Controller", GUILayout.Height(100)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIAnchors>() != null)
                    DestroyImmediate(g.GetComponent<AiryUIAnchors>());
            }
        }

        GUILayout.Space(20);
    }

    private void AddRemoveBackBtn_BUTTONS()
    {
        if (GUILayout.Button("Add Back Button Functionality", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIBackButton>() == null)
                {
                    g.AddComponent<AiryUIBackButton>();
                }
            }
        }

        if (GUILayout.Button("Remove Back Button Functionality", GUILayout.Height(50)))
        {
            foreach (GameObject g in Selection.gameObjects)
            {
                if (g.GetComponent<AiryUIBackButton>() != null)
                    DestroyImmediate(g.GetComponent<AiryUIBackButton>());
            }
        }

        GUILayout.Space(20);
    }

    private void CloseWindow_BUTTON()
    {
        GUILayout.BeginVertical();
        if (GUILayout.Button("Close", GUILayout.Height(100)))
        {
            window.Close();
        }
        GUILayout.EndVertical();
    }
}