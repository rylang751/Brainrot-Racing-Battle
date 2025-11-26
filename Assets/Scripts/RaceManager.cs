using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (CharacterSelect.characterNames != null)
        {
            Debug.Log("Character recieved");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
