using UnityEngine;
using Random = System.Random;

namespace Basic_no_refactor
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private int _points = 0;
        public int Points => _points;

        private void Start()
        {
            Random newRandom = new Random();
            _points = newRandom.Next(1, 10);
        }
    }
}
