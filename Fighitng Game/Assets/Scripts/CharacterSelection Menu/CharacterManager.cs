using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDataBase characterDB;

    public Text nameText;
    public Image imageOfSprite; 

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCharacter(selectedOption);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

        }
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount) 
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0) 
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption) 
    {
        Character character = characterDB.GetCharacter(selectedOption);
        imageOfSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }
   
}
