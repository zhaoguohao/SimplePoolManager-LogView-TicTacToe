using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Appload
{
    static Appload()
    {
        bool hasKey = PlayerPrefs.HasKey("zgh");
        if (hasKey == false)
        {
            PlayerPrefs.SetInt("zgh", 1);
            WelcomeScreen.ShowWindow();
        }
    }
}

public class WelcomeScreen : EditorWindow
{
    private Texture mSamplesImage;
    private Rect imageRect = new Rect(30f, 90f, 350f, 350f);
    private Rect textRect = new Rect(15f, 15f, 380f, 100f);

    public void OnEnable()
    {
        mSamplesImage = LoadTexture("zgh.png");
    }


    Texture LoadTexture(string name)
    {
        string path = "Assets/Unity-Logs-Viewer/Reporter/Editor/";
        return (Texture)AssetDatabase.LoadAssetAtPath(path + name, typeof(Texture));
    }

    public void OnGUI()
    {
        GUIStyle style = new GUIStyle
        {
            fontSize = 14,
            normal = { textColor = Color.green }
        };

        if (mSamplesImage == null)
        {
            mSamplesImage = LoadTexture("zgh.jpg");
        }

        GUI.Label(textRect, "如果该项目对你有用，记得帮我点一下Star哟\n这个页面只会显示一次奥", style);
        GUI.DrawTexture(imageRect, mSamplesImage);
    }

    public static void ShowWindow()
    {
        WelcomeScreen window = GetWindow<WelcomeScreen>(true, "本项目仅用于学习交流，如有侵权请及时联系我昂");
        window.minSize = window.maxSize = new Vector2(410f, 470f);
        DontDestroyOnLoad(window);
    }
}


