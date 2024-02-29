using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PanelController : MonoBehaviour
{
    public List<GameObject> paneles; // Declaración de la lista de GameObjects

    public void Activar(string nombre)
    {
        foreach (GameObject panel in paneles)
        {
            // Comprueba si el nombre del panel es "Promociones"
            if (panel.name == nombre)
            {
                // Desactiva el panel si se encuentra
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false); 
            }
        }
    }
    
}
