namespace lab5;

public static class Constants
{
    public const int CountOfContenders = 100;

    public const int CountSkipContenders = 4;

    public const int CountAttempts = 100;

    private static readonly List<string> NamesTemplate = new()
    {
        "Абрам", "Аваз", "Аввакум", "Август", "Авдей", "Авраам", "Автандил", "Агап", "Агафон", "Аггей", "Адам", "Адис",
        "Адольф", "Адриан", "Азамат", "Азат", "Айдар", "Айнур", "Айрат", "Аким", "Алан", "Александр", "Алексей", "Али",
        "Алихан", "Алмаз", "Альберт", "Альфред", "Амадей", "Амадеус", "Амаяк", "Амин", "Амир", "Анвар", "Андрей",
        "Андрэ", "Аникита", "Антон", "Анфим", "Арам", "Аристарх", "Арман", "Армен", "Арно", "Арнольд", "Арон", "Арсен",
        "Арслан", "Артем", "Артур", "Архип", "Аскольд", "Ахмет", "Ашот", "Бахрам", "Бежен", "Бенедикт", "Берек",
        "Бернар", "Богдан", "Боголюб", "Бореслав", "Борис", "Борислав", "Боян", "Бронислав", "Бруно",
        "Булат", "Вадим", "Валентин", "Вальдемар", "Вальтер", "Вардан", "Варлаам", "Варфоломей",
        "Ватслав", "Велизар", "Велор", "Венедикт", "Вениамин", "Виктор", "Вилен", "Вилли", "Вильгельм",
        "Виссарион", "Витаутас", "Витольд", "Владимир", "Владислав", "Владлен", "Влас", "Володар",
        "Всеволод", "Вячеслав", "Гавриил", "Галактион", "Гамлет", "Гарри", "Гаяс", "Гевор", "Геворг",
        "Генри", "Генрих", "Геральд", "Герасим", "Герман", "Глеб", "Гоар", "Гордей", "Гордон", "Горислав",
        "Градимир", "Густав", "Давид", "Давлат", "Дамир", "Даниил", "Данислав", "Даньяр", "Демид",
        "Демьян", "Денис", "Джамал", "Джеймс", "Джереми", "Джозеф", "Джордан", "Джорж", "Дик", "Динар",
        "Добрыня", "Дональд", "Донат", "Донатос", "Дорофей", "Евграф", "Евдоким", "Евсей",
        "Егор", "Елизар", "Елисей", "Емельян", "Еремей", "Ермолай", "Ерофей", "Ефим", "Ефрем", "Жан",
        "Ждан", "Жерар", "Закир", "Замир", "Заур", "Захар", "Зенон", "Зигмунд", "Зураб", "Ибрагим", "Иван",
        "Игнат", "Игорь", "Иероним", "Измаил", "Израиль", "Илиан", "Илларион", "Ильхам", "Ильшат", "Илья",
        "Ильяс", "Иоанн", "Иоаким", "Ион", "Иосиф", "Ипполит", "Иса", "Исаак", "Исидор",
        "Искандер", "Ислам", "Исмаил", "Казбек", "Казимир", "Камиль", "Карен", "Карим", "Карл", "Ким", "Кир", "Кирилл",
        "Клаус", "Клим", "Климент", "Клод", "Кондрат", "Константин", "Корней", "Кузьма", "Лавр",
        "Лазарь", "Лев", "Леван", "Левон", "Ленар", "Леон", "Леонард", "Леонид", "Леопольд",
        "Лука", "Лукьян", "Любим", "Любомир", "Людвиг", "Люсьен", "Мавлюда", "Мадлен", "Май", "Майкл", "Макар",
        "Максим", "Максимильян", "Максуд", "Мансур", "Мануил", "Мар", "Марат", "Мариан", "Марк", "Марсель",
        "Мартин", "Матвей", "Махмуд", "Мераб", "Мечеслав", "Микула", "Милан", "Мирон", "Мирослав",
        "Митрофан", "Михаил", "Мишлов", "Модест", "Моисей", "Мстислав", "Мурат", "Муслим", "Мухаммед", "Назар",
        "Наиль", "Натан", "Наум", "Нестор", "Никанор", "Никита", "Никифор", "Никодим", "Никола", "Николай",
        "Никон", "Нильс", "Нисон", "Нифонт", "Норманн", "Олан", "Олег", "Олесь", "Онисим", "Орест", "Орландо",
        "Осип", "Оскар", "Остап", "Павел", "Панкрат", "Парамон", "Петр", "Платон", "Потап",
        "Прохор", "Равиль", "Радик", "Радомир", "Радослав", "Разиль", "Райан", "Раймонд", "Раис", "Рамазан",
        "Рамиз", "Рамиль", "Рамон", "Ранель", "Расим", "Расул", "Ратибор", "Ратмир", "Рафаил", "Рафаэль", "Рафик",
        "Рашид", "Рем", "Ринат", "Рифат", "Рихард", "Ричард", "Роберт", "Родион", "Ролан", "Роман", "Ростислав",
        "Рубен", "Рудольф", "Руслан", "Рустам", "Руфин", "Рушан", "Рэй", "Сабир", "Савва", "Самвел",
        "Самсон", "Самуил", "Святослав", "Севастьян", "Северин", "Семен", "Серафим", "Сергей", "Сидор", "Сократ",
        "Соломон", "Спартак", "Спиридон", "Стакрат", "Станислав", "Степан", "Стефан", "Стивен", "Стоян", "Султан",
        "Тагир", "Таис", "Тайлер", "Талик", "Тамаз", "Тамерлан", "Тарас", "Тельман", "Теодор", "Тибор",
        "Тиграм", "Тигран", "Тимофей", "Тимур", "Тит", "Тихон", "Томас", "Трифон", "Трофим", "Ульманас",
        "Умар", "Устин", "Фадей", "Фазиль", "Фанис", "Фарид", "Фархад", "Федор", "Федот", "Феликс",
        "Фердинанд", "Фидель", "Филимон", "Филипп", "Фома", "Франц", "Фред", "Фридрих", "Фуад", "Хабиб",
        "Хаким", "Харитон", "Христиан", "Христос", "Христофор", "Цезарь", "Чарльз", "Чеслав", "Чингиз", "Шамиль",
        "Шарль", "Эдвард", "Эдгар", "Эдмунд", "Эдуард", "Эльдар", "Эмиль", "Эмин", "Эммануил", "Эраст", "Эрик",
        "Эрнест", "Юлиан", "Юнус", "Юхим", "Яков", "Ян", "Ярослав", "Ясон"
    };

    public static string GetRandomName()
    {
        return NamesTemplate[new Random().Next(NamesTemplate.Count)];
    }
}