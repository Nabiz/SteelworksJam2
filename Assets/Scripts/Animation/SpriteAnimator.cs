using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    private SpriteSegment[] sprites;
    
    [field: SerializeField] public float AnimationSpeed { get; private set; } = 1f;

    [SerializeField] List<SpriteSegment> spriteSegments;

    [SerializeField] List<float> spriteSegmentsOffsets;

	private void Awake()
	{
        sprites = gameObject.GetComponentsInChildren<SpriteSegment>(includeInactive: false); 

        HashSet<float> offsets = new HashSet<float>(spriteSegmentsOffsets);
        float offset = offsets.Count * 0.1f;

        for (int i = 0; i < spriteSegments.Count; ++i)
        {
            spriteSegments[i].Init(spriteSegmentsOffsets[i]);
        }

        for (int i = 0; i < sprites.Length; ++i) //then make it check if sprite schould react to dir change
        {
            sprites[i].ChangeDirection();
            sprites[i].Init(i * 0.1f + offset);
        }
	}

    // Update is called once per frame
    void Update()
    {

    }

    void OnValidate() {
        for (int i = 0; i < spriteSegmentsOffsets.Count; ++i) //then make it check if sprite schould react to dir change
        {
            spriteSegmentsOffsets[i] = Mathf.Clamp01(spriteSegmentsOffsets[i]);
        }
    }

    public void SetDirectionAll(Enums.Direction dir)
	{
        for (int i = 0; i < sprites.Length; ++i) //then make it check if sprite schould react to dir change
		{
            sprites[i].SetDirection(dir);
		}
	}
}
