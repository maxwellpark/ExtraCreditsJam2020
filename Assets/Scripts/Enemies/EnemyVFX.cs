using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyVFX : MonoBehaviour
{
    public AIPath aiPath;
    public EnemySpriteAnimator enemySpriteAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        // Flip enemy if changed direction  
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            if (aiPath.desiredVelocity.y >= 0.01f)
            {
                enemySpriteAnimator.direction = Direction.upright; 
            }
            else if (aiPath.desiredVelocity.y <= 0.01f)
            {
                enemySpriteAnimator.direction = Direction.downright; 
            }
            else
            {
                enemySpriteAnimator.direction = Direction.right; 
            }
            //transform.localScale = new Vector3(-1, 1f, 1f); 

        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            if (aiPath.desiredVelocity.y >= 0.01f)
            {
                enemySpriteAnimator.direction = Direction.upleft;
            }
            else if (aiPath.desiredVelocity.y <= 0.01f)
            {
                enemySpriteAnimator.direction = Direction.downleft;
            }
            else
            {
                enemySpriteAnimator.direction = Direction.left;
            }


            //enemySpriteAnimator.direction = Direction.left; 
            //transform.localScale = Vector3.one; 
        }
        else
        {
            if (aiPath.desiredVelocity.y >= 0.01f)
            {
                enemySpriteAnimator.direction = Direction.up;
            }
            else
            {
                enemySpriteAnimator.direction = Direction.down; 
            }
        }
    }
}
