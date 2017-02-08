using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ShowUI : MonoBehaviour
{
    public static ShowUI instance;
    public UILabel countUI;
    public int count = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (MenuController.instance.gameType == GameType.Endless)
        {
            countUI.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (MenuController.instance.gameType == GameType.Endless)
        {
            countUI.text = "您已杀死 " + count + " 只怪物.";
        }
    }

    public void OnBackBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
