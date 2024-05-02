using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
    }
    public void _startChange()
    {
        StartCoroutine(ChangeColorCoroutine());
    }
    public IEnumerator ChangeColorCoroutine()
    {
        while (true)
        {
            Color newColor = new Color(Random.value, Random.value, Random.value);
            _rend.material.color = newColor;
            yield return new WaitForSeconds(1);
        }
    }
}
