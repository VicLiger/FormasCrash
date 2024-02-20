using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Clash;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashPlugin
{
    [PluginAttribute("PluginClash",
                       "ADSK",
                       ToolTip = "PluginClashIn.Clash tool tip",
                       DisplayName = "Plugin Clash")]
    public class Clash : AddInPlugin
    {

        Autodesk.Navisworks.Api.Automation.NavisworksApplication app = new Autodesk.Navisworks.Api.Automation.NavisworksApplication();
        private string clashName = "Teste";

        public override int Execute(params string[] parameters)
        {
            string pathModel = @"D:\Victor\OpenFolder\OpenFolder\Project\Q1_aro_ii.nwd";
            string pathNuvem = @"D:\Victor\OpenFolder\OpenFolder\Project\ID2021-0317_r0_Braskem-BA_Q1_UA2_NP_Z6_r1_SB.rcp";

            app.Visible = true;
            app.OpenFile(pathModel);
            app.AppendFile(pathNuvem);

            var doc = Autodesk.Navisworks.Api.Application.ActiveDocument; // Obtém referência para o documento aberto atual
            DocumentClash clash = doc.GetClash(); // Permite acessar e gerenciar os testes de clash no documento
            DocumentClashTests clashTests = clash.TestsData; // Permite obter um retorno das informações do testes anteriomente realizados

            var clashTest = new ClashTest { CustomTestName = clashName };
            clashTest.DisplayName = clashTest.CustomTestName;

            // Define as configurações para a verificação de clash
            clashTest.TestType = ClashTestType.Clearance;
            clashTest.Tolerance = 10;

            clashTest.SelectionA.SelfIntersect = false;
            clashTest.SelectionA.PrimitiveTypes = PrimitiveTypes.Triangles;

            clashTest.SelectionB.SelfIntersect = false;
            clashTest.SelectionB.PrimitiveTypes = PrimitiveTypes.Points;



            return 0;
        }
    }
}

