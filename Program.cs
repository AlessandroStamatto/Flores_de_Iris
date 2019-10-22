using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Flores_de_Iris
{
    class Program
    {
        //Caminho dos dados "brutos" advindos do iris.data
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "iris.data");
        
        //Caminho do modelo de aprendizado a ser construído, e então utilizado pela previsão KNN
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");
        static void Main(string[] args)
        {
            //Semeia a aleatoriedade
            var mlContext = new MLContext(seed: 0);

            //Carrega os dados "brutos" de Flores de Iris
            IDataView dataView = mlContext.Data.LoadFromTextFile<IrisData>(_dataPath, hasHeader: false, separatorChar: ',');

            //Pipeline de aprendizado: concatena as 4 dimensões e define um modelo KNN
            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
                .Concatenate(featuresColumnName, "SepalLength", "SepalWidth", "PetalLength", "PetalWidth")
                .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));

            //Executa o pipeline de aprendizado para criar o Modelo KNN
            var model = pipeline.Fit(dataView);

            //Salva o modelo KNN como o IrisClusteringModel.zip
            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                mlContext.Model.Save(model, dataView.Schema, fileStream);
            }

            //Cria um motor de previsão utilizando o Modelo KNN gerado
            var predictor = mlContext.Model.CreatePredictionEngine<IrisData, ClusterPrediction>(model);

            //Faz uma previsão de qual tipo de flor seria a definida em TestIrisData.cs
            var prediction = predictor.Predict(TestIrisData.Setosa);
            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");
        }
    }
}
