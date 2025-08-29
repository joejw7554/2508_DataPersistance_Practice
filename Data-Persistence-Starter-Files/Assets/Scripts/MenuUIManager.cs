using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInputField;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButtonClicked()
    {
        if(nameInputField)
        {
            DataManager.Instance.playerName = nameInputField.text;

        }


        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
