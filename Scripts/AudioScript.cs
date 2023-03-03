using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioClip JumpSound, DeadSound, ShootSound,ErrorSound,EnemyHitSound,PlayerHitSound,LevelCompleteSound;
    static AudioSource AudioSrc;
    void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
        JumpSound = Resources.Load<AudioClip>("Jump");
        ShootSound = Resources.Load<AudioClip>("Shoot");
        DeadSound = Resources.Load<AudioClip>("Death");
        ErrorSound = Resources.Load<AudioClip>("Error");
        EnemyHitSound = Resources.Load<AudioClip>("EnemyHit");
        PlayerHitSound = Resources.Load<AudioClip>("PlayerHit");
        LevelCompleteSound = Resources.Load<AudioClip>("Complete");



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Shoot":
                AudioSrc.PlayOneShot(ShootSound);
                break;
            case "Jump":
                AudioSrc.PlayOneShot(JumpSound);
                break;
            case "Dead":
                AudioSrc.PlayOneShot(DeadSound);
                break;
            case "Error":
                AudioSrc.PlayOneShot(ErrorSound);
                break;
            case "PlayerHit":
                AudioSrc.PlayOneShot(PlayerHitSound);
                break;
            case "EnemyHit":
                AudioSrc.PlayOneShot(EnemyHitSound);
                break;
            case "Complete":
                AudioSrc.PlayOneShot(LevelCompleteSound);
                break;

        }
    }
}
