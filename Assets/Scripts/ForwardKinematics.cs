using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardKinematics : MonoBehaviour
{
    [Tooltip("List of Transforms to animate through forward kinematics.")]
    public List<Transform> targetTransforms;

    [Tooltip("List of starting Transform rotations.")]
    public List<Transform> startingRotations;

    [Tooltip("List of ending Transform rotations.")]
    public List<Transform> endingRotations;

    [Tooltip("Animation time in seconds.")]
    public float animationTime = 1.0f;

    [Tooltip("Whether to hold the animation.")]
    public bool holdAnimation = false;

    [Tooltip("Whether to play the animation.")]
    public bool animate = false;

    // How long the animation has played.
    private float runTime;

    // Start is called before the first frame update
    void Start()
    {
        // Reset the run time.
        runTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If playing the forward kinematics animation.
        if (animate)
        {
            // Update the run time.
            runTime += Time.deltaTime;

            // If the animation is complete
            if (runTime >= animationTime)
            {
                // Reset whether to play the animation.
                animate = false;

                // Reset the run time.
                runTime = 0.0f;

                // If holding the animation
                if (holdAnimation)
                {
                    // Update each rotation to its ending value.
                    for (int i = 0; i < targetTransforms.Count && i < startingRotations.Count && i < endingRotations.Count; i++)
                    {
                        // Check that the target, starting, and ending transforms are valid.
                        if (targetTransforms[i] != null && startingRotations[i] != null && endingRotations[i] != null)
                        {
                            targetTransforms[i].localRotation = Quaternion.Lerp(startingRotations[i].localRotation, endingRotations[i].localRotation, 1.0f);
                        }
                    }
                }
                // If not holding the animation
                else
                {
                    // Update each rotation to its starting value.
                    for (int i = 0; i < targetTransforms.Count && i < startingRotations.Count && i < endingRotations.Count; i++)
                    {
                        // Check that the target, starting, and ending transforms are valid.
                        if (targetTransforms[i] != null && startingRotations[i] != null && endingRotations[i] != null)
                        {
                            targetTransforms[i].localRotation = Quaternion.Lerp(startingRotations[i].localRotation, endingRotations[i].localRotation, 0.0f);
                        }
                    }
                }
            }
            // If the animation is still going
            else
            {
                // Update each rotation based on the current run time.
                for (int i = 0; i < targetTransforms.Count && i < startingRotations.Count && i < endingRotations.Count; i++)
                {
                    // Check that the target, starting, and ending transforms are valid.
                    if (targetTransforms[i] != null && startingRotations[i] != null && endingRotations[i] != null)
                    {
                        targetTransforms[i].localRotation = Quaternion.Lerp(startingRotations[i].localRotation, endingRotations[i].localRotation, runTime / animationTime);
                    }
                }
            }
        }
        // If not playing the animation and not holding it.
        else if (!animate && !holdAnimation)
        {
            // Update each rotation to its starting value.
            for (int i = 0; i < targetTransforms.Count && i < startingRotations.Count && i < endingRotations.Count; i++)
            {
                // Check that the target, starting, and ending transforms are valid.
                if (targetTransforms[i] != null && startingRotations[i] != null && endingRotations[i] != null)
                {
                    targetTransforms[i].localRotation = Quaternion.Lerp(startingRotations[i].localRotation, endingRotations[i].localRotation, 0.0f);
                }
            }
        }
    }
}
