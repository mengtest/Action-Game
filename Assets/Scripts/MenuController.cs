using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum GameType
{
    Easy,
    Endless
}

public enum ColorType
{
    White,
    Blue,
    Cyan,
    Green,
    Purple,
    Red
}

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    public GameType gameType = GameType.Easy;
    public Color purple;
    public SkinnedMeshRenderer headRenderer;
    public SkinnedMeshRenderer handRenderer;
    public SkinnedMeshRenderer upperbodyRenderer;
    public SkinnedMeshRenderer lowerbodyRenderer;
    public SkinnedMeshRenderer footRenderer;
    public Mesh[] headMeshArray;
    public Mesh[] handMeshArray;
    public Mesh[] upperbodyMeshArray;
    public Mesh[] lowerbodyMeshArray;
    public Mesh[] footMeshArray;
    public Color[] colorArray;
    private int headMeshIndex = 0;
    private int handMeshIndex = 0;
    private int upperbodyMeshIndex = 0;
    private int lowerbodyMeshIndex = 0;
    private int footMeshIndex = 0;
    private int colorIndex = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        colorArray = new Color[6] { Color.white, Color.blue, Color.cyan, Color.green, purple, Color.red };
        DontDestroyOnLoad(gameObject);
    }

    public void OnEasyBtnClick()
    {
        gameType = GameType.Easy;
    }

    public void OnEndlessBtnClick()
    {
        gameType = GameType.Endless;
    }

    public void OnQuitBtnClick()
    {
        Application.Quit();
    }

    public void OnHeadMeshNext()
    {
        headMeshIndex++;
        headMeshIndex %= headMeshArray.Length;
        headRenderer.sharedMesh = headMeshArray[headMeshIndex];
    }

    public void OnHandMeshNext()
    {
        handMeshIndex++;
        handMeshIndex %= handMeshArray.Length;
        handRenderer.sharedMesh = handMeshArray[handMeshIndex];
    }

    public void OnUpperbodyMeshNext()
    {
        upperbodyMeshIndex++;
        upperbodyMeshIndex %= upperbodyMeshArray.Length;
        upperbodyRenderer.sharedMesh = upperbodyMeshArray[upperbodyMeshIndex];
    }

    public void OnLowerbodyMeshNext()
    {
        lowerbodyMeshIndex++;
        lowerbodyMeshIndex %= lowerbodyMeshArray.Length;
        lowerbodyRenderer.sharedMesh = lowerbodyMeshArray[lowerbodyMeshIndex];
    }

    public void OnFootMeshNext()
    {
        footMeshIndex++;
        footMeshIndex %= footMeshArray.Length;
        footRenderer.sharedMesh = footMeshArray[footMeshIndex];
    }

    public void OnBlueBtnClick()
    {
        colorIndex = (int)ColorType.Blue;
        ChangeColor(Color.blue);
    }

    public void OnCyanBtnClick()
    {
        colorIndex = (int)ColorType.Cyan;
        ChangeColor(Color.cyan);
    }

    public void OnGreenBtnClick()
    {
        colorIndex = (int)ColorType.Green;
        ChangeColor(Color.green);
    }

    public void OnPurpleBtnClick()
    {
        colorIndex = (int)ColorType.Purple;
        ChangeColor(purple);
    }

    public void OnRedBtnClick()
    {
        colorIndex = (int)ColorType.Red;
        ChangeColor(Color.red);
    }

    public void OnWhiteBtnClick()
    {
        colorIndex = (int)ColorType.White;
        ChangeColor(Color.white);
    }

    void ChangeColor(Color color)
    {
        headRenderer.material.color = color;
        handRenderer.material.color = color;
        upperbodyRenderer.material.color = color;
        lowerbodyRenderer.material.color = color;
        footRenderer.material.color = color;
    }

    void Save()
    {
        PlayerPrefs.SetInt("HeadMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("HandMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("UpperbodyMeshIndex", upperbodyMeshIndex);
        PlayerPrefs.SetInt("LowerbodyMeshIndex", lowerbodyMeshIndex);
        PlayerPrefs.SetInt("FootMeshIndex", footMeshIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }

    public void OnPlayBtnClick()
    {
        Save();
        SceneManager.LoadScene(1);
    }
}
