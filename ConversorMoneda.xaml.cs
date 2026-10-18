namespace ProyectoFinalPrimerParcial;

public partial class ConversorMoneda : ContentPage
{
    // Tasas de cambio (constantes respecto a USD)
    private const double TASA_HNL = 24.75;
    private const double TASA_EUR = 1.08;
    private const double TASA_MXN = 17.00;

    public ConversorMoneda()
    {
        InitializeComponent();
    }

    private async void OnConvertirClicked(object sender, EventArgs e)
    {
        // Validar que el campo no esté vacío y sea numérico
        if (string.IsNullOrWhiteSpace(txtMonto.Text) || !double.TryParse(txtMonto.Text, out double monto))
        {
            await DisplayAlert("Error", "Por favor ingrese un monto numérico válido (sin letras ni espacios).", "OK");
            return;
        }

        // Validar que el monto sea mayor a 0
        if (monto <= 0)
        {
            await DisplayAlert("Error", "El monto a convertir debe ser mayor a 0.", "OK");
            return;
        }

        // Validar que se hayan seleccionado ambas monedas
        if (pckOrigen.SelectedIndex == -1 || pckDestino.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Por favor seleccione la moneda de origen y la de destino.", "OK");
            return;
        }

        // Conversión a USD como moneda base
        double montoEnUSD = pckOrigen.SelectedIndex switch
        {
            0 => monto / TASA_HNL, // HNL
            1 => monto,            // USD
            2 => monto * TASA_EUR, // EUR
            3 => monto / TASA_MXN, // MXN
            _ => monto
        };

        // Conversión de USD a la moneda destino
        double resultado = pckDestino.SelectedIndex switch
        {
            0 => montoEnUSD * TASA_HNL, // HNL
            1 => montoEnUSD,            // USD
            2 => montoEnUSD / TASA_EUR, // EUR
            3 => montoEnUSD * TASA_MXN, // MXN
            _ => montoEnUSD
        };

        // Obtener el símbolo de la moneda destino
        string simbolo = pckDestino.SelectedIndex switch
        {
            0 => "L",
            1 => "$",
            2 => "€",
            3 => "$",
            _ => ""
        };

        // Mostrar resultado formateado
        lblResultado.Text = $"Resultado: {simbolo} {resultado:N2}";
    }

    private void OnLimpiarClicked(object sender, EventArgs e)
    {
        txtMonto.Text = string.Empty;
        pckOrigen.SelectedIndex = -1;
        pckDestino.SelectedIndex = -1;
        lblResultado.Text = string.Empty;
    }
}