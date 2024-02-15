using Autodesk.Navisworks.Api;
using System;

public static void PerformCrash()
{
    // Inicialize o aplicativo Navisworks
    NavisworksApplication app = new NavisworksApplication();
    app.Visible = true;

    // Substitua "ModeloPlanta" e "ModeloNuvemPontos" pelos caminhos reais dos arquivos
    string modeloPlanta = @"Caminho\para\sua\maquete3D.nwd";
    string modeloNuvemPontos = @"Caminho\para\sua\nuvemDePontos.nwc";

    // Abra o arquivo da maquete 3D
    Document modelDoc = app.OpenFile(modeloPlanta);

    // Anexe o arquivo da nuvem de pontos
    Document pointCloudDoc = app.AppendFile(modelDoc, modeloNuvemPontos);

    // Realize o crash com configurações padrão
    ModelItemCrashTestResult crashResult = modelDoc.Models.CreateCrashTest();

    if (crashResult != null)
    {
        Console.WriteLine("Crash realizado com sucesso!");
        Console.WriteLine($"Número de pontos: {crashResult.Points.Count}");
        Console.WriteLine($"Número de sólidos: {crashResult.Solids.Count}");
    }
    else
    {
        Console.WriteLine("Falha ao realizar o crash.");
    }

    // Fechar o aplicativo Navisworks
    app.Dispose();
}
