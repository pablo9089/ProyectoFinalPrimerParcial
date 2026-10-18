using Microsoft.Extensions.DependencyInjection;

namespace ProyectoFinalPrimerParcial
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Creamos el contenedor de pestañas
            var tabbedPage = new TabbedPage();

            // 1. PRIMERA PESTAÑA (Se mostrará por defecto al abrir la app)
            tabbedPage.Children.Add(new CalculadoraIMC
            {
                Title = "Calculadora IMC"
            });

            // 2. SEGUNDA PESTAÑA
            tabbedPage.Children.Add(new ConversorMoneda
            {
                Title = "Conversor Moneda"
            });

            // Retornamos la ventana con las pestañas configuradas
            return new Window(tabbedPage);
        }
    }
}