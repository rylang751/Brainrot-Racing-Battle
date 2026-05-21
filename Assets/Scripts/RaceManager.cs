using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    void Start()
    {
        // Check if a character name was successfully saved from the selection screen
        if (!string.IsNullOrEmpty(CharacterSelect.SelectedCharacterName))
        {
            Debug.Log("Character received: " + CharacterSelect.SelectedCharacterName);
            
            // This is where you will spawn your character prefab later
            SpawnSelectedCharacter();
        }
        else
        {
            Debug.LogWarning("No character was selected! Make sure to start from the Character Select scene.");
        }
    }

    private void SpawnSelectedCharacter()
    {
        if (CharacterSelect.SelectedCharacterPrefab != null)
        {
            // Spawns the chosen prefab at the position of this RaceManager object
            Instantiate(CharacterSelect.SelectedCharacterPrefab, transform.position, transform.rotation);
        }
    }
}