using UnityEngine;

namespace Basic_no_refactor
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Time.timeScale = 1;
        }
    }
}
