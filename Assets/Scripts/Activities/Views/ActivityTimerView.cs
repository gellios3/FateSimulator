using TMPro;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Activities.Views
{
    public class ActivityTimerView : MonoBehaviour
    {
        [SerializeField] private ProceduralImage image;

        [SerializeField] private TextMeshProUGUI timeTxt;

        [SerializeField] private int time;

        private void Start()
        {
            timeTxt.text = "0";
        }

        // Update is called once per frame
        private void Update()
        {
            if (image.fillAmount < 1)
            {
                image.fillAmount += Time.deltaTime / time;
                timeTxt.text = (image.fillAmount * 10).ToString("F");
            }
            else
            {
                image.fillAmount = 0;
                timeTxt.text = time.ToString("F");
            }
        }
    }
}