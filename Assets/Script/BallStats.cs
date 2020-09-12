using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStats : MonoBehaviour
{
    [SerializeField] BallData _stats;


    [SerializeField] int _density;
    [SerializeField] float _maxVelocity;
    [SerializeField] int _weight;
    [SerializeField] int _hardness; //hp



    public int GetDensity() => _density;
    public float GetMaxVelocity() => _maxVelocity;
    public int GetWeight() => _weight;
    public int GetHardness() => _hardness;



    public void SetBall(BallData ball)
    {
        _stats = ball;

        _density = _stats.GetDensity();
        _maxVelocity = _stats.GetMaxVelocity();
        _weight = _stats.GetWeight();
        _hardness = _stats.GetHardness();
    }


    public bool ShouldTakeDamage(int ObjectHitsStrength)
    {
        return ObjectHitsStrength>_density;
    }

    public void TakeDamage(int damage)
    {
        _hardness -= damage;
        if (_hardness < 0)
            Die();
    }

    public void Die()
    {
        Debug.LogWarning("You Died");
        Destroy(this.gameObject);
    }

    //Dont know what this does
    public void ResetBall()
    {
        
    }

}
