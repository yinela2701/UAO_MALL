using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Android;
using System;

public class ARGPS : MonoBehaviour
{
    public PanelController PanelController;
    public TextToSpeechTest TextToSpeechTest;
    public Asistente Asistente;
  //  public GameObject prefabTennis;
  //  public GameObject prefabLego;
  //  public GameObject prefabNike;
  //  public GameObject prefabStarbucks;
 //   public GameObject prefabHomecenter;
    public Text txtGPS;

   // public Text temp;
   // public Text temp1;

    int maxWait = 200;
    private bool gpsEnabled = false;

    public double targetLatitudeTennis;
    public double targetLongitudeTennis;
    public double targetLatitudeLego;
    public double targetLongitudeLego;
    public double targetLatitudeNike;
    public double targetLongitudeNike;
    public double targetLatitudeStarbucks;
    public double targetLongitudeStarbucks;
    public double targetLatitudeHomecenter;
    public double targetLongitudeHomecenter;

    public double tuDistanciaUmbral = 4f;

    public bool estaUsadoTennis = false;
    public bool estaUsadoLego = false;
    public bool estaUsadoNike = false;
    public bool estaUsadoStarbucks = false;
    public bool estaUsadoHomecenter = false;

    void Start()
    {
        StartCoroutine(UpdateGPS());
      //  prefabTennis.SetActive(false);
      //  prefabLego.SetActive(false);
      //  prefabNike.SetActive(false);
      //  prefabStarbucks.SetActive(false);
     //   prefabHomecenter.SetActive(false);
    }

    private void Awake()
    {
        if (!Application.isEditor)
        {
            // Solicita permiso al usuario para usar el GPS
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
                Permission.RequestUserPermission(Permission.FineLocation);
        }
    }

