using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeartUI : MonoBehaviour
{
  public Sprite fullHeart, halfHeart, emptyHeart;
  
  private Image heartImage;

  void Awake()
  {
    heartImage = GetComponent<Image>();
  }

  public void SetHeartImage(HeartStatus status)
  {
    switch (status)
    {
      case HeartStatus.Empty:
        heartImage.sprite = emptyHeart;
        break;
      case HeartStatus.Half:
        heartImage.sprite = halfHeart;
        break;
      case HeartStatus.Full:
        heartImage.sprite = fullHeart;
        break;
    }
  }
}
