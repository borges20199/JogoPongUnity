using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Obtenha o componente de áudio
        audioSource = GetComponent<AudioSource>();

        // Inicie a reprodução da música
        PlayMusic();
    }

    void Update()
    {
        // Adicione lógica adicional conforme necessário
    }

    void PlayMusic()
    {
        // Verifique se o áudio não está tocando para evitar reiniciar
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void StopMusic()
    {
        // Pare a reprodução da música
        audioSource.Stop();
    }

    void OnDestroy()
    {
        // Chame StopMusic ao destruir o objeto
        StopMusic();
    }

    void Awake()
{
    DontDestroyOnLoad(this.gameObject);
}
}
