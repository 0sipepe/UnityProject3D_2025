using UnityEngine;
using UnityEngine.InputSystem;

public class SavePosition : MonoBehaviour
{

    [SerializeField] private Transform player;
    private void Start()
    {
        Load();
    }

   
    private void Update()
    {
        //плохо и хорошо бы разбить
        if (Keyboard.current[Key.F5].wasPressedThisFrame)
        {
            Save();
        }
        if (Keyboard.current[Key.F6].wasPressedThisFrame)
        {
            Load();
        }

    }

    private void Save()
    {

        Debug.Log("saved");
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.position.z);
    }
    private void Load()
    {
        if (!(PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))) return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float z = PlayerPrefs.GetFloat("PlayerZ");

        player.position = new Vector3(x, y, z);
    }
}
