using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 4f, xOffset = 0f, yOffset = 0f;
    public bool flip;
    
    void Update(){
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x + xOffset, player.position.y + yOffset), speed * Time.deltaTime);

        Vector3 scale = transform.localScale;
        if(player.position.x > transform.position.x){
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        } else{
            scale.x = Mathf.Abs(scale.x) * (flip? -1 : 1);
        }

        transform.localScale = scale;
    }
}