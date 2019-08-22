using System.ComponentModel;

namespace DemoSuframa
{
    public enum EnumPerfil
    {
        [Description("CADSUF PESSOA JURIDICA - INSCRICAO CADASTRAL")]
        Importador = 1,

        [Description("SCIEX Analista")]
        Analista = 2,

        [Description("SCIEX Coordenador")]
        Coordenador = 3,

        [Description("PESSOA FISICA - PREPOSTO")]
        Preposto = 4,

    }


}