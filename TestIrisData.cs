using System;
using System.Collections.Generic;
using System.Text;

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
 */

namespace Flores_de_Iris
{
    static class TestIrisData
    {
        internal static readonly IrisData Setosa = new IrisData
        {
            SepalLength = 5.1f,
            SepalWidth = 3.5f,
            PetalLength = 1.4f,
            PetalWidth = 0.2f
        };



    }
}