    IEnumerator UpdateGPS()
    {
        while (true)
        {
            // Valida si el usuario tiene el servicio de ubicación activado
            if (!Input.location.isEnabledByUser)
            {
                txtGPS.text = "Servicio de Ubicación: " + Input.location.isEnabledByUser;
                yield return new WaitForSeconds(5f); // Espera 5 segundos antes de volver a verificar
                continue;
            }
            else
            {
                txtGPS.text = "Servicio de Ubicación: " + Input.location.isEnabledByUser;
            }

            // Inicializa el servicio de ubicación
            Input.location.Start();

            // Espera hasta que el servicio de ubicación esté activado
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
                txtGPS.text = "Esperando: " + maxWait;
            }

            if (maxWait <= 0)
            {
                txtGPS.text = "Inicialización GPS fuera de tiempo límite";
                yield return new WaitForSeconds(5f); // Espera 5 segundos antes de volver a verificar
                continue;
            }

            // Si el servicio de ubicación falla, detiene el script
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                txtGPS.text = "Imposible determinar la posición del dispositivo";
                yield return new WaitForSeconds(5f); // Espera 5 segundos antes de volver a verificar
                continue;
            }
            else
            {
                gpsEnabled = true;

                // Obtiene los datos de latitud y longitud del GPS
                double latitude = Input.location.lastData.latitude;
                double longitude = Input.location.lastData.longitude;

                // Muestra las coordenadas en txtGPS
             //   txtGPS.text = "Latitud: " + latitude.ToString() + "\n" +
                //              "Longitud: " + longitude.ToString();

                // Calcula la distancia entre la posición actual y la posición del objetivo
                float distanceTennis = CalculateDistance(latitude, longitude, targetLatitudeTennis, targetLongitudeTennis);
                float distanceLego = CalculateDistance(latitude, longitude, targetLatitudeLego, targetLongitudeLego);
                float distanceNike = CalculateDistance(latitude, longitude, targetLatitudeNike, targetLongitudeNike);
                float distanceStarbucks = CalculateDistance(latitude, longitude, targetLatitudeStarbucks, targetLongitudeStarbucks);
                float distanceHomecenter = CalculateDistance(latitude, longitude, targetLatitudeHomecenter, targetLongitudeHomecenter);


              //  temp.text = "Distancia: " + distance.ToString() + " Umbral: " + tuDistanciaUmbral.ToString();
                if(distanceTennis > tuDistanciaUmbral)
                {
                        estaUsadoTennis= false;
                       // prefabTennis.SetActive(false);
                }
                if(distanceLego > tuDistanciaUmbral)
                {
                        estaUsadoLego= false;
                       // prefabTennis.SetActive(false);
                }
                if(distanceNike > tuDistanciaUmbral)
                {
                        estaUsadoNike= false;
                       // prefabTennis.SetActive(false);
                }
                if(distanceStarbucks > tuDistanciaUmbral)
                {
                        estaUsadoStarbucks= false;
                       // prefabTennis.SetActive(false);
                }
                if(distanceHomecenter > tuDistanciaUmbral)
                {
                        estaUsadoHomecenter= false;
                       // prefabTennis.SetActive(false);
                }

                if(!estaUsadoTennis)
                {
                    if(distanceTennis > tuDistanciaUmbral)
                    {
                       // prefabTennis.SetActive(false);
                    } else
                    {
                        PanelController.Activar("TennisQRGPS");
                        TextToSpeechTest.StartTextToSpeech("Jeeeey, estas pasando cerca a Tennis y tienen estupendas promociones");
                        Asistente.Avisar();

                    }
                } else
                {
                    //prefabTennis.SetActive(false);
                    //PanelController.Activar("Principal");
                }
                
                if(!estaUsadoLego)
                {
                    if(distanceLego > tuDistanciaUmbral)
                    {
                     //   prefabLego.SetActive(false);
                    } else
                    {
                        PanelController.Activar("LegoQRGPS");
                        TextToSpeechTest.StartTextToSpeech("Jeeeey, estas pasando cerca a Lego y tienen estupendas promociones");
                        Asistente.Avisar();
                    }
                } else
                {
                    //prefabLego.SetActive(false);
                    //PanelController.Activar("Principal");
                }

                if(!estaUsadoNike)
                {
                    if(distanceNike > tuDistanciaUmbral)
                    {
                      //  prefabNike.SetActive(false);
                    } else
                    {
                        PanelController.Activar("NikeQRGPS");
                        TextToSpeechTest.StartTextToSpeech("Jeeeey, estas pasando cerca a Naik y tienen estupendas promociones");
                        Asistente.Avisar();
                    }
                } else
                {
                   // prefabNike.SetActive(false);
                   // PanelController.Activar("Principal");
                }

                if(!estaUsadoStarbucks)
                {
                    if(distanceStarbucks > tuDistanciaUmbral)
                    {
                       // prefabStarbucks.SetActive(false);
                    } else
                    {
                        PanelController.Activar("StarbucksQRGPS");
                        TextToSpeechTest.StartTextToSpeech("Jeeeey, estas pasando cerca a Estarbocks y tienen estupendas promociones");
                        Asistente.Avisar();
                    }
                } else
                {
                    //prefabStarbucks.SetActive(false);
                    //PanelController.Activar("Principal");
                }

                if(!estaUsadoHomecenter)
                {
                    if(distanceHomecenter > tuDistanciaUmbral)
                    {
                       // prefabHomecenter.SetActive(false);
                    } else
                    {
                        PanelController.Activar("HomecenterQRGPS");
                        TextToSpeechTest.StartTextToSpeech("Jeeeey, estas pasando cerca a Jomcenter y tienen estupendas promociones");
                        Asistente.Avisar();
                    }
                } else
                {
                    //prefabHomecenter.SetActive(false);
                    //PanelController.Activar("Principal");
                }
            }

            yield return new WaitForSeconds(5f); // Espera 5 segundos antes de volver a verificar
        }
    }

    private float CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double EarthRadius = 6371; 
        double dLat = (lat2 - lat1) * (Math.PI / 180);
        double dLon = (lon2 - lon1) * (Math.PI / 180);
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        float distance = (float)(EarthRadius * c);
        return distance;
    }
    
    public void CerrarPromoTennis()
    {
        estaUsadoTennis = true;
    }

    public void CerrarPromoLego()
    {
        estaUsadoLego = true;
    }

    public void CerrarPromoNike()
    {
        estaUsadoNike = true;
    }
    
    public void CerrarPromoStarbucks()
    {
        estaUsadoStarbucks = true;
    }

    public void CerrarPromoHomecenter()
    {
        estaUsadoHomecenter = true;
    }
}
