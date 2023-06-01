using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
   public static CharacterSelector instance;
   public CharacterScriptableObject character1;

    void Awake()
    {
        if(instance == null )
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("EXTRA" + this + "Deleted");
            Destroy(gameObject);
        }
    }

    public static CharacterScriptableObject GetData()
    {
        return instance.character1;
    }

    public void SelectCharacter(CharacterScriptableObject character)
    {
        character1 = character;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
