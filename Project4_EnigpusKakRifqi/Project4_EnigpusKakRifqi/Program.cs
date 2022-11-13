using Project4_EnigpusKakRifqi.Services;
using Project4_EnigpusKakRifqi.Views;

public class Program
{
    public static void Main(string[] args)
    {
        IInventoryService service = new InventoryService();
        EnigpusMenu menu = new EnigpusMenu(service);
        menu.MainMenu();
    }
}