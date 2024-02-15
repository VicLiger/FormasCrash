using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api.Interop.ComApi;
using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.Interop.ComApi.ComApiBridge;
using ComApiGeometry = Autodesk.Navisworks.Api.Geometry.ComApi;
using System;
using System.Linq;

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

    // Obter a seleção combinada dos modelos
    DocumentSelection selection = app.ActiveDocument.CurrentSelection;

    // Configurar as opções de crash
    var crashOptions = new CrashTestOptions();
    crashOptions.UseXData = true; // Use os dados de extensão (se disponíveis)
    crashOptions.CalculateMaterials = true; // Calcule os materiais
    crashOptions.DefineTolerance = true; // Definir tolerância
    crashOptions.DefineSolid = true; // Definir sólido
    crashOptions.DefinePoint = true; // Definir ponto
    crashOptions.ResolvePoint = true; // Resolver ponto

    // Realizar o crash
    ModelItemCrashTestResult crashResult = selection.CreateCrashTest(crashOptions);

    // Verificar o resultado do crash
    if (crashResult != null)
    {
        Console.WriteLine("Crash realizado com sucesso!");

        // Exibir informações sobre o crash
        Console.WriteLine($"Número de pontos: {crashResult.Points.Count}");
        Console.WriteLine($"Número de sólidos: {crashResult.Solids.Count}");

        // Você pode fazer mais operações com os resultados do crash aqui, se necessário
    }
    else
    {
        Console.WriteLine("Falha ao realizar o crash.");
    }

    // Fechar o aplicativo Navisworks
    app.Dispose();
}
