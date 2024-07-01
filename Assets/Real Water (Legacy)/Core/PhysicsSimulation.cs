#if UNITY_EDITOR
namespace Water2D
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEditor.SceneManagement;
    using UnityEditor;
    using System.Collections.Generic;

    [ExecuteInEditMode]
    public class PhysicsSimulation : MonoBehaviour
    {
        // ... (other existing code)

        private void Awake()
        {
            // your existing Awake method code
        }

        public static void Run()
        {
            // your existing Run method code
        }

        public static void Stop()
        {
            // your existing Stop method code
        }

        public static PhysicsSimulation instance;

        public bool Simulate = false;
        bool _LastSimulateState = false;

        PhysicsScene2D CurrentPhysicsScene;
        float timer1 = 0;

        [HideInInspector] public List<Rigidbody2D> RBAltered;

        private void OnRun()
        {
            if (Simulate)
                return;

            // Unity Simulate OFF
            Physics2D.simulationMode = SimulationMode2D.Script;

            ExcludeRB2D();

            Simulate = true;
            EditorApplication.update += UpdatePhysics;
        }

        private void OnStop()
        {
            Simulate = false;
            EditorApplication.update -= UpdatePhysics;
            BackToNormalRB2D();

            // Unity Simulate ON
            Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
        }

        // ... (other existing methods)

        void UpdatePhysics()
        {
            // your existing UpdatePhysics method code
        }

        // ... (other existing methods)

        void ExcludeRB2D()
        {
            // your existing ExcludeRB2D method code
        }

        void BackToNormalRB2D()
        {
            // your existing BackToNormalRB2D method code
        }

        // ... (other existing methods)
    }
}
#endif