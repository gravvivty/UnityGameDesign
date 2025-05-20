using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{
    public Image slideshowImage;
    public Sprite[] slides;
    public float delay = 4f;
    public float lastSlideDelay = 20f;
    public string sceneToLoad;

    private int currentIndex = 0;
    private float timer = 0f;
    private bool slideshowFinished = false;

    void Start()
    {
        if (slides.Length > 0)
        {
            slideshowImage.sprite = slides[0];
        }
    }

    void Update()
    {
        if (slides.Length == 0 || slideshowFinished) return;

        timer += Time.deltaTime;

        float currentDelay = (currentIndex == slides.Length - 1) ? lastSlideDelay : delay;

        if (timer >= currentDelay)
        {
            timer = 0f;
            currentIndex++;

            if (currentIndex < slides.Length)
            {
                slideshowImage.sprite = slides[currentIndex];
            }
            else
            {
                slideshowFinished = true;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}