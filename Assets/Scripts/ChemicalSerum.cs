using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalSerum : MonoBehaviour
{
    public Chemical.Type Type { get; set; }
    public ChemicalReactionType ReactionType { get; set; }
    
    public enum ChemicalReactionType
    {
        nothing,
        explosion
    }
    
    public void OnCollisionWithBottle(Bottle bottle)
    {
        Debug.Log("Serum has collision with bottle");
        this.tag = "ChemicalReaction"; // change tag
        ReactionType = ChemicalReactionType.nothing;
        var comp = gameObject.AddComponent<Rigidbody2D>();
        comp.bodyType = RigidbodyType2D.Kinematic;
        
        // Disable / enable to trigger collision
        // GetComponent<Collider2D>().enabled = false;
        // GetComponent<Collider2D>().enabled = true;

        ReactionType = CreateReaction(Type, bottle.GetComponent<Bottle>().GetBottleType());
    }

    public static ChemicalReactionType CreateReaction(Chemical.Type t1, Chemical.Type t2)
    {
        if (t1 == Chemical.Type.red && t2 == Chemical.Type.yellow ||
            t1 == Chemical.Type.yellow && t2 == Chemical.Type.red)
        {
            return ChemicalReactionType.explosion;
        }

        return ChemicalReactionType.nothing;
    }
    
}