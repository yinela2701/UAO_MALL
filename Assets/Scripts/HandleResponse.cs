using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class HandleResponse : MonoBehaviour
{
   [SerializeField] private TMP_Text txtUI; 

    [Serializable]
    public struct VoiceCommand
    {
        public string keyword;
        public UnityEvent response;
    }

    public VoiceCommand[] voiceCommand;

    private Dictionary<string, UnityEvent> commands = new Dictionary<string, UnityEvent>();


    private void Awake()
    {
        foreach (var command in voiceCommand)
        {
            commands.Add(command.keyword.ToLower(), command.response);
        }
    }

   

    public void OnFinalSpeechResult(string resultado)
    {
        txtUI.text = resultado;

        if (resultado != null)
        {
            var respuesta = commands[resultado.ToLower()];

            if (respuesta != null)
            {
                respuesta?.Invoke();
            }
        }
    }
}
