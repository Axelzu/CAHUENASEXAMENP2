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
            chisteLabel.Text = $"{response.Setup}\n\n{response.Punchline}";
        }
        catch
        {
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