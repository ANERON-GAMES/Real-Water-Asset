using UnityEngine;

public class Real_Water_Random_Material_Type : MonoBehaviour
{
    public Material[] _Material;

    private int Length_Material;
    private int Random_Material;

    private Real_Water_Settings_Graphics _Real_Water_Settings_Graphics;
    private void Start()
    {
        Length_Material = _Material.Length;
        if (Length_Material == 0)
        {
            Debug.Log("Скрипт: Real_Water_Random_Material_Type - обнаружил у себя пустой массив. Пожалуйста заполните массив пред использованием скрипта.");
            Destroy(GetComponent<Real_Water_Random_Material_Type>());
        }
        if (Length_Material != 0)
        {
            Random_Material = Random.Range(0, Length_Material);
            if (GetComponent<ParticleSystemRenderer>() != null)
            {
                GetComponent<ParticleSystemRenderer>().material = _Material[Random_Material];
            }
            else
            {
                Debug.Log("Скрипт: Real_Water_Random_Material_Type - не обнаружил у себя форму ParticleSystemRenderer. Пожалуйста примените форму ParticleSystemRenderer к объекту с скриптом.");
            }
        }
        if (GetComponent<Real_Water_Settings_Graphics>() != null)
        {
            _Real_Water_Settings_Graphics = GetComponent<Real_Water_Settings_Graphics>();
            _Real_Water_Settings_Graphics.Set_Start_DistortAmount();
            _Real_Water_Settings_Graphics.Set_Particle_Settings();
            _Real_Water_Settings_Graphics.Set_Start_Active(true);
            _Real_Water_Settings_Graphics.Update_shader();
            _Real_Water_Settings_Graphics.Restart_Particle();
        }
        else
        {
            Debug.Log("Скрипт: Real_Water_Random_Material_Type - не обнаружил у себя форму Real_Water_Settings_Graphics. Пожалуйста примените форму Real_Water_Settings_Graphics к объекту с скриптом.");
            Destroy(GetComponent<Real_Water_Random_Material_Type>());
        }
    }
}
