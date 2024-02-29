using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asistente : MonoBehaviour
{
    public Animator animator;

    public AudioClip[] audioClips; // Un arreglo de clips de audio que deseas reproducir.  Silly Dancing
    private AudioSource audioSource;

    public AudioSource ChisteSound, RecordSound, PromoSound, TiendaSound;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Saludar()
    {
        animator.SetTrigger("Saludar");
    }
     public void Promociones()
    {
        animator.SetTrigger("Promociones");
    }
     public void Tiendas()
    {
        animator.SetTrigger("Tiendas");
    }
     public void TiendasNuevas()
    {
        animator.SetTrigger("TiendasNuevas");
    }
     public void Chiste()
    {
        animator.SetTrigger("Chiste");
        animator.SetTrigger("Reir");
    }
     public void Hablar()
    {
        animator.SetTrigger("Hablar");
    }
     public void Especifico()
    {
        animator.SetTrigger("Especifico");
    }
     public void Principal()
    {
        animator.SetTrigger("Principal");
    }

    public void Avisar()
    {
        animator.SetTrigger("Avisar");
    }

     public void presionarBoton()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void ChisteSonido(){
        ChisteSound.Play();
    }
    public void RecordSonido(){
        RecordSound.Play();
    }
    public void PromoSonido(){
        PromoSound.Play();
    }
    public void TiendaSonido(){
        TiendaSound.Play();
    }
    
    

   // public void Victory()
    //{
    //    animator.SetTrigger("Victory");
        
    //    audioSource.clip = audioClips[0];
    //    audioSource.Play();
    //}

    public void CerrarApp(){
        Application.Quit();
    }
}
