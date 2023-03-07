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
        // 앞쪽 방향으로 이동
        if(isFire)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 벽과 충돌시 다시 풀링에 저장됨
        if(other.tag == "Wall")
        {
            isFire = false;
            poolingManager.GetPoolObject(this.gameObject);
            
        }

    }

}
