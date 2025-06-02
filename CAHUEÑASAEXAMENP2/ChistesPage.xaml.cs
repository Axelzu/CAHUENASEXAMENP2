using System.Net.Http.Json;

namespace CAHUEÑASAEXAMENP2;

public partial class ChistesPage : ContentPage
{
    HttpClient client = new HttpClient();

    public ChistesPage()
    {
        InitializeComponent();
        CargarChiste();
    }

    private async void CargarChiste()
    {
        try
        {
            var response = await client.GetFromJsonAsync<Chiste>("https://official-joke-api.appspot.com/random_joke");

            if (response != null)
                chisteLabel.Text = $"{response.Setup}\n\n{response.Punchline}";
            else
                chisteLabel.Text = "No se recibió ningún chiste.";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo cargar el chiste: {ex.Message}", "OK");
            chisteLabel.Text = "Error al cargar el chiste.";
        }
    }

    private void OnNuevoChisteClicked(object sender, EventArgs e)
    {
        CargarChiste();
    }

    public class Chiste
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }
}   