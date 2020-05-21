using UnityEngine;
using UnityEngine.UI;

namespace Basic_no_refactor
{
    public class PointsDisplayController : MonoBehaviour
    {
        public Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
        }
    }
}
