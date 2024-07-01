using UnityEngine;

public class Real_Water_Settings_Graphics : MonoBehaviour
{
    public enum myEnum
    {
        Minimum,
        Optimal,
        Realistic
    }
    public myEnum Real_Water_Settings = myEnum.Minimum;

    private float float_rateOverTime;

    private float Q_1_Start_stats_tipe_1;
    private int Q_1_Start_stats_tipe_2;
    private float Q_2_Start_stats_tipe_1;
    private int Q_2_Start_stats_tipe_2;

    private int start_max_particle;
    private bool Start_active;

    private float Start_DistortAmount;
    public void Set_Particle_Settings()
    {
        float_rateOverTime = GetComponent<ParticleSystem>().emission.rateOverTime.constant;
        start_max_particle = GetComponent<ParticleSystem>().main.maxParticles;

        Q_1_Start_stats_tipe_1 = float_rateOverTime / 3F;
        Q_1_Start_stats_tipe_2 = start_max_particle / 3;

        Q_2_Start_stats_tipe_1 = float_rateOverTime;
        Q_2_Start_stats_tipe_2 = start_max_particle;
    }

    public void Set_Start_Active(bool active)
    {
        Start_active = active;
    }
    public void Restart_Particle()
    {
        if (GetComponent<ParticleSystem>() == null)
        {
            GetComponent<ParticleSystem>().Stop();
            GetComponent<ParticleSystem>().Play();
        }
    }
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            if (Start_active == true)
            {
                if (GetComponent<ParticleSystem>() == null)
                {
                    Debug.Log("Скрипт: Real_Water_Settings_Graphics - не обнаружил у себя форму ParticleSystem. Пожалуйста примените форму ParticleSystem к объекту с скриптом.");
                    return;
                }
                if (GetComponent<ParticleSystemRenderer>().material == null)
                {
                    Debug.Log("Скрипт: Real_Water_Settings_Graphics - не обнаружил у себя форму ParticleSystemRenderer. Пожалуйста примените форму ParticleSystemRenderer к объекту с скриптом.");
                    return;
                }
                Update_shader();
            }
        }
    }
    public void Update_shader()
    {
        Check_Minimum();
        Check_Optimal();
        Check_Realistic();
    }

    private void Check_Minimum()
    {
        if (Real_Water_Settings == myEnum.Minimum)
        {
            var ParticleSystem_Real_Water_Settings_Emission = GetComponent<ParticleSystem>().emission;
            float_rateOverTime = ParticleSystem_Real_Water_Settings_Emission.rateOverTime.constant;

            GetComponent<ParticleSystemRenderer>().material.SetFloat("_DistortAmount", 0);
            ParticleSystem_Real_Water_Settings_Emission.rateOverTime = Q_1_Start_stats_tipe_1;
            GetComponent<ParticleSystem>().maxParticles = Q_1_Start_stats_tipe_2;
        }
    }
    private void Check_Optimal()
    {
        if (Real_Water_Settings == myEnum.Optimal)
        {
            var ParticleSystem_Real_Water_Settings_Emission = GetComponent<ParticleSystem>().emission;
            float_rateOverTime = ParticleSystem_Real_Water_Settings_Emission.rateOverTime.constant;

            GetComponent<ParticleSystemRenderer>().material.SetFloat("_DistortAmount", 0);
            ParticleSystem_Real_Water_Settings_Emission.rateOverTime = Q_2_Start_stats_tipe_1;
            GetComponent<ParticleSystem>().maxParticles = Q_2_Start_stats_tipe_2;
        }
    }
    private void Check_Realistic()
    {
        if (Real_Water_Settings == myEnum.Realistic)
        {
            var ParticleSystem_Real_Water_Settings_Emission = GetComponent<ParticleSystem>().emission;
            float_rateOverTime = ParticleSystem_Real_Water_Settings_Emission.rateOverTime.constant;

            GetComponent<ParticleSystemRenderer>().material.SetFloat("_DistortAmount", Start_DistortAmount);
            ParticleSystem_Real_Water_Settings_Emission.rateOverTime = Q_2_Start_stats_tipe_1;
            GetComponent<ParticleSystem>().maxParticles = Q_2_Start_stats_tipe_2;
        }
    }
    public void Set_Start_DistortAmount()
    {
        Start_DistortAmount = GetComponent<ParticleSystemRenderer>().material.GetFloat("_DistortAmount");
    }
}
