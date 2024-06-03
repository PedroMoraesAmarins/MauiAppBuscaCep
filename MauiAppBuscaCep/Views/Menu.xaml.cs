namespace MauiAppBuscaCep.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}

    private void Button_Clicked_buscacep(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.BuscaCepPorLogradouro());
    }

    private void Button_Clicked_buscaendereco(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void Button_Clicked_buscabairro(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.BairrosPorCidade());
    }

    private void Button_Clicked_buscarua(object sender, EventArgs e)
    {
        
    }
}