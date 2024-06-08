namespace cguambaS2.vistas;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            validarCampos();

            string estudiante = pkEstudiantes.SelectedItem.ToString();
            double numSegP1 = obtieneDoubleYValidaEntradaNumerica(txtNumSegP1);
            double numExamP1 = obtieneDoubleYValidaEntradaNumerica(txtNumExamP1);
            double numSegP2 = obtieneDoubleYValidaEntradaNumerica(txtNumSegP2);
            double numExamP2 = obtieneDoubleYValidaEntradaNumerica(txtNumExamP2);
            string fechaRegistro = dpFecha.Date.ToShortDateString();        

            double notaParcial1 = calculaProporcion(numSegP1, numExamP1);
            double notaParcial2 = calculaProporcion(numSegP2, numExamP2);

            double final = notaParcial1 + notaParcial2;

            lblNotaParcial1.Text = "Nota Parcial (1): " + notaParcial1.ToString();
            lblNotaParcial2.Text = "Nota Parcial (2): " + notaParcial2.ToString();

            lblNotaFinal.Text = "Nota Final: " + final.ToString();

            DisplayAlert("MENSAJE DE BIENVENIDA",
                "Bienvenido " +
                "\nEste es el detalle del registro para el estudiante: " + estudiante+
                "\nNota Seguimiento 1:\t" + numSegP1+
                "\nNota Examen 1:\t\t" + numExamP1 +
                "\nNota Parcial 1:\t\t" + notaParcial1 +
                "\n\nNota Seguimiento 2:\t" + numSegP2+
                "\nNota Examen 2:\t\t" + numExamP2 +
                "\nNota Parcial 2:\t\t" + notaParcial2 +
                "\n\nNOTA FINAL 2:\t" + final +
                "\n\nFecha del registro 2:\t" + fechaRegistro, "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }
    }

    private double calculaProporcion(double numSeg, double numExam)
    {
        return Math.Round( (numSeg*0.02) + (numExam*0.03) , 2);
    }

    private double obtieneDoubleYValidaEntradaNumerica(Entry txtEntry)
    {
        try
        {
            double valor = Convert.ToDouble(txtEntry.Text);
            if (valor > 10)
            {
                throw new Exception("El valor no puede ser mayor a 10");
            }
            if (string.IsNullOrWhiteSpace(txtEntry.Text))
            {
                txtEntry.Focus();
                throw new Exception("Campo es obligatorio");
            }
            return valor;
        }
        catch (Exception ex)
        {
            txtEntry.Focus();
            throw new Exception("Error al con el campo númerico (Entero con decimales separado por coma), por favor corrija el valor y vuelva a intentar. "+ex.Message.ToString());
        }
    }

    private void validarCampos()
    {

        try
        {
            if (string.IsNullOrWhiteSpace(pkEstudiantes.SelectedItem.ToString()))
            {
                pkEstudiantes.Focus();
                throw new Exception("Por favor elija un estudiante.");
            }
        }
        catch (Exception ex)
        {
            pkEstudiantes.Focus();
            throw new Exception("Por favor seleccione un estudiante." + ex.Message.ToString());
        }

    }
}