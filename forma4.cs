using Autodesk.Navisworks.Api;
using System;

public static void PerformCrash()
{
    // Inicialize o aplicativo Navisworks
    NavisworksApplication app = new NavisworksApplication();
    app.Visible = true;

    // Crie um novo documento
    Document doc = app.Document;

    // Substitua "ModeloPlanta" e "ModeloNuvemPontos" pelos caminhos reais dos arquivos
    string modeloPlanta = @"Caminho\para\sua\maquete3D.nwd";
    string modeloNuvemPontos = @"Caminho\para\sua\nuvemDePontos.nwc";

    // Carregar os modelos diretamente para o documento
    doc.Models.ResolveAddinsPath();
    doc.Models.AppendFile(modeloPlanta);
    doc.Models.AppendFile(modeloNuvemPontos);

    // Realize o crash com configurações padrão
    ModelItemCrashTestResult crashResult = doc.Models.CreateCrashTest();

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
