using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Posi��o inicial para o objeto de paralaxe.
    Vector2 startingPosition;

    // Valor inicial de Z para o objeto de paralaxe.
    float startingZ;

    // Dist�ncia que a c�mera se moveu desde a posi��o inicial do objeto de paralaxe.
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    // Dist�ncia Z entre a posi��o do objeto e a posi��o do objeto a seguir.
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // Se o objeto estiver na frente do objeto a seguir, use o plano de corte pr�ximo (near clip plane). Se estiver atr�s, use o plano de corte distante (far clip plane).
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // Quanto mais distante o objeto estiver do jogador, mais r�pido ele se mover�. Arraste seu valor Z mais pr�ximo ao objeto a seguir para torn�-lo mais lento.
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    void Update()
    {
        // Quando o objeto a seguir se move, mova o objeto de paralaxe na mesma dist�ncia multiplicada por um fator.
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        // Quando o objeto a seguir se move, mova o objeto de paralaxe na mesma dist�ncia multiplicada por um fator.
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
