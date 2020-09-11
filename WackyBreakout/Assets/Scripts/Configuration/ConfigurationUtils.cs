using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    static ConfigurationData configurationData;

    public static float FreezerDurationSeconds
    {
        get { return configurationData.FreezerDurationSeconds; }        
    }

    public static int NumberOfBalls 
    {
        get { return configurationData.NumberOfBalls; }
    }

    public static float ProbabilitieOfBonusBlock
    {
        get { return configurationData.ProbabilitieOfBonusBlock; }
    }

    public static float ProbabilitieOfCommonBlock
    {
        get { return configurationData.ProbabilitieOfCommonBlock; }
    }

    public static float ProbabilitieOfPickUpBlock
    {
        get { return configurationData.ProbabilitieOfPickUpBlock;  }
    }

    public static int PointsForPickupBlock
    {
        get { return configurationData.PointsForPickupBlock; }
    
    }

    public static int PointsForBonusBlock
    {
        get { return configurationData.PointsForBonusBlock; }

    }

    public static int PointsForCommonBlock
    {
        get { return configurationData.PointsForCommonBlock; }
    }


    public static float NewBallSpawnSecondsMin 
    {
        get { return configurationData.NewBallSpawnSecondsMin; }
    }

    public static float NewBallSpawnSecondsMax
    {
        get { return configurationData.NewBallSpawnSecondsMax; }
    }

    public static float BallImpulseForse
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeTimeSeconds 
    {
        get { return configurationData.BallLifeTimeSeconds; }
    }


    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
