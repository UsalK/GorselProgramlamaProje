namespace GorselProgramlamaProje;

public partial class krediHesaplama : ContentPage
{
    double BSMV, KKDF;

    public krediHesaplama()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (creditTypePicker.SelectedIndex == -1)
        {
            return;
        }

        if (string.IsNullOrEmpty(oran.Text) || string.IsNullOrEmpty(vade.Text) || string.IsNullOrEmpty(kredi.Text))
        {
            return;
        }

        double oranValue = 0, vadeValue = 0, krediValue = 0;

        try
        {
            oranValue = double.Parse(oran.Text);
            vadeValue = double.Parse(vade.Text);
            krediValue = double.Parse(kredi.Text);
        }
        catch (FormatException)
        {
            return; 
        }

        KrediHesaplama(oranValue, vadeValue, krediValue);
    }

    private void KrediHesaplama(double Oran, double Vade, double Tutar)
    {
        double brutFaiz = (Oran + (Oran * BSMV) + (Oran * KKDF)) / 100;          // Toplam faiz
        double taksit = ((Math.Pow(1 + brutFaiz, Vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, Vade) - 1)) * Tutar;
        double toplam = taksit * Vade;
        double fFaiz = toplam - Tutar;

        result1.Text = $"{taksit:C}"; // Aylýk taksit
        result2.Text = $"{toplam:C}"; // Toplam ödeme
        result3.Text = $"{fFaiz:C}";  // Toplam faiz
    }

    private void creditTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {

        var selectedCreditType = creditTypePicker.SelectedItem as string;

        if (selectedCreditType == null || selectedCreditType == "Kredi türünü seçiniz")
        {
            return;
        }

        if (selectedCreditType == "Ýhtiyaç Kredisi")
        {
            krediName.Text = "Ýhtiyaç Kredisi";
            KKDF = 0.15; // 15%
            BSMV = 0.10; // 10%
        }
        else if (selectedCreditType == "Konut Kredisi")
        {
            krediName.Text = "Konut Kredisi";
            KKDF = 0;    // 0%
            BSMV = 0;    // 0%
        }
        else if (selectedCreditType == "Taþýt Kredisi")
        {

            krediName.Text = "Taþýt Kredisi";
            KKDF = 0.15; // 15%
            BSMV = 0.05; // 5%
        }
        else if (selectedCreditType == "Ticari Kredisi")
        {
            krediName.Text = "Ticari Kredisi";
            KKDF = 0;    // 0%
            BSMV = 0.05; // 5%
        }
    }
}
