// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using Entities;

// public static class Levels{

//     public static Level Level1 = new Level(){
//         LevelName = "Training Hills"
//         ,LevelNumber = 1
//         ,Phases = new Phase[]{
//             new Phase(){
//                 PlayerPosition = PlayerPositions.Left
//                 ,WaitForStart = 1
//                 ,WaitForWave = 0
//                 ,Waves = new Wave[]{
//                     new Wave(){
//                         RepeatCount = 20
//                         ,RepeatWait = .5f
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 1
//                     }
//                     ,new Wave(){
//                         RepeatCount = 10
//                         ,RepeatWait = .25F
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 2
//                     }
//                     ,new Wave(){
//                         RepeatCount = 4
//                         ,RepeatWait = 1
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 2
//                         ,RowCount = 2
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 2
//                     }
//                     ,
//                     new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 1
//                         ,Formation = FormationType.Wedge
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 3
//                         ,RowCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 2
//                     }
//                     ,
//                     new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 1
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 3
//                         ,RowCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 2
//                     }
//                     ,new Wave(){
//                         RepeatCount = 1
//                         ,RepeatWait = 0
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 5
//                         ,RowCount = 5
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 3
//                     }
//                     ,new Wave(){
//                         RepeatCount = 1
//                         ,RepeatWait = 0
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 5
//                         ,RowCount = 5
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 5
//                         ,RepeatWait = .75F
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 5
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 2F
//                         ,Formation = FormationType.Wedge
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 1
//                     }
//                     ,new Wave(){
//                         RepeatCount = 20
//                         ,RepeatWait = .25f
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 1
//                     }
//                     ,new Wave(){
//                         RepeatCount = 5
//                         ,RepeatWait = 1F
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 4
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 5
//                     }
//                     ,new Wave(){
//                         RepeatCount = 4
//                         ,RepeatWait = .5F
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 7
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 2F
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 3
//                         ,RowCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 1
//                     }
//                 }
//             }
//         }
//     };
    
//     public static Level Level2 = new Level(){
//         LevelName = "Next Level Hills"
//         ,LevelNumber = 2
//         ,Phases = new Phase[]{
//             new Phase(){
//                 PlayerPosition = PlayerPositions.Left
//                 ,WaitForStart = 1
//                 ,WaitForWave = 0
//                 ,Waves = new Wave[]{
//                     new Wave(){
//                         RepeatCount = 1
//                         ,RepeatWait = 1
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 5
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 1
//                         ,RepeatWait = 2F
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 7
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 1
//                         ,RepeatWait = 1
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 5
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 5
//                         ,RepeatWait = 2F
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 5
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 0
//                     }
//                     ,
//                     new Wave(){
//                         RepeatCount = 6
//                         ,RepeatWait = 1
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 3
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,
//                     new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 2
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 3
//                         ,RowCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 3
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 2.5F
//                         ,Formation = FormationType.Wedge
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 5
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 1
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = .75f
//                         ,Formation = FormationType.Wedge
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = .25f
//                         ,Formation = FormationType.Wedge
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 2
//                     }
//                     ,new Wave(){
//                         RepeatCount = 1
//                         ,RepeatWait = 0
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 40
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 7
//                     }
//                     ,new Wave(){
//                         RepeatCount = 30
//                         ,RepeatWait = .5f
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.KiteSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.UpperRight
//                         ,EnemyExit = EnemySpawns.UpperLeft
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 20
//                         ,RepeatWait = .5f
//                         ,Formation = FormationType.RandomStagger
//                         ,Enemy = EnemyType.FastSoldier
//                         ,ColumnCount = 1
//                         ,RowCount = 1
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,RepeatWait = 2
//                         ,Formation = FormationType.Block
//                         ,Enemy = EnemyType.FootSoldier
//                         ,ColumnCount = 4
//                         ,RowCount = 4
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,WavePause = 1
//                     }
//                 }
//             }
//         }
//     };
    
//     public static Level Level3 = new Level(){
//         LevelName = "Not level 3!"
//         ,LevelNumber = 3
//         ,Phases = new Phase[]{
//             new Phase(){
//                 PlayerPosition = PlayerPositions.Left
//                 ,WaitForStart = 4
//                 ,WaitForWave = 1
//                 ,Waves = new Wave[]{
//                     new Wave(){
//                         RepeatCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 6
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 3
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 6
//                         ,EnemySpawn = EnemySpawns.Right
//                         ,EnemyExit = EnemySpawns.Left
//                         ,RepeatWait = .1f
//                     }
//                 }
//             }
//             ,new Phase(){
//                 PlayerPosition = PlayerPositions.Right
//                 ,WaitForStart = 1
//                 ,WaitForWave = 2
//                 ,Waves = new Wave[]{
//                     new Wave(){
//                         RepeatCount = 5
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 10
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = .25f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 10
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = 0.1f
//                     }
//                 }
//             }
//             ,new Phase(){
//                 PlayerPosition = PlayerPositions.Left
//                 ,WaitForStart = 4
//                 ,WaitForWave = 1
//                 ,Waves = new Wave[]{
//                     new Wave(){
//                         RepeatCount = 15
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = .5f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 15
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = .25f
//                     }
//                 }
//             }
//             ,new Phase(){
//                 PlayerPosition = PlayerPositions.Right
//                 ,WaitForStart = 1
//                 ,WaitForWave = 2
//                 ,Waves = new Wave[]{
//                     new Wave(){
//                         RepeatCount = 5
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = 0
//                     }
//                     ,new Wave(){
//                         RepeatCount = 10
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = .25f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 50
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = 0.25f
//                     }
//                     ,new Wave(){
//                         RepeatCount = 100
//                         ,EnemySpawn = EnemySpawns.Left
//                         ,EnemyExit = EnemySpawns.Right
//                         ,RepeatWait = 0.1f
//                     }
//                 }
//             }
//         }
//     };
// }
