using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSetting : MonoBehaviour
{
    [SerializeField] Text userID;

    private void Awake()
    {
        userID.text = PlayerPrefs.GetString("ID");
    }
}
