using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SerializeField : 해당 필도를 유니티에디터의 인스펙터창에 노출을 시켜주기위한 Attribute
public class Horse : MonoBehaviour
{
    public bool doMove;
    [SerializeField] private float speed;
    [SerializeField] private float stability;

    private void FixedUpdate()
    {
        if (doMove)
            Move();
    }


    // 거리  = 속력 * 시간
    // 한프레임당 거리 = 속력 * 한프레임당시간
    private void Move()
    {
        transform position += Vector3. forward * speed + Time fixedDeltaTime; 
    }
}
