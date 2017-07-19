using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageSingleTon {
    public static List<Dictionary<string, object>> stageData= CSVReader.Read("stageDB");

    public static void StageDB()
    {
        stageData=CSVReader.Read("stageDB");
    }
}
