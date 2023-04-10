using UnityEngine;

public class LevelUp_Event : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioSource childAudio;

    public void UnactiveThis() //animevent
    {
        this.gameObject.SetActive(false);
    }

    public void Sound1() //animevent
    {
        myAudio.Play();
    }

    public void Sound2() //animevent
    {
        childAudio.Play();
    }
}
