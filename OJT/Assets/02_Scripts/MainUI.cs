using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    [SerializeField] GameObject loginUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] InputField inputField;
    [SerializeField] Text textWarning;
    [SerializeField] Button btnLogin;
    string inputID;
    void Start()
    {
        SetListener();
        btnLogin.interactable = false;
    }

    void SetListener()
    {
        // ��ǲ�ʵ�
        inputField.characterLimit = 8;
        inputField.onValueChanged.AddListener((s) => CheckInputfieldText(s));
        // �ؽ�Ʈ
        textWarning.text = "4�ڸ� �̻��� id�� �Է��ϼ���";
        // ��ư
        btnLogin.onClick.AddListener(() => OnClickLoginBtn());
    }

    void CheckInputfieldText(string inputText)
    {
        if(inputText.Length >= 4)
        {
            btnLogin.interactable = true;
            textWarning.text = "�α����� �����մϴ�";
        }
        inputID = inputText;
    }
    void OnClickLoginBtn()
    {
        loginUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        PlayerPrefs.SetString("ID", inputID.ToString());
    }

}
