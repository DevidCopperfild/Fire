using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform playerTransform; // Здесь будет ссылка на компонент игрока
    [SerializeField] private string playerTag; // Здесь будет тег игрока   
    [SerializeField] private float movingSpeed; //скорость камеры которая движеться за объектом 

    private void Awake()
    {
        if(this.playerTransform == null) // if in radius camera no object 
        {
            if(this.playerTag == "") //He find tag
            {
                this.playerTag = "Player"; //if Tag = Empty, tag == Player
            }

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform; //He find tag and position
        }

        this.transform.position = new Vector3() // position camera
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 10 // Camera back for player.pos
        };
    }

    private void FixedUpdate()
    {
        if(this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp( a: this.transform.position, b: target, this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}