namespace ProyectoFinalPrimerParcial;

public partial class CalculadoraIMC : ContentPage
{
    public CalculadoraIMC()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Validar que los campos no estén vacíos y contengan valores numéricos mayores a cero para evitar errores de cálculo o división por cero
        if (!double.TryParse(txtPeso.Text, out double peso) || peso <= 0 ||
            !double.TryParse(txtAltura.Text, out double altura) || altura <= 0)
        {
            // Mostrar una alerta en pantalla si la validación de entrada falla
            await DisplayAlert("Error", "Por favor ingrese valores numéricos válidos mayores a 0", "Ok");
            return;
        }

        // Calcular el índice de masa corporal aplicando la fórmula estándar: peso dividido entre la altura al cuadrado
        double imc = peso / (altura * altura);

        // Formatear el valor numérico del IMC para mostrarlo con un solo decimal en la etiqueta correspondiente
        lblValorIMC.Text = imc.ToString("F1");

        // Evaluar en qué rango se encuentra el IMC calculado para asignar colores personalizados y textos de diagnóstico clínico
        if (imc < 18.5)
        {
            // Configurar la interfaz visual para el estado de bajo peso con tonos rojizos
            lblValorIMC.TextColor = Color.FromArgb("#C0392B");
            lblDiagnostico.Text = "Bajo peso";
            lblDiagnostico.TextColor = Color.FromArgb("#C0392B");
            brResultado.BackgroundColor = Color.FromArgb("#FDEDEC");
            brResultado.Stroke = Color.FromArgb("#F5B7B1");
        }
        else if (imc <= 24.9)
        {
            // Configurar la interfaz visual para el estado de peso normal con tonos verdes saludables
            lblValorIMC.TextColor = Color.FromArgb("#196F3D");
            lblDiagnostico.Text = "Peso normal";
            lblDiagnostico.TextColor = Color.FromArgb("#196F3D");
            brResultado.BackgroundColor = Color.FromArgb("#EAFAF1");
            brResultado.Stroke = Color.FromArgb("#A9DFBF");
        }
        else if (imc <= 29.9)
        {
            // Configurar la interfaz visual para el estado de sobrepeso utilizando tonalidades amarillentas/doradas
            lblValorIMC.TextColor = Color.FromArgb("#B7950B");
            lblDiagnostico.Text = "Sobrepeso";
            lblDiagnostico.TextColor = Color.FromArgb("#B7950B");
            brResultado.BackgroundColor = Color.FromArgb("#FEF9E7");
            brResultado.Stroke = Color.FromArgb("#F9E79F");
        }
        else if (imc <= 34.9)
        {
            // Configurar la interfaz visual para obesidad leve empleando tonos anaranjados
            lblValorIMC.TextColor = Color.FromArgb("#D35400");
            lblDiagnostico.Text = "Obesidad leve";
            lblDiagnostico.TextColor = Color.FromArgb("#D35400");
            brResultado.BackgroundColor = Color.FromArgb("#FBEEE6");
            brResultado.Stroke = Color.FromArgb("#F5CBA7");
        }
        else if (imc <= 39.9)
        {
            // Configurar la interfaz visual para obesidad moderada con matices púrpuras
            lblValorIMC.TextColor = Color.FromArgb("#8E44AD");
            lblDiagnostico.Text = "Obesidad Moderada";
            lblDiagnostico.TextColor = Color.FromArgb("#8E44AD");
            brResultado.BackgroundColor = Color.FromArgb("#F4ECF7");
            brResultado.Stroke = Color.FromArgb("#D7BDE2");
        }
        else
        {
            // Configurar la interfaz visual para obesidad mórbida con tonos vino oscuros de alerta
            lblValorIMC.TextColor = Color.FromArgb("#641E16");
            lblDiagnostico.Text = "Obesidad Mórbida";
            lblDiagnostico.TextColor = Color.FromArgb("#641E16");
            brResultado.BackgroundColor = Color.FromArgb("#FADBD8");
            brResultado.Stroke = Color.FromArgb("#E6B0AA");
        }

        // Cambiar la propiedad IsVisible a verdadero para revelar la tarjeta con los resultados en la interfaz gráfica
        brResultado.IsVisible = true;

        // Asignar el texto explicativo con los rangos de referencia oficiales de la OMS a la etiqueta informativa inferior
        lblRangosExplicacion.Text = "Rangos de referencia:\n" +
                                    "• Menor a 18.5: Bajo peso\n" +
                                    "• 18.5 - 24.9: Peso normal\n" +
                                    "• 25.0 - 29.9: Sobrepeso\n" +
                                    "• 30.0 - 34.9: Obesidad leve\n" +
                                    "• 35.0 - 39.9: Obesidad moderada\n" +
                                    "• Mayor o igual a 40: Obesidad mórbida";
        lblRangosExplicacion.IsVisible = true;
    }

    private void OnLimpiarClicked(object sender, EventArgs e)
    {
        // Restablecer todos los campos de entrada y vaciar los textos de las etiquetas de resultados
        txtPeso.Text = string.Empty;
        txtAltura.Text = string.Empty;
        lblValorIMC.Text = string.Empty;
        lblDiagnostico.Text = string.Empty;
        lblRangosExplicacion.Text = string.Empty;

        // Ocultar nuevamente la tarjeta contenedora de resultados estableciendo su visibilidad en falso
        brResultado.IsVisible = false;
    }
}