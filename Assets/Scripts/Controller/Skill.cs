using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField]
    GameObject Particle;
    GameObject Particle2;
    bool SpeedUp = false;
    bool Size = false;
    Vector3 originalScale;

    void Start()
    {
        Particle.SetActive(false);
    }

 
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && !SpeedUp)
        {
            Particle.SetActive(true);
            SpeedUp = true;
            Movement.Playerspeed = 10f;
            StartCoroutine(Skill1());
        }
        if (Input.GetKey(KeyCode.X) && !Size)
        {
            Particle.SetActive(true);
            Size = true;
            StartCoroutine(Skill2(1.0f, 3.0f));
        }

    }
    IEnumerator Skill1()
    {
        yield return new WaitForSeconds( 1f );
        Particle.SetActive(false);
        yield return new WaitForSeconds( 2.0f );
        Movement.Playerspeed = 5f;
        yield return new WaitForSeconds( 27.0f );
        SpeedUp = false;
    }
    IEnumerator Skill2(float newSize, float duration)
    {
        float timer = 0.0f;
        Vector3 originalSize = transform.localScale;

        while (timer < duration)
        {
            transform.localScale = Vector3.Lerp(originalSize, new Vector3(newSize, newSize, newSize), timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
        Size = false;
    }
}
