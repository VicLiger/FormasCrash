using Autodesk.Navisworks.Api;
using System;

public static void PerformCrash()
{
    // Inicialize o aplicativo Navisworks
    Autodesk.Navisworks.Api.Application app = new Autodesk.Navisworks.Api.Application();
    app.Visible = true;

    // Substitua "ModeloPlanta" e "ModeloNuvemPontos" pelos caminhos reais dos arquivos
    string modeloPlanta = @"Caminho\para\sua\maquete3D.nwd";
    string modeloNuvemPontos = @"Caminho\para\sua\nuvemDePontos.nwc";

    // Abra o arquivo da maquete 3D
    Autodesk.Navisworks.Api.ModelItem modelItemPlanta = app.ActiveDocument.Models.OpenFile(modeloPlanta);

    // Anexe o arquivo da nuvem de pontos
    Autodesk.Navisworks.Api.ModelItem modelItemNuvemPontos = app.ActiveDocument.Models.AppendFile(modeloNuvemPontos);

    // Configurar as opções de crash
    CrashTestOptions options = new CrashTestOptions();
    options.CalculateMaterials = true; // Calcule os materiais
    options.DefineTolerance = true; // Definir tolerância
    options.Tolerance = 0.01; // Definir a tolerância
    options.DefineSolid = true; // Definir sólido
    options.DefinePoint = true; // Definir ponto
    options.ResolvePoint = true; // Resolver ponto

    // Realizar o crash com as opções configuradas
    ModelItemCrashTestResult crashResult = modelItemPlanta.CrashTest(modelItemNuvemPontos, options);

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
}
