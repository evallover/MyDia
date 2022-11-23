namespace MyDiary
{
    internal class Program
    {
        static List<Day> dailyplan = Days();

        static void Main(string[] args)
        {
            int index = 1;
            Console.WriteLine("Ну вот что-то по типу дневника!\n" +
                "Для того, чтобы переключиться между датами, нужно пользоваться стрелочками вправо и влево\n" +
                "Если вы хотите переключиться между пунктами, то нажмите на стрелочки вверх и вниз\n" +
                "Для выбора определенного пункта нажмите клавишу Enter\n" +
                "Ну, а для добавления новой записи нужно нажать клавишу N!\n" +
                "Для того чтобы покинуть мой дневник, нужно просто нажать ESC :)");
            DateTime day = DateTime.Now;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 1)
                    {
                        index = 2;
                    }
                    index--;
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (index >= 2)
                    {
                        index = 1;
                    }
                    index++;
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    index = 1;
                    day = day.AddDays(-1);
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    index = 1;
                    day = day.AddDays(+1);
                }

                if (key.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("Создание новой записи в дневник:");
                    Console.WriteLine("--------------------------------------");
                    NewPlan();
                }

                Console.Clear();
                Console.WriteLine("Выбрана дата: " + day.ToShortDateString());

                for (int i = 0; i < dailyplan.Count; i++)
                {
                    if (dailyplan[i].Date.Date == day.Date)
                    {
                        Console.WriteLine("  " + dailyplan[i].DayPlan);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            Console.WriteLine(dailyplan[i].Task);
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine(dailyplan[i].Description);
                            Console.WriteLine("Выбрана дата: " + dailyplan[i].Date);
                        }
                    }
                }
                Console.SetCursorPosition(0, index);
                Console.WriteLine("->");
            }
        }

        static List<Day> Days()
        {
            List<Day> dailyplan = new List<Day>();

            Day  first = new Day();
            first.DayPlan = "1. Потусоваться у Аришки!";
            first.Task = "Потусоваться у Аришки";
            first.Description = "Описание: Приехать к Ришкинсу на Ярославку в общежитие МГПУ;\n" +
                "Порассуждать о том, куда уходят все деньги и думать когда пойдем в зал, как говорится, делать анжуманя и пресс качат\n" +
                "Потусить там до 21:59, потому что в 22:00 оттуда уже выгоняют с овчарками, не шучу!";
            first.Date = new DateTime(2022, 11, 20);
            dailyplan.Add(first);

            Day second = new Day();
            second.DayPlan = "2. Поговорить с папой по Фейстайму";
            second.Task = "Поговорить с папой по Фейстайму";
            second.Description = "  Описание: Приехать после Аришки домой и позвонить папе\n" +
                "Рассказать о последних событиях и сказать как скучаю и хочу домой в Севастополь:(";
            second.Date = new DateTime(2022, 11, 20);
            dailyplan.Add(second);

            Day third = new Day();
            third.DayPlan = "1. Позвонить любимой подружке!";
            third.Task = "Позвонить подружке";
            third.Description = "Описание: Поговорить с Лизой и послушать ее интересные истории с халяля\n" +
                "Послушать о том, какие вкусные бургеры в Симферопольском халяле и какие там красивые татары\n" +
                "Татары, конечно, не в моем вкусе, но вот бургеры конечно попробовать хочется после таких рассказов!!";
            third.Date = new DateTime(2022, 11, 21);
            dailyplan.Add(third);

            Day fourth = new Day();
            fourth.DayPlan = "2. Убраться в комнате";
            fourth.Task = "(не)любимая уборка";
            fourth.Description = "  Описание: Привести в порядок свою комнату, то каждый раз откладываю, ну  вот и наоткладывала...\n" +
                "Ставьте плюс, если тоже не любите убираться.. просто я не люблю.. минифанфакт обо мне получился!";
            fourth.Date = new DateTime(2022, 11, 21);
            dailyplan.Add(fourth);

            Day fifth = new Day();
            fifth.DayPlan = "1. Сходить за продуктами";
            fifth.Task = "Поход в пятерочку";
            fifth.Description = "Описание: Купить в пятерочке овощную смесь и курочку, чтобы вкусно и полезно покушать!";
            fifth.Date = new DateTime(2022, 11, 22);
            dailyplan.Add(fifth);

            return dailyplan;
        }

        static void NewPlan()
        {
            for (int i = 0; i < 1; i++)
            {
                Day newdayplan = new Day();
                Console.WriteLine("Введите план на день: ");
                newdayplan.DayPlan = Console.ReadLine();
                Console.WriteLine("Введите название: ");
                newdayplan.Task = Console.ReadLine();
                Console.WriteLine("Введите описание о заметке: ");
                newdayplan.Description = Console.ReadLine();
                Console.WriteLine("Введите дату (в формате гггг, мм, дд): ");
                newdayplan.Date = Convert.ToDateTime(Console.ReadLine());
                dailyplan.Add(newdayplan);

                Console.WriteLine("\n");
            }
        }
    }
}