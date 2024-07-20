using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboEffect : ObjectEffects
{
    [SerializeField] float turboValue = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") ActiveEffect();
    }
    public override void ActiveEffect()
    {
        base.ActiveEffect();
        //player.velocity += (Vector2.one * turboValue);
        if(player.velocity.x < 0) player.velocity += Vector2.left * turboValue;
        if(player.velocity.y < 0) player.velocity += Vector2.down * turboValue;
        if(player.velocity.x > 0) player.velocity += Vector2.right * turboValue;
        if(player.velocity.y > 0) player.velocity += Vector2.up * turboValue;
    }
}
