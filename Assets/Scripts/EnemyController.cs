using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

public class EnemyController : MonoBehaviour {

		public GameObject FootSoldier;
		public GameObject FastSoldier;
		public GameObject KiteSoldier;

        public GameObject DarkHorse;

	    public Vector2[] GetSpawnPositions(bool Flying, FormationType Formation, int enemyCount){

            Vector2[] positions;
            // int posNum = 0;
            // float ySpaceing = .85f;
            // float xSpaceing = .85f;

            Vector2 basePosition;

            switch(Formation){
                // case FormationType.Block:
                //     basePosition = GetRandomSpawnPosition(Flying);
                //     int enemiesSquared = enemyCount*enemyCount;
                //     positions = new Vector2[enemiesSquared];
                //     for(int r = 0; r < enemyCount; r++){
                //         for(int c = 0; c < enemyCount; c++){
                //             float x = basePosition.x + r * xSpaceing;
                //             float y = basePosition.y - c * ySpaceing;
                //             positions[posNum] = new Vector2(x,y);
                //             posNum++;
                //         }
                //     }
                //     return positions;
                // case FormationType.Wedge:
                //     basePosition = GetRandomSpawnPosition(Flying);
                //     positions = new Vector2[enemyCount];                    
                //     for(int r = 0; r < enemyCount; r++){;
                //         float x = basePosition.x;
                //         float y = basePosition.y;
                //         positions[posNum] = new Vector2(x,y);

                //     }
                //     // ///firstrow
                //     // positions[0] = basePosition;
                //     // ///second row
                //     // positions[1] = new Vector2(basePosition.x+xSpaceing, basePosition.y+ySpaceing/2);
                //     // positions[2] = new Vector2(basePosition.x+xSpaceing, basePosition.y-ySpaceing/2);
                //     // ///back row
                //     // positions[3] = new Vector2(basePosition.x+xSpaceing*2, basePosition.y+ySpaceing);
                //     // positions[4] = new Vector2(basePosition.x+xSpaceing*2, basePosition.y);
                //     // positions[5] = new Vector2(basePosition.x+xSpaceing*2, basePosition.y-ySpaceing);
                //     return positions;
                // case FormationType.Stagger:
                //     basePosition = GetRandomSpawnPosition(Flying);
                //     positions = new Vector2[enemyCount];
                //     for(int i = 0; i< enemyCount; i++){
                //         positions[i] = new Vector2(basePosition.x+i*enemyCount, basePosition.y);
                //     }
                //     return positions;
                case FormationType.RandomStagger:
                    positions = new Vector2[enemyCount];
                    for(int i = 0; i< enemyCount; i++){
                        positions[i] = GetRandomSpawnPosition(Flying);
                    }
                    return positions;
                default:
                    positions = new Vector2[1]{GetRandomSpawnPosition(Flying)};
                    return positions;
            }
    }



    public GameObject GetRandomEnemy()
    {
        var enemies = EnemyType.GetValues(typeof(EnemyType));
        EnemyType randomEnemyType = (EnemyType)enemies.GetValue(Random.Range(0, enemies.Length));
        return GetEnemy(randomEnemyType);
    }
    public FormationType GetRandomFormation()
    {
        var formations = FormationType.GetValues(typeof(FormationType));
        return (FormationType)formations.GetValue(Random.Range(0, formations.Length));
        
    }
    public GameObject GetEnemy(EnemyType enemyType)
    {  
        switch(enemyType){
            case EnemyType.FootSoldier:
                return FootSoldier;
            case EnemyType.KiteSoldier:
                return KiteSoldier;
            case EnemyType.FastSoldier:
                return FastSoldier;
            default:
                return FootSoldier;
        }

    }

    public Vector2 GetRandomSpawnPosition(bool Flying){

        if(Flying){
            var x = Random.Range(EnemySpawns.SkyLowerRight.x, EnemySpawns.SkyUpperLeft.x);
            var y = Random.Range(EnemySpawns.SkyLowerRight.y, EnemySpawns.SkyUpperLeft.y);
            return new Vector2(x, y);
        }else{
            var x = Random.Range(EnemySpawns.GroundLowerRight.x, EnemySpawns.GroundUpperLeft.x);
            var y = Random.Range(EnemySpawns.GroundLowerRight.y, EnemySpawns.GroundUpperLeft.y);
            return new Vector2(x, y);
        }

    }
    
    public enum FormationType{
        // Wedge,
        // Block,
        RandomStagger,
        //Stagger
    }

    public enum EnemyType{
        FootSoldier
        ,KiteSoldier
        ,FastSoldier
    }

	void OnDrawGizmos() {

        // ////Player positions
		// Gizmos.color = Color.red;
		// float size = .3f;        
		// Gizmos.DrawLine(PlayerPositions.Left - Vector2.up * size, PlayerPositions.Left + Vector2.up * size);
		// Gizmos.DrawLine(PlayerPositions.Left - Vector2.left * size, PlayerPositions.Left + Vector2.left * size);
		// Gizmos.DrawLine(PlayerPositions.Right - Vector2.up * size, PlayerPositions.Right + Vector2.up * size);
		// Gizmos.DrawLine(PlayerPositions.Right - Vector2.left * size, PlayerPositions.Right + Vector2.left * size);
		// Gizmos.DrawLine(PlayerPositions.Center - Vector2.up * size, PlayerPositions.Center + Vector2.up * size);
		// Gizmos.DrawLine(PlayerPositions.Center - Vector2.left * size, PlayerPositions.Center + Vector2.left * size);

        ////Enemy Spawns Group
		Gizmos.color = Color.red;
		Gizmos.DrawLine(EnemySpawns.SkyUpperLeft, EnemySpawns.SkyLowerRight);
		Gizmos.DrawLine(EnemySpawns.GroundUpperLeft, EnemySpawns.GroundLowerRight);
		Gizmos.DrawLine(EnemySpawns.GroundUpperLeft, EnemySpawns.SkyLowerRight);



	}

}

// public static class PlayerPositions{
//     public static Vector2 Left = new Vector2(-7,0);
//     public static Vector2 Center = new Vector2(0,0);
//     public static Vector2 Right = new Vector2(7,0);
// }
public static class EnemySpawns{
    ////Sky
    public static Vector2 SkyUpperLeft = new Vector2(9.5f, 3.5f);
    public static Vector2 SkyLowerRight = new Vector2(15.5f, -1f);
    
    ////Ground
    public static Vector2 GroundUpperLeft = new Vector2(9.5f, -1f);
    public static Vector2 GroundLowerRight = new Vector2(15.5f, -4);
}