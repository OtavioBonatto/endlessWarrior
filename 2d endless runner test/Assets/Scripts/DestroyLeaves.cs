using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLeaves : MonoBehaviour {
    void OnBecameInvisible() {
        Destroy(gameObject);
     }
}
