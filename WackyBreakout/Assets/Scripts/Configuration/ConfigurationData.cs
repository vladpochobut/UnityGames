using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballLifeTimeSeconds = 10;
    static float newBallSpawnSecondsMin = 5;
    static float newBallSpawnSecondsMax = 10;
    static int pointsForCommonBlock = 5;
    static int pointsForBonusBlock = 10;
    static int pointsForPickupBlock = 7;
    static float probabilitieOfCommonBlock = 70f;
    static float probabilitieOfBonusBlock = 100f;
    static float probabilitieOfPickUpBlock = 80f;
    static int numberOfBalls = 10;
    static float freezerDurationSeconds = 2f;
    #endregion

    #region Properties 

    public float FreezerDurationSeconds
    {
        get { return freezerDurationSeconds; }
    
    }

    public int NumberOfBalls
    {
        get { return numberOfBalls; }
    }

    public float ProbabilitieOfPickUpBlock
    {
        get { return probabilitieOfPickUpBlock; }

    }

    public float ProbabilitieOfBonusBlock
    {
        get { return probabilitieOfBonusBlock; }

    }

    public float ProbabilitieOfCommonBlock
    {
        get { return probabilitieOfCommonBlock; }

    }

    public int PointsForPickupBlock
    {
        get { return pointsForPickupBlock; }
    
    }


    public int PointsForBonusBlock 
    {
        get { return pointsForBonusBlock; }
    }

    public int PointsForCommonBlock
    {
        get { return pointsForCommonBlock; }
    }

    public float NewBallSpawnSecondsMin 
    {
        get { return newBallSpawnSecondsMin; }
    }

    public float NewBallSpawnSecondsMax
    {
        get { return newBallSpawnSecondsMax; }
    }

    public float BallLifeTimeSeconds 
    {
        get { return ballLifeTimeSeconds; }
    }

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }
    static void SetConfigurationDataFields(string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTimeSeconds = float.Parse(values[2]);
        newBallSpawnSecondsMin = float.Parse(values[3]);
        newBallSpawnSecondsMax = float.Parse(values[4]);
        pointsForCommonBlock = int.Parse(values[5]);
        pointsForBonusBlock = int.Parse(values[6]);
        pointsForPickupBlock = int.Parse(values[7]);
        probabilitieOfPickUpBlock = float.Parse(values[8]);
        probabilitieOfCommonBlock = float.Parse(values[9]);
        probabilitieOfBonusBlock = float.Parse(values[10]);
        numberOfBalls = int.Parse(values[11]);
        freezerDurationSeconds = float.Parse(values[12]);
    }

    #endregion
}
