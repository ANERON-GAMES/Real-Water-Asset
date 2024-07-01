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
            Debug.Log("������: Real_Water_Random_Material_Type - ��������� � ���� ������ ������. ���������� ��������� ������ ���� �������������� �������.");
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
                Debug.Log("������: Real_Water_Random_Material_Type - �� ��������� � ���� ����� ParticleSystemRenderer. ���������� ��������� ����� ParticleSystemRenderer � ������� � ��������.");
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
            Debug.Log("������: Real_Water_Random_Material_Type - �� ��������� � ���� ����� Real_Water_Settings_Graphics. ���������� ��������� ����� Real_Water_Settings_Graphics � ������� � ��������.");
            Destroy(GetComponent<Real_Water_Random_Material_Type>());
        }
    }
}
