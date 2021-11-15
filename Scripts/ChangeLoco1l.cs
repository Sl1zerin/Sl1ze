using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLoco1l : MonoBehaviour
{
    
    public bool stay;
    public Transform point;
    public GameObject nextRoom;
    public GameObject lastRoom;

    public StaticCharacter staticCharacter;

    public GameObject character;
    public InputCharacter inputCharacter;

    public AudioSource audioDoor;

    public bool changeroom = false;

    public SettingOptionsCamera settingText;

    public GameObject Text;

    public float speedScrenChange;
    public float waitTimeScreen;

    private void OnTriggerEnter(Collider other) {
        stay = true;
        if(other.tag == "Character")
        {
            character = other.gameObject;
            inputCharacter=character.GetComponent<InputCharacter>();
            staticCharacter=character.GetComponent<StaticCharacter>();
        }
    }
    private void OnTriggerStay(Collider other) {
        stay = true;
        if(other.tag == "Character")
        {
            character = other.gameObject;
            inputCharacter=character.GetComponent<InputCharacter>();
            staticCharacter=character.GetComponent<StaticCharacter>();
        }
    }

    private void OnTriggerExit(Collider other) {
        stay = false;
        if(other.tag == "Character")
        {
            character = null;
            inputCharacter= null;
            staticCharacter=null;
        }
    }

    void Update()
    {
        UpdateInput();
        UpdateChange();
    }

    void UpdateInput()
    {
        if(stay){
            Text.SetActive(true);    
            if(inputCharacter != null && inputCharacter.actionEvent){
                staticCharacter.changeLocal.speedChange=speedScrenChange;
                staticCharacter.changeLocal.timeOfBack=waitTimeScreen;
                staticCharacter.changeLocal.changeLocations=true;
                changeroom = true;
            }
        }
        else Text.SetActive(false);
    }

    void UpdateChange()
    {
        if (staticCharacter.changeLocal.typeColorChangeImage==1){
            if(changeroom){
                audioDoor.Play();
                nextRoom.SetActive(true);
                character.transform.position = point.position;
                lastRoom.SetActive(false);
                character = null;
                inputCharacter = null;
                stay = false;
                changeroom = false;
                Debug.Log("change");
            }
        }
    }
}
