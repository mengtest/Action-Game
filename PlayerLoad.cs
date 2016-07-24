using UnityEngine;
using System.Collections;

public class PlayerLoad : MonoBehaviour
{
    public Color purple;
    public SkinnedMeshRenderer headRenderer;
    public SkinnedMeshRenderer handRenderer;
    public SkinnedMeshRenderer upperbodyRenderer;
    public SkinnedMeshRenderer lowerbodyRenderer;
    public SkinnedMeshRenderer footRenderer;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        int headMeshIndex = PlayerPrefs.GetInt("HeadMeshIndex");
        int handMeshIndex = PlayerPrefs.GetInt("HandMeshIndex");
        int upperbodyMeshIndex = PlayerPrefs.GetInt("UpperbodyMeshIndex");
        int lowerbodyMeshIndex = PlayerPrefs.GetInt("LowerbodyMeshIndex");
        int footMeshIndex = PlayerPrefs.GetInt("FootMeshIndex");
        int colorIndex = PlayerPrefs.GetInt("ColorIndex");

        headRenderer.sharedMesh = MenuController.instance.headMeshArray[headMeshIndex];
        handRenderer.sharedMesh = MenuController.instance.handMeshArray[handMeshIndex];
        upperbodyRenderer.sharedMesh = MenuController.instance.upperbodyMeshArray[upperbodyMeshIndex];
        lowerbodyRenderer.sharedMesh = MenuController.instance.lowerbodyMeshArray[lowerbodyMeshIndex];
        footRenderer.sharedMesh = MenuController.instance.footMeshArray[footMeshIndex];

        ChangeColor(MenuController.instance.colorArray[colorIndex]);
    }

    void ChangeColor(Color color)
    {
        headRenderer.material.color = color;
        handRenderer.material.color = color;
        upperbodyRenderer.material.color = color;
        lowerbodyRenderer.material.color = color;
        footRenderer.material.color = color;
    }
}
