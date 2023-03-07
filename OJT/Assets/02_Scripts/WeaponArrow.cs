using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponArrow : MonoBehaviour
{
    private PoolingManager poolingManager;
    private float moveSpeed = 3f;
    bool isFire = false;
    public void SetPoollingManager(GameObject obj)
    {
        poolingManager =  obj.GetComponent<PoolingManager>();
        isFire = true;
    }

    void Update()
    {
        // ���� �������� �̵�
        if(isFire)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� �浹�� �ٽ� Ǯ���� �����
        if(other.tag == "Wall")
        {
            isFire = false;
            poolingManager.GetPoolObject(this.gameObject);
            
        }

    }

}
