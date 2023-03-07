using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private GameObject player;
    private GameObject pet;
    
    private Vector3 petOffset = new Vector3(1.5f, 0f, -0.5f);


    void Start()
    {
        LoadMap();
        LoadCharacter();
        LoadPet();
    }

    void LoadMap()
    {

    }

    void LoadCharacter()
    {
        GameObject playerObj = Resources.Load<GameObject>("Player");
        player =  Instantiate(playerObj, playerTransform.position, playerTransform.rotation) as GameObject;
        // 카메라 연결
        Camera camera = Camera.main;
        CameraFollow follow = Camera.main.GetComponent<CameraFollow>();
        follow.SetTarget(player.transform);
    }

    void LoadPet()
    {
        GameObject petObj = Resources.Load<GameObject>("Pet");
        Vector3 petTransform = playerTransform.position + petOffset;
        pet = Instantiate(petObj, petTransform, playerTransform.rotation) as GameObject;

        PetMove petMove = pet.GetComponent<PetMove>();
        petMove.SetPlayerObj(player);
    }


}
