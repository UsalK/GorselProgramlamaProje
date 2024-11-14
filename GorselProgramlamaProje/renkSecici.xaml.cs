namespace GorselProgramlamaProje;

public partial class renkSecici : ContentPage
{
    double red = 0, green = 0, blue = 0;
    Random random = new Random();

    public renkSecici()
    {
        InitializeComponent();
    }

    private void ChangeColor()
    {
       // colorLayer.BackgroundColor = Color.FromRgb(red / 255, green / 255, blue / 255);
        backgroundLayer.BackgroundColor = Color.FromRgb(red / 255, green / 255, blue / 255);
        colorCodeLabel.Text = RgbToHex((int)red, (int)green, (int)blue);


    }

    private void redSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        red =(int) e.NewValue;
        ChangeColor();
    }

    private void blueSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        blue =(int) e.NewValue;
        ChangeColor();
    }

    private async void copyButton_Clicked(object sender, EventArgs e)
    {

        String code = RgbToHex((int)red,(int)green, (int)blue);

        await Clipboard.SetTextAsync(code);
        await DisplayAlert("Baþarýlý", code + " kodu panoya kopyalandý.", "Tamam");


    }

    private string RgbToHex(int red, int green, int blue)
    {
        red = Math.Clamp(red, 0, 255);
        green = Math.Clamp(green, 0, 255);
        blue = Math.Clamp(blue, 0, 255);

        return $"#{red:X2}{green:X2}{blue:X2}";
    }

    private void greenSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        green =(int) e.NewValue;
        ChangeColor();
    }

    private void RandomButton_Clicked(object sender, EventArgs e)
    {
        red = random.Next(0, 256);
        green = random.Next(0, 256);
        blue = random.Next(0, 256);

        redSlider.Value = red;
        greenSlider.Value = green;
        blueSlider.Value = blue;

        ChangeColor();
    }
}
