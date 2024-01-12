namespace QuirkyCarRepair.DAL.Areas.Shared.Enums
{
    public enum OrderType
    {
        WW = 0, // Wydanie wewnętrzne
        WZ = 1, // Wydanie zewnętrzne
        ZZ = 2, // Zwrot zewnętrzny
        ZW = 3, // Zwrot wewnętrzny
        R = 4, // Reklamacja do producenta
        D = 5, // Dostawa
        ZS = 6 // Zlecenie serwisowe
    }
}