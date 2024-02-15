using System;
using ComApi = Autodesk.Navisworks.Api.Interop.ComApi;
using ComApiBridge = Autodesk.Navisworks.Api.Interop.ComApi.ComApiBridge;

public static void PerformCrash()
{
    // Criar uma instância do aplicativo Navisworks através da interface COM
    ComApi.InwOpState10 oState = ComApiBridge.State;
    ComApi.InwOpSelection oSel = oState.CurrentSelection;
    ComApi.InwNwDatabase oDB = oState.CurrentSelection.Database;

    // Substitua "ModeloPlanta" e "ModeloNuvemPontos" pelos caminhos reais dos arquivos
    string modeloPlanta = @"Caminho\para\sua\maquete3D.nwd";
    string modeloNuvemPontos = @"Caminho\para\sua\nuvemDePontos.nwc";

    // Carregar os modelos
    oState.Models.OpenFile(modeloPlanta);
    oState.Models.AppendFile(modeloNuvemPontos);

    // Configurar as opções de crash
    ComApi.InwOaPath3D crashPath = oState.ObjectFactory.CreatePath();
    crashPath.Tolerance = 0.01;
    crashPath.UseTolerance = true;

    // Executar o crash
    ComApi.InwOaCrashTestResults crashResults = oState.Crash3D(crashPath, false);

    if (crashResults != null)
    {
        Console.WriteLine("Crash realizado com sucesso!");
        Console.WriteLine($"Número de pontos: {crashResults.GetPoints(null, null, 0).Count}");
        Console.WriteLine($"Número de sólidos: {crashResults.GetSolids(null, 0).Count}");
    }
    else
    {
        Console.WriteLine("Falha ao realizar o crash.");
    }

    // Fechar o aplicativo Navisworks
    oState.Dispose();
}
