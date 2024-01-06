using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Posição inicial para o objeto de paralaxe.
    Vector2 startingPosition;

    // Valor inicial de Z para o objeto de paralaxe.
    float startingZ;

    // Distância que a câmera se moveu desde a posição inicial do objeto de paralaxe.
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    // Distância Z entre a posição do objeto e a posição do objeto a seguir.
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;

    // Se o objeto estiver na frente do objeto a seguir, use o plano de corte próximo (near clip plane). Se estiver atrás, use o plano de corte distante (far clip plane).
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // Quanto mais distante o objeto estiver do jogador, mais rápido ele se moverá. Arraste seu valor Z mais próximo ao objeto a seguir para torná-lo mais lento.
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    void Update()
    {
        // Quando o objeto a seguir se move, mova o objeto de paralaxe na mesma distância multiplicada por um fator.
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        // Quando o objeto a seguir se move, mova o objeto de paralaxe na mesma distância multiplicada por um fator.
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
