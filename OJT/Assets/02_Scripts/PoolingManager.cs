using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField] private GameObject poolingObj;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform poolingPosition;
    Stack<GameObject> poolingStack = new Stack<GameObject>();
   
    // Start is called before the first frame update
    void Start()
    {
        CreatePooling();
    }
    void CreatePooling()
    {
        // �⺻ 5�� ����
        for(int i = 0; i<5; i++)
        {
            AddPoolingObject(poolingObj);
        }
    }
    public void PoolingArrow()
    {
        // pooling�� obj�� ������ �����ؼ� ���
        if(poolingStack.Count >= 1)
        {
            Debug.Log("1");
            GameObject item = poolingStack.Pop();
            Debug.Log("2");
            SpawnPoolingObject(item);
        }
        else
        {
            // 5�� �߰� ����
            for (int i = 0; i < 5; i++)
            {
                AddPoolingObject(poolingObj);
            }
        }
    }

    public void AddPoolingObject(GameObject obj)
    {
        GameObject poolingObj = Instantiate(obj);
        poolingObj.name = "poolObj";
        poolingObj.gameObject.SetActive(false);
        poolingObj.transform.SetParent(poolingPosition, false);
        poolingStack.Push(poolingObj);
    }

    public void GetPoolObject(GameObject obj)
    {
        GameObject poolingObj = obj as GameObject;
        poolingObj.name = "newPoolObj";
        poolingObj.gameObject.SetActive(false);
        poolingObj.transform.SetParent(poolingPosition, false);
        poolingObj.transform.position = new Vector3(0f, 0f, 0f);
        poolingStack.Push(poolingObj);
    }

    void SpawnPoolingObject(GameObject spawnObj)
    {
        spawnObj.name = "arrow";
        spawnObj.gameObject.SetActive(true);
        spawnObj.transform.SetParent(spawnPosition, false);
        WeaponArrow weapon = spawnObj.GetComponent<WeaponArrow>();
        weapon.SetPoollingManager(transform.gameObject);
    }
    
}
