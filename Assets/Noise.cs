using UnityEngine;

public class Noise : MonoBehaviour {
    public GameObject head;

    static float islandRadius = 912f;
    static float noisiness = 0.25f;
    static int width = 1024;
    static int height = 1024;
    static int depth = 128;
    static float scale = 20f;
    static float chance = 0.0001f;
    public int terrainCoordX;
    public int terrainCoordY;
    Terrain terrain;
    void Start() {
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData) {
        terrainData.heightmapResolution = width;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GetHeights());
        return terrainData;
    }
    float[,] GetHeights() {
        float[,] heights = new float[width + 1, height + 1];
        for (int x = 0; x <= width; x++) {
            for (int y = 0; y <= height; y++) {
                float thisX = (float)x;
                float thisY = (float)y;
                float thisHeight;
                float noiseMajor;
                //float noiseMinor = Mathf.PerlinNoise((thisX / width * scale * 5 + randX + 1000), (thisY / height * scale * 5 + randY + 1000)) / divide;
                noiseMajor = GetNoise(terrainCoordX, terrainCoordY, thisX,thisY);
                thisHeight = GetCurrentHeight(terrainCoordX, terrainCoordY, thisX, thisY);
                thisHeight = (1-noisiness)*Mathf.SmoothStep(0, 1, thisHeight) + noisiness * noiseMajor * Mathf.SmoothStep(0, 1, thisHeight);
                //thisHeight = Mathf.SmoothStep(0, 1, thisHeight);
                if (Random.value < chance && thisHeight > 0.5) {
                    CreateHead(terrainCoordX, terrainCoordY, thisX, thisY, thisHeight);
                }
                heights[x, y] = thisHeight;
            }
        }
        return heights;
    }

    float GetNoise(int terrainLeftRight, int terrainUpDown, float Xcoord, float Ycoord) {
        float gottenNoise;
        gottenNoise = Mathf.PerlinNoise(((Xcoord + terrainLeftRight * width) / width * scale + Seed.randX + width), ((Ycoord + terrainUpDown * height) / height * scale + Seed.randY + height));
        return gottenNoise;
    }

    float GetCurrentHeight(int terrainLeftRight, int terrainUpDown, float Xcoord, float Ycoord) {
        float gottenHeight;
        int Xon;
        int Yon;
        if (terrainLeftRight == 1) {
            Xon = 0;
        } else {
            Xon = 1;
        }
        if (terrainUpDown == 1) {
            Yon = 0;
        } else {
            Yon = 1;
        }
        gottenHeight = (Mathf.Max(1 - Mathf.Sqrt(Xon*Mathf.Pow(Xcoord - width + width * terrainLeftRight/2, 2) + Yon*Mathf.Pow(Ycoord - height + height * terrainUpDown / 2, 2)) / islandRadius, 0));
        return gottenHeight;
    }
    
    void CreateHead(int terrainLeftRight, int terrainUpDown, float Xcoord, float Ycoord, float currentHeight) {
        float angle = Random.Range(0f, 360f);
        Instantiate(head, new Vector3(Ycoord + height * terrainUpDown, currentHeight * depth + 3,Xcoord + width * terrainLeftRight), Quaternion.Euler(-90, angle, 0));
    }
}
