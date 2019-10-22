using System;
using Microsoft.ML.Data;

/**
 *  Cada Flor de Iris é medida em 4 dimensões:
 *  - O comprimento da sépala
 *  - A largura da sépala
 *  - O comprimento da pétala
 *  - A largura da pétala
 *  
 *  Com isso uma Flor de Iris pode ser classificada entre os 3 tipos:
 *  - Setosa
 *  - Versicolor
 *  - Virginica
 *  
 *  Como o algoritmo utiliza KNN as amostras são divididas em 3 Clusters 
 *  onde cada Cluster representa um tipo de Flor de Iris. Dada uma flor
 *  a classificação indica a distância da mesma para cada Cluster, quanto
 *  mais próximo de um Cluster maior a chance da Flor ser daquele tipo.
 *  
 */

public class IrisData
{
    [LoadColumn(0)]
    public float SepalLength;

    [LoadColumn(1)]
    public float SepalWidth;

    [LoadColumn(2)]
    public float PetalLength;

    [LoadColumn(3)]
    public float PetalWidth;
}

public class ClusterPrediction
{
    [ColumnName("PredictedLabel")]
    public uint PredictedClusterId;

    [ColumnName("Score")]
    public float[] Distances;
}
