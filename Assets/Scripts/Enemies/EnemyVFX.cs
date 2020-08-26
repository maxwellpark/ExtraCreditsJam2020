using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyVFX : MonoBehaviour
{
    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    EnemySpriteAnimator enemySpriteAnimator;

    // Point above which the sprite faces left 
    // or right, rather than up or down 
    [SerializeField] float verticalThreshold; 

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>(); 
        enemySpriteAnimator = GetComponent<EnemySpriteAnimator>(); 
    }

    void Update()
    {
        SetEnemySpriteDirection(); 
    }

    // Sprite faces a direction based on its path
    void SetEnemySpriteDirection()
    {

        // This can probably be simplified 
        if (aiPath.desiredVelocity.y >= 0.01f)
        {
            if (transform.position.x + (destinationSetter.target.transform.position.x - transform.position.x) <= verticalThreshold)
            {
                enemySpriteAnimator.direction = Direction.up;
            }
            else
            {
                enemySpriteAnimator.direction = aiPath.desiredVelocity.x >= 0.01f ? Direction.right : Direction.left;
            }
        }
        else if (aiPath.desiredVelocity.y <= 0.01f)
        {
            if (transform.position.x + (destinationSetter.target.transform.position.x - transform.position.x) <= verticalThreshold)
            {
                enemySpriteAnimator.direction = Direction.down;
            }
            else
            {
                enemySpriteAnimator.direction = aiPath.desiredVelocity.x >= 0.01f ? Direction.right : Direction.left;
            }
        }
    }
}
