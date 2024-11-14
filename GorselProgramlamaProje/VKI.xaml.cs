using Microsoft.Maui.Controls;

namespace GorselProgramlamaProje
{
    public partial class VKI : ContentPage
    {
        public VKI()
        {
            InitializeComponent();
        }

        private void weightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double weight = e.NewValue;
            weightLabel.Text = $"{weight:0} KG";
            CalculateVKI();
        }

        private void heightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double height = e.NewValue;
            heightLabel.Text = $"{height:0} CM";
            CalculateVKI();
        }

        private void CalculateVKI()
        {
            double weight = weightSlider.Value;
            double height = heightSlider.Value;

            height = height / 100;

            double vki = weight / (height * height);

            vkiResultLabel.Text = $"VKÝ: {vki:0.00}";

            if (vki < 16)
            {
                vkiStatusLabel.Text = "Ýleri Düzeyde Zayýf";
                vkiStatusLabel.TextColor = Color.FromRgb(255, 0, 0); // Kýrmýzý
            }
            else if (vki >= 16 && vki <= 16.99)
            {
                vkiStatusLabel.Text = "Orta Düzeyde Zayýf";
                vkiStatusLabel.TextColor = Color.FromRgb(255, 165, 0); // Turuncu
            }
            else if (vki >= 17 && vki <= 18.49)
            {
                vkiStatusLabel.Text = "Hafif Düzeyde Zayýf";
                vkiStatusLabel.TextColor = Color.FromRgb(255, 255, 0); // Sarý
            }
            else if (vki >= 18.50 && vki <= 24.9)
            {
                vkiStatusLabel.Text = "Normal Kilolu";
                vkiStatusLabel.TextColor = Color.FromRgb(0, 255, 0); // Yeþil
            }
            else if (vki >= 25 && vki <= 29.99)
            {
                vkiStatusLabel.Text = "Hafif Þiþman / Fazla Kilolu";
                vkiStatusLabel.TextColor = Color.FromRgb(255, 255, 0); // Sarý
            }
            else if (vki >= 30 && vki <= 34.99)
            {
                vkiStatusLabel.Text = "1. Derecede Obez";
                vkiStatusLabel.TextColor = Color.FromRgb(255, 165, 0); // Turuncu
            }
            else if (vki >= 35 && vki <= 39.99)
            {
                vkiStatusLabel.Text = "2. Derecede Obez";
                vkiStatusLabel.TextColor = Color.FromRgb(255, 0, 0); // Kýrmýzý
            }
            else
            {
                vkiStatusLabel.Text = "3. Derecede Obez / Morbid Obez";
                vkiStatusLabel.TextColor = Color.FromRgb(139, 0, 0); // Koyu Kýrmýzý
            }
        }
    }
}
