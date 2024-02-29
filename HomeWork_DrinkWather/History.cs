namespace HomeWork_DrinkWather.Menyu;

public  struct History
{
    public DateTime DateDrink {  get; set; }
    public double DrinkWatherLT { get; set; }

    public History(DateTime dateDrink, double drinkWatherLT)
    {
        DateDrink = dateDrink;
        DrinkWatherLT = drinkWatherLT;
    }

    public override string ToString() => $"Vaxt-> {DateDrink.ToString()}\nIcdiyiniz Suyun Miqadari-> {DrinkWatherLT}";
}
